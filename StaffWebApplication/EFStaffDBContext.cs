using Microsoft.EntityFrameworkCore;
using StaffWebApplication.Models;

namespace StaffWebApplication
{
    public class EFStaffDBContext : DbContext
    {
        public EFStaffDBContext(DbContextOptions<EFStaffDBContext> options) : base(options)
        { }
        public DbSet<Staff> Staff { get; set; }
    }
}
