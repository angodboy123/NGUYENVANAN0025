﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NguyenVanAn0025.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230623012429_Create_Table_NVA025SanPham")]
    partial class Create_Table_NVA025SanPham
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.7");

            modelBuilder.Entity("NguyenVanAn0025.Models.NVA025SanPham", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasColumnType("TEXT");

                    b.Property<string>("GiaSanPham")
                        .HasColumnType("TEXT");

                    b.Property<string>("TenSanPham")
                        .HasColumnType("TEXT");

                    b.HasKey("MaSanPham");

                    b.ToTable("SanPham");
                });
#pragma warning restore 612, 618
        }
    }
}
