using PersonManagementApp.Business.Interfaces;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Services
{
    public class ProfessorService : BaseService<Professor>, IProfessorService
    {
        public ProfessorService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
