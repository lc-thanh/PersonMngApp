using System.ComponentModel.DataAnnotations;

namespace PersonManagementApp.Data.Models
{
    public class Student : Person
    {
        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
    }
}
