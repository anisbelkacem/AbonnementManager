﻿// <auto-generated />
using System;
using AbonnementManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbonnementManager.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240729225523_EditAbonModel1")]
    partial class EditAbonModel1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AbonnementManager.Models.Abonnement", b =>
                {
                    b.Property<int>("Id_Abon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Abon"));

                    b.Property<DateOnly>("DateDebut")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DateFin")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdApp")
                        .HasColumnType("int");

                    b.Property<int>("IdClient")
                        .HasColumnType("int");

                    b.HasKey("Id_Abon");

                    b.HasIndex("IdApp");

                    b.HasIndex("IdClient");

                    b.ToTable("abonnements");
                });

            modelBuilder.Entity("AbonnementManager.Models.Application", b =>
                {
                    b.Property<int>("Id_App")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_App"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_App");

                    b.ToTable("applications");
                });

            modelBuilder.Entity("AbonnementManager.Models.Client", b =>
                {
                    b.Property<int>("Id_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Client"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Client");

                    b.ToTable("clients");

                    b.HasData(
                        new
                        {
                            Id_Client = 1,
                            Description = "hello my name is anis",
                            Email = "Anis@gmail.com",
                            LastName = "Belkacem",
                            Name = "Anis",
                            Tel = "+216 29172360"
                        },
                        new
                        {
                            Id_Client = 2,
                            Description = "hello my name is Test",
                            Email = "Test@gmail.com",
                            LastName = "Test",
                            Name = "Test",
                            Tel = "+216 29172360"
                        },
                        new
                        {
                            Id_Client = 3,
                            Description = "hello my name is Admin",
                            Email = "Admin@gmail.com",
                            LastName = "Admin",
                            Name = "Admin",
                            Tel = "+216 29172360"
                        });
                });

            modelBuilder.Entity("AbonnementManager.Models.Abonnement", b =>
                {
                    b.HasOne("AbonnementManager.Models.Application", "Application")
                        .WithMany()
                        .HasForeignKey("IdApp")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AbonnementManager.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
