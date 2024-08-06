using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Repositories
{
    public class ProfessorRepository : BaseRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(PersonManageAppDbContext context) : base(context)
        {
        }
    }
}
