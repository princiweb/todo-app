using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using TodoApp.Domain.Models;

namespace TodoApp.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuarios");

            Property(x => x.Nome).HasMaxLength(100).IsRequired();

            Property(x => x.Email).HasMaxLength(60).IsRequired()
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("IX_Usuarios_EmailUnico", 1) { IsUnique = true }));

            Property(x => x.Senha).HasMaxLength(64).IsRequired();
        }
    }
}
