using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using hr_jide.Models;
using System.Collections;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace hr_jide.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // DbSet implementation .
        public DbSet<Employee> Employee { get; set; }
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<PayGrades> PayGrades { get; set; }
        public DbSet<EmployementStatus> EmployementStatus { get; set; }
        public DbSet<JobCategories> JobCategories { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<CompanyInformation> CompanyInformation { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<CompanyBranch> CompanyBranch{ get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Licenses> Licenses { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Nationalities> Nationalities { get; set; }
        public DbSet<EmployeeContactDetails> EmployeeContactDetails { get; set; }
        public DbSet<EmployeeEmergencyContact> EmployeeEmergencyContacts { get; set; }
        public DbSet<EmployeeDependant> EmployeeDependants { get; set; }
        public DbSet<EmployeeImmigration> EmployeeImmigrations { get; set; }
        public DbSet<EmployeeJob> EmployeeJobs { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public DbSet<EmployeeMembership> EmployeeMemberships { get; set; }
        public DbSet<EmployeeSupervisor> EmployeeSupervisors { get; set; }
        public DbSet<EmployeeSubordinate> EmployeeSubordinates { get; set; }
        public DbSet<EmployeeWorkExperience> EmployeeWorkExperiences { get; set; }
        public DbSet<EmployeeEducation> EmployeeEducations { get; set; }
        public DbSet<EmployeeSkills> EmployeeSkills { get; set; }
        public DbSet<EmployeeLanguage> EmployeeLanguages { get; set; }
        public DbSet<EmployeeLicense> EmployeeLicenses { get; set; }

      

        public DbSet<Employ> Employ { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<ReportingMethod> ReportingMethod { get; set; }

        public DbSet<Relationship> Relationship { get; set; }

        public DbSet<Currency>  Currency { get; set; }

        public DbSet<DocumentType> DocumentType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }


        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var currentUsername = !string.IsNullOrEmpty(userId)
                ? userId
                : "Anonymous";

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedDate = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).CreatedBy = currentUsername;
                }

                ((BaseEntity)entity.Entity).ModifiedDate = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).ModifiedBy = currentUsername;
            }
        }

        internal void Update(EmployeeSupervisor employeeSupervisor)
        {
            throw new NotImplementedException();
        }

        public DbSet<hr_jide.Models.PayFrequency> PayFrequency { get; set; }

        
    }
}