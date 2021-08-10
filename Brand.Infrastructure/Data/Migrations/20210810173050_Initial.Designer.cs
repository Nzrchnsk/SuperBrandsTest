﻿// <auto-generated />
using Brand.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Brand.Infrastructure.Data.Migrations
{
    [DbContext(typeof(BrandDBContext))]
    [Migration("20210810173050_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Brand.Domain.Entities.BrandAggregate.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("brandBrandPK");

                    b.ToTable("brand", "brand");
                });

            modelBuilder.Entity("Brand.Domain.Entities.BrandAggregate.Size", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int")
                        .HasColumnName("brandId");

                    b.Property<string>("BrandSize")
                        .HasColumnType("text")
                        .HasColumnName("brandSize");

                    b.Property<string>("RusSize")
                        .HasColumnType("text")
                        .HasColumnName("rusSize");

                    b.HasKey("id")
                        .HasName("brandSizePK");

                    b.HasIndex("BrandId");

                    b.ToTable("size", "brand");
                });

            modelBuilder.Entity("Brand.Domain.Entities.BrandAggregate.Size", b =>
                {
                    b.HasOne("Brand.Domain.Entities.BrandAggregate.Brand", "Brand")
                        .WithMany("Sizes")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Brand.Domain.Entities.BrandAggregate.Brand", b =>
                {
                    b.Navigation("Sizes");
                });
#pragma warning restore 612, 618
        }
    }
}
