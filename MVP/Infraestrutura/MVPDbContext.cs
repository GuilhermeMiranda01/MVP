using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MVP.Entidades;

public class MVPDbContext : DbContext, IDesignTimeDbContextFactory<MVPDbContext>
{

    public MVPDbContext(DbContextOptions<MVPDbContext> options):
        base(options)
        {
        }
        public MVPDbContext()
        {
            
        }

    public DbSet<SituacaoUsuario> SituacaoUsuario{get;set;}

    public MVPDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MVPDbContext>();
        optionsBuilder.UseSqlite("Data Source=mvp.db");

        return new MVPDbContext(optionsBuilder.Options);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<SituacaoUsuario>().HasData(
            new SituacaoUsuario { Id = 1, CPF = "123456", TemProcesso = true },
            new SituacaoUsuario { Id = 2, CPF = "654321", TemProcesso = false },
            new SituacaoUsuario { Id = 3, CPF = "111", TemProcesso = true});
        }
}