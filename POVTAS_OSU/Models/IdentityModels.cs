using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace POVTAS_OSU.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }


    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<AcademicTitle> AcademicTitles { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ChairConsist> ChairConsists { get; set; }
        public DbSet<SupportStaff> SupportStaffs { get; set; }
        

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Chair> Chairs { get; set; }

        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<CalendarOfEvent> CalendarOfEvents { get; set; }
        public DbSet<Classroom> Classrooms  { get; set; }

        public DbSet<Discipline> Disciplines  { get; set; }
        public DbSet<EducationField> EducationFields  { get; set; }
        public DbSet<MaterialSupport> MaterialSupports  { get; set; }
        public DbSet<Post> Posts  { get; set; }
        public DbSet<NewsType> NewsTypes { get; set; }
        public DbSet<TechnicalFacility> TechnicalFacilities  { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}