using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using admininterface.Models;
namespace admininterface.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<TreatmentModel> Treatments { get; set; }
    public DbSet<TreatmentTypeModel> TreatmentTypes { get; set; }
    public DbSet<BookingModel> Bookings { get; set; }
}
