using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Dto
{
    public class PersonViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
