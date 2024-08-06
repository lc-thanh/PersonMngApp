using Microsoft.EntityFrameworkCore;
using PersonManagementApp.Business.Dto;
using PersonManagementApp.Business.Interfaces;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Business.Services
{
    public class PersonService : BaseService<Person>, IPersonService
    {
        public PersonService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<PersonViewModel>> GetAllPeopleAllRoleAsync()
        {
            var students = await _unitOfWork.StudentRepository.GetQuery()
            .Include(s => s.Address)
            .Select(s => new PersonViewModel
            {
                Id = s.Id,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
                EmailAddress = s.EmailAddress,
                Role = "Student",
                Address = s.Address.Number + " - " + s.Address.Name
            })
            .ToListAsync();

            var professors = await _unitOfWork.ProfessorRepository.GetQuery()
            .Include(s => s.Address)
            .Select(s => new PersonViewModel
            {
                Id = s.Id,
                FullName = s.FullName,
                PhoneNumber = s.PhoneNumber,
                EmailAddress = s.EmailAddress,
                Role = "Professor",
                Address = s.Address.Number + " - " + s.Address.Name
            })
            .ToListAsync();

            var persons = students.Concat(professors).ToList();

            return persons;
        }
        public async Task<bool> CreatePerson(PersonCreateModel personCreateModel)
        {
            if (personCreateModel == null)
                return false;

            if (personCreateModel.Role.Equals("Student"))
            {
                Student student = new Student
                {
                    FullName = personCreateModel.FullName,
                    PhoneNumber= personCreateModel.PhoneNumber,
                    EmailAddress = personCreateModel.EmailAddress,
                    StudentNumber = personCreateModel.StudentNumber,
                    AverageMark = personCreateModel.AverageMark,
                };

                string addressName = personCreateModel.Address.Split("-")[1].Trim();
                int addressNumber;
                if (!int.TryParse(personCreateModel.Address.Split("-")[0].Trim(), out addressNumber))
                    return false;

                Address address = new Address
                {
                    Name = addressName,
                    Number = addressNumber,
                    Person = student
                };

                _unitOfWork.AddressRepository.Add(address);
                _unitOfWork.StudentRepository.Add(student);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }

            if (personCreateModel.Role.Equals("Professor"))
            {
                Professor professor = new Professor
                {
                    FullName = personCreateModel.FullName,
                    PhoneNumber = personCreateModel.PhoneNumber,
                    EmailAddress = personCreateModel.EmailAddress,
                    Salary = personCreateModel.Salary,
                };

                string addressName = personCreateModel.Address.Split("-")[1].Trim();
                int addressNumber;
                if (!int.TryParse(personCreateModel.Address.Split("-")[0].Trim(), out addressNumber))
                    return false;

                Address address = new Address
                {
                    Name = addressName,
                    Number = addressNumber,
                    Person = professor
                };

                _unitOfWork.AddressRepository.Add(address);
                _unitOfWork.ProfessorRepository.Add(professor);

                await _unitOfWork.SaveChangesAsync();

                return true;
            }

            return false;
        }
    }
}
