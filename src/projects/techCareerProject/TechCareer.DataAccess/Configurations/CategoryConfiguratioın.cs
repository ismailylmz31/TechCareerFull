using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechCareer.Models.Entities;


namespace TechCareer.DataAccess.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("CategoryId")
                .IsRequired();

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100); // Gerekirse uzunluk sınırı belirtebilirsiniz.

            // Navigation Property'yi AutoInclude kaldırılıyor veya Events'e yönlendiriliyor
            // builder.Navigation(c => c.Event).AutoInclude(); // Hatalı
        }

    }
}