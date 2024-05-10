using Microsoft.EntityFrameworkCore;
using Teste.ToDoList.Infra.Entidades;

namespace Teste.ToDoList.Infra.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) 
            : base(options) 
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}
