using System.ComponentModel.DataAnnotations;

namespace PersonManagementApp.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(11, 99)]
        public int Number { get; set; }

        public int AddressOfPersonId { get; set; }
        public Person Person { get; set; }
    }
}
