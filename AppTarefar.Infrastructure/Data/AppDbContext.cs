using AppTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppTarefar.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
