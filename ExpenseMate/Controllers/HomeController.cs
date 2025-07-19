using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ExpenseMate.DAL;
using ExpenseMate.Models;

namespace ExpenseMate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            decimal monthIncome = 0;
            decimal monthExpense = 0;
            decimal remaining = 0;
            decimal todayExpenseTotal = 0;

            // ✅ 1. Get Current Month Income
            string incomeQuery = @"
                SELECT ISNULL(SUM(Amount), 0)
                FROM Income
                WHERE MONTH(IncomeDate) = MONTH(GETDATE()) AND YEAR(IncomeDate) = YEAR(GETDATE())";

            object? incomeResult = DBManager.ExecuteScalar(incomeQuery);
            monthIncome = incomeResult != null ? Convert.ToDecimal(incomeResult) : 0;

            // ✅ 2. Get Current Month Expense
            string expenseQuery = @"
                SELECT ISNULL(SUM(Amount), 0)
                FROM Expense
                WHERE MONTH(ExpenseDate) = MONTH(GETDATE()) AND YEAR(ExpenseDate) = YEAR(GETDATE())";

            object? expenseResult = DBManager.ExecuteScalar(expenseQuery);
            monthExpense = expenseResult != null ? Convert.ToDecimal(expenseResult) : 0;

            // ✅ 3. Remaining Balance = Income - Expense
            remaining = monthIncome - monthExpense;

            // ✅ 4. Get Today's Expense Entries
            string todayQuery = @"
                SELECT * FROM Expense 
                WHERE CAST(ExpenseDate AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY ExpenseDate DESC";

            List<Expense> todayExpenses = DBManager.ExecuteReader(todayQuery, null, reader => new Expense
            {
                Id = Convert.ToInt32(reader["Id"]),
                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                CategoryName = reader["CategoryName"].ToString() ?? "",
                Description = reader["Description"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"])
            });

            // ✅ 5. Calculate Today's Expense Total
            todayExpenseTotal = todayExpenses.Sum(e => e.Amount);

            // ✅ 6. Pass All Data to ViewBag
            ViewBag.MonthIncome = monthIncome;
            ViewBag.MonthTotal = monthExpense;
            ViewBag.RemainingBalance = remaining;
            ViewBag.TodayExpenses = todayExpenses;
            ViewBag.TodayExpenseTotal = todayExpenseTotal;

            return View();
        }
    }
}
