using BPKBManagementAPI.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace BPKBManagementAPI.Data;

public class BPKBManagementAPIContext : IdentityDbContext<ApplicationUser>
{
    public BPKBManagementAPIContext(DbContextOptions<BPKBManagementAPIContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<TrBpkb> TrBpkb { get; set; }
    public DbSet<MsStorageLocation> MsStorageLocation { get; set; }
}
