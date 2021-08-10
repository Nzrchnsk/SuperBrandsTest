using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;


namespace Brand.Infrastructure.Data
{
    public class BrandDBContext : DbContext
    {
        public DbSet<Domain.Entities.BrandAggregate.Brand> Brands;
        public DbSet<Domain.Entities.BrandAggregate.Size> Sizes;
        
        public BrandDBContext(DbContextOptions<BrandDBContext> options) : base(options)
        {
            // base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseIdentityColumns();
            modelBuilder.HasAnnotation("Npgsql:ValueGenerationStrategy",
                NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            
            modelBuilder.Entity<Domain.Entities.BrandAggregate.Brand>(entity =>
            {
                entity.ToTable("brand", "brand");
                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.HasKey(e => e.Id).HasName("brandBrandPK");

                entity.Property(e => e.Name).HasColumnName("name");

            });  
            
            modelBuilder.Entity<Domain.Entities.BrandAggregate.Size>(entity =>
            {
                entity.ToTable("size", "brand");

                entity.Property<int>("id")
                    .IsRequired()
                    .HasColumnName("id")
                    .HasColumnType("int")
                    .ValueGeneratedOnAdd();
                
                entity.HasKey("id").HasName("brandSizePK");
            
                entity.Property(e => e.RusSize).HasColumnName("rusSize");
                entity.Property(e => e.BrandSize).HasColumnName("brandSize");
                
                entity.Property(e => e.BrandId).HasColumnName("brandId");
                entity.HasOne(e => e.Brand)
                    .WithMany(e => e.Sizes)
                    .HasForeignKey(e => e.BrandId);
            });
        }

    }
}