using Microsoft.EntityFrameworkCore;
using TestBackend.Models;

namespace TestBackend.Data
{
    public class TarefaDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public TarefaDbContext(DbContextOptions<TarefaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Definir configurações adicionais do modelo, como chaves primárias, índices, etc.

            // Exemplo de configuração para a classe Tarefa
            modelBuilder.Entity<Tarefa>()
                .HasKey(t => t.Id);
        }
    }
}
