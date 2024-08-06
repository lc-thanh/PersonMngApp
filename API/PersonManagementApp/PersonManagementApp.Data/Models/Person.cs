using System.ComponentModel.DataAnnotations;

namespace PersonManagementApp.Data.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        public Address Address { get; set; }
    }
}
