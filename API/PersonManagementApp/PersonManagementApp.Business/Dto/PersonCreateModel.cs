using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Dto
{
    public class PersonCreateModel
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string StudentNumber { get; set; }
        public double AverageMark { get; set; }
        public double Salary { get; set; }
    }
}
