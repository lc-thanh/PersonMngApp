using PersonManagementApp.Business.Interfaces;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        public StudentService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
