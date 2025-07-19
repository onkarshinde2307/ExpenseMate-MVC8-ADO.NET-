namespace ExpenseMate.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}
