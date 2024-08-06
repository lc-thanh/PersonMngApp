using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        PersonManageAppDbContext Context { get; }
        IBaseRepository<Person> PersonRepository { get; }
        IBaseRepository<Address> AddressRepository { get; }
        IBaseRepository<Student> StudentRepository { get; }
        IBaseRepository<Professor> ProfessorRepository { get; }
        IBaseRepository<T> BaseRepository<T>() where T : class;
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
