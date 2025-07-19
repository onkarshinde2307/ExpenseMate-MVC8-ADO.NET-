using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ExpenseMate.DAL;
using ExpenseMate.Models;

namespace ExpenseMate.Controllers
{
    public class ExpenseController : Controller
    {
        public IActionResult Index()
        {
            string query = "SELECT * FROM Expense ORDER BY ExpenseDate DESC";
            var expenses = DBManager.ExecuteReader(query, null, reader => new Expense
            {
                Id = Convert.ToInt32(reader["Id"]),
                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                CategoryName = reader["CategoryName"].ToString() ?? "",
                Description = reader["Description"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"])
            });

            return View(expenses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Expense model)
        {
            if (ModelState.IsValid)
            {
                string query = "INSERT INTO Expense (ExpenseDate, CategoryName, Description, Amount) VALUES (@ExpenseDate, @CategoryName, @Description, @Amount)";
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@ExpenseDate", model.ExpenseDate),
                    new SqlParameter("@CategoryName", model.CategoryName),
                    new SqlParameter("@Description", model.Description),
                    new SqlParameter("@Amount", model.Amount)
                };
                DBManager.ExecuteNonQuery(query, parameters);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            string query = "SELECT * FROM Expense WHERE Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            var expense = DBManager.ExecuteReader(query, parameters, reader => new Expense
            {
                Id = Convert.ToInt32(reader["Id"]),
                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                CategoryName = reader["CategoryName"].ToString() ?? "",
                Description = reader["Description"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"])
            }).FirstOrDefault();

            return View(expense);
        }

        [HttpPost]
        public IActionResult Edit(Expense model)
        {
            if (ModelState.IsValid)
            {
                string query = "UPDATE Expense SET ExpenseDate=@ExpenseDate, CategoryName=@CategoryName, Description=@Description, Amount=@Amount WHERE Id=@Id";
                SqlParameter[] parameters = new[]
                {
                    new SqlParameter("@ExpenseDate", model.ExpenseDate),
                    new SqlParameter("@CategoryName", model.CategoryName),
                    new SqlParameter("@Description", model.Description),
                    new SqlParameter("@Amount", model.Amount),
                    new SqlParameter("@Id", model.Id)
                };
                DBManager.ExecuteNonQuery(query, parameters);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            string query = "SELECT * FROM Expense WHERE Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            var expense = DBManager.ExecuteReader(query, parameters, reader => new Expense
            {
                Id = Convert.ToInt32(reader["Id"]),
                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                CategoryName = reader["CategoryName"].ToString() ?? "",
                Description = reader["Description"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"])
            }).FirstOrDefault();

            return View(expense);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            string query = "DELETE FROM Expense WHERE Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            DBManager.ExecuteNonQuery(query, parameters);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            string query = "SELECT * FROM Expense WHERE Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };
            var expense = DBManager.ExecuteReader(query, parameters, reader => new Expense
            {
                Id = Convert.ToInt32(reader["Id"]),
                ExpenseDate = Convert.ToDateTime(reader["ExpenseDate"]),
                CategoryName = reader["CategoryName"].ToString() ?? "",
                Description = reader["Description"].ToString() ?? "",
                Amount = Convert.ToDecimal(reader["Amount"])
            }).FirstOrDefault();

            return View(expense);
        }
    }
}
