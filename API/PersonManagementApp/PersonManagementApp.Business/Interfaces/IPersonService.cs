using PersonManagementApp.Business.Dto;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Interfaces
{
    public interface IPersonService : IBaseService<Person>
    {
        Task<IEnumerable<PersonViewModel>> GetAllPeopleAllRoleAsync();
        Task<bool> CreatePerson(PersonCreateModel personCreateModel);
    }
}
