using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Product.Infrastructure.Data
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Domain.Entities.Product> Products;
        
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
            // base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasAnnotation("Npgsql:ValueGenerationStrategy",
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            
            modelBuilder.Entity<Domain.Entities.Product>(entity =>
            {
                entity.ToTable("product", "product");
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id)
                    .HasName("productProductPK");

                entity.Property(e => e.Name)
                    .HasColumnName("name");
                entity.Property(e => e.BrandId)
                    .HasColumnName("brandId")
                    .HasColumnType("int");
                entity.Property(e => e.BrandName)
                    .HasColumnName("brandName");
                entity.Property(e => e.RusSize)
                    .HasColumnName("rusSize");
            });  
            
        }
    }
}