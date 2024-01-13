using AllInOne.Entity.Models.Popup;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<EmployeePopup> employeePopups { get; set; }
    }
}
