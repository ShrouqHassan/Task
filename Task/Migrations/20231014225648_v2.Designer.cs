﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task.Models;

#nullable disable

namespace Task.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231014225648_v2")]
    partial class v2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Task.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("DeletedDate")
                        .HasColumnType("date");

                    b.Property<string>("Filepath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("Task.Models.Glass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("catalog_id")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("side")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("catalog_id");

                    b.ToTable("Glass");
                });

            modelBuilder.Entity("Task.Models.Glass", b =>
                {
                    b.HasOne("Task.Models.Catalog", "catalog")
                        .WithMany("Glass")
                        .HasForeignKey("catalog_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("catalog");
                });

            modelBuilder.Entity("Task.Models.Catalog", b =>
                {
                    b.Navigation("Glass");
                });
#pragma warning restore 612, 618
        }
    }
}
