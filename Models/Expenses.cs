using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Expenses
    {
     public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null;
        [Required]
        [Range (0.01, double. MaxValue, ErrorMessage ="Amount needs to be higher than o")]
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public DateTime Date { get; set; } = DateTime. Now;
    }
}
