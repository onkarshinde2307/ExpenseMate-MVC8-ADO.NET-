using System.ComponentModel.DataAnnotations;

namespace ExpenseMate.Models
{
    public class Income
    {
        public int Id { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime IncomeDate { get; set; }

        [Required(ErrorMessage = "Source is required")]
        public string Source { get; set; } = "";  // ✅ Prevent null reference

        [Required]
        [Range(1, 1000000)]
        public decimal Amount { get; set; }
        //public DateTime ReceivedDate { get; internal set; }
    }
}


