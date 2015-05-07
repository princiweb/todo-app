using System.Data.Entity.ModelConfiguration;
using TodoApp.Domain.Models;

namespace TodoApp.Data.Mappings
{
    public class TarefaMap : EntityTypeConfiguration<Tarefa>
    {
        public TarefaMap()
        {
            ToTable("Tarefas");

            Property(x => x.Titulo).HasMaxLength(100).IsRequired();

            Property(x => x.CriadoEm).IsRequired();

            Property(x => x.Status).IsRequired();

            HasRequired(x => x.CriadoPor);
        }
    }
}
