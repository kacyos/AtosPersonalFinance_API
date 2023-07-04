using AtosPersonalFinance_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AtosPersonalFinance_API.Data.Mapping
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50)
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("type")
                .HasColumnType("VARCHAR");

            builder
                .Property(x => x.Color)
                .IsRequired()
                .HasColumnName("color")
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR");

            builder
                .Property(x => x.Icon)
                .IsRequired()
                .HasColumnName("icon")
                .HasMaxLength(50)
                .HasColumnType("NVARCHAR");

            builder.HasData(CategoryDefault.generate());
        }
    }
}
