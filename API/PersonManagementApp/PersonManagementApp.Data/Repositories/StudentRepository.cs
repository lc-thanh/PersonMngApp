using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(PersonManageAppDbContext context) : base(context)
        {
        }
    }
}
