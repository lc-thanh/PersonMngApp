using Microsoft.EntityFrameworkCore;
using PersonManagementApp.Data.Models;

namespace PersonManagementApp.Data.Data
{
    public class PersonManageAppDbContext : DbContext 
    {
        public PersonManageAppDbContext(DbContextOptions<PersonManageAppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>()
                .HasOne<Address>(p => p.Address)
                .WithOne(ad => ad.Person)
                .HasForeignKey<Address>(ad => ad.AddressOfPersonId);

            // Seed Address data
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, Name = "Hà Nội", Number = 30, AddressOfPersonId = 2 },
                new Address { Id = 2, Name = "Hà Tĩnh", Number = 38, AddressOfPersonId = 1 },
                new Address { Id = 3, Name = "Quảng Bình", Number = 73, AddressOfPersonId = 3 },
                new Address { Id = 4, Name = "Nghệ An", Number = 37, AddressOfPersonId = 4 }
            );

            // Seed Student data
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Lê Công Thành", PhoneNumber = "0834361811", EmailAddress = "student.a@example.com", StudentNumber = "000001", AverageMark = 85.5 },
                new Student { Id = 2, FullName = "Nguyễn Văn A", PhoneNumber = "0747657485", EmailAddress = "student.bb@example.com", StudentNumber = "000002", AverageMark = 75.5 }
            );

            // Seed Professor data
            modelBuilder.Entity<Professor>().HasData(
                new Professor { Id = 3, FullName = "Nguyễn Thanh Bình", PhoneNumber = "0343689648", EmailAddress = "professor.a@example.com", Salary = 50000 },
                new Professor { Id = 4, FullName = "Trần Văn Dương", PhoneNumber = "0969483658", EmailAddress = "professor.bb@example.com", Salary = 100000 }
            );
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
