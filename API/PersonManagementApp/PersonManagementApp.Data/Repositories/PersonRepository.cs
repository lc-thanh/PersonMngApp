using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Repositories
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(PersonManageAppDbContext context) : base(context)
        {
        }
    }
}
