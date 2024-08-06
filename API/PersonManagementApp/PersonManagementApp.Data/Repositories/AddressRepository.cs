using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(PersonManageAppDbContext context) : base(context)
        {
        }
    }
}
