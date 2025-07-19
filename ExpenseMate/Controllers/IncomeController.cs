using ExpenseMate.DAL;
using ExpenseMate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ExpenseMate.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            string query = "SELECT * FROM Income ORDER BY IncomeDate"; // Latest first
            var list = DBManager.ExecuteReader(query, null, r => new Income
            {
                Id = (int)r["Id"],
                IncomeDate = (DateTime)r["IncomeDate"],
                Source = r["Source"].ToString()!,
                Amount = (decimal)r["Amount"]
            });
            return View(list);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Income income)
        {
            if (!ModelState.IsValid)
                return View(income);

            string query = "INSERT INTO Income (IncomeDate, Source, Amount) VALUES (@date, @source, @amount)";
            var param = new[]
            {
                new SqlParameter("@date", income.IncomeDate),
                new SqlParameter("@source", income.Source),
                new SqlParameter("@amount", income.Amount)
            };
            DBManager.ExecuteNonQuery(query, param);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            string query = "SELECT * FROM Income WHERE Id=@id";
            var param = new[] { new SqlParameter("@id", id) };
            var income = DBManager.ExecuteReader(query, param, r => new Income
            {
                Id = (int)r["Id"],
                IncomeDate = (DateTime)r["IncomeDate"],
                Source = r["Source"].ToString()!,
                Amount = (decimal)r["Amount"]
            }).FirstOrDefault();

            return View(income);
        }

        [HttpPost]
        public IActionResult Edit(Income income)
        {
            if (!ModelState.IsValid)
                return View(income);

            string query = "UPDATE Income SET IncomeDate=@date, Source=@source, Amount=@amount WHERE Id=@id";
            var param = new[]
            {
                new SqlParameter("@date", income.IncomeDate),
                new SqlParameter("@source", income.Source),
                new SqlParameter("@amount", income.Amount),
                new SqlParameter("@id", income.Id)
            };
            DBManager.ExecuteNonQuery(query, param);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            string query = "DELETE FROM Income WHERE Id=@id";
            var param = new[] { new SqlParameter("@id", id) };
            DBManager.ExecuteNonQuery(query, param);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            string query = "SELECT * FROM Income WHERE Id=@id";
            var param = new[] { new SqlParameter("@id", id) };
            var income = DBManager.ExecuteReader(query, param, r => new Income
            {
                Id = (int)r["Id"],
                IncomeDate = (DateTime)r["IncomeDate"],
                Source = r["Source"].ToString()!,
                Amount = (decimal)r["Amount"]
            }).FirstOrDefault();

            return View(income);
        }
    }
}
