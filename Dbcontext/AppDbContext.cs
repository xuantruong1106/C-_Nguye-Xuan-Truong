using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Phongtro> phongtros { get; set; }
    public DbSet<Hinhthucthanhtoan> Hinhthucthanhtoans { get; set; }
}
