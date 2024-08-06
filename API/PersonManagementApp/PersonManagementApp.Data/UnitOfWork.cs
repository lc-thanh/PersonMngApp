using Microsoft.EntityFrameworkCore.Storage;
using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;
using PersonManagementApp.Data.Models;
using PersonManagementApp.Data.Repositories;

namespace PersonManagementApp.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonManageAppDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(PersonManageAppDbContext context)
        {
            _context = context;
        }

        public PersonManageAppDbContext Context => _context;

        public IBaseRepository<Person> PersonRepository => new PersonRepository(_context);
        public IBaseRepository<Address> AddressRepository => new AddressRepository(_context);
        public IBaseRepository<Student> StudentRepository => new StudentRepository(_context);
        public IBaseRepository<Professor> ProfessorRepository => new ProfessorRepository(_context);

        public IBaseRepository<T> BaseRepository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
            _transaction.Dispose();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
