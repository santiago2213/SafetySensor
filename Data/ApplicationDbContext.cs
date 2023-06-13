using LibraryGroup7;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcGroup7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Engineer> Engineer { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<IT> IT { get; set; }
        public DbSet<RecordedData> RecordedData { get; set; }
        public DbSet<SensorRepairRequest> SensorRepairRequest { get; set; }
        public DbSet<Facility> Facility { get; set; }   
        public DbSet<SensorLocation> SensorLocation { get; set; }
        public DbSet<Notes> Note { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}