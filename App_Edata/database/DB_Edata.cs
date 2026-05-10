using Microsoft.EntityFrameworkCore;

class DB_Edata : DbContext
{
    public DB_Edata(DbContextOptions<DB_Edata> options)
        : base(options) { }
    
    public DbSet<RSE_data> RSE_datas => Set<RSE_data>();

    public DbSet<Technician_data> Technician_datas => Set<Technician_data>();
}
