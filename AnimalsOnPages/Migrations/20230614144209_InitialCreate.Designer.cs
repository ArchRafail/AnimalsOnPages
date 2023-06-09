﻿// <auto-generated />
using System;
using AnimalsOnPages.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AnimalsOnPages.Migrations
{
    [DbContext(typeof(AnimalsDdContext))]
    [Migration("20230614144209_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AnimalsOnPages.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Building")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoverColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sound")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Animals");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Animal");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Zoo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.ToTable("Zoos");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.ZooAnimal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnimalId")
                        .HasColumnType("int");

                    b.Property<int>("ZooId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("ZooId");

                    b.ToTable("ZooAnimal", (string)null);
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Amphibia", b =>
                {
                    b.HasBaseType("AnimalsOnPages.Models.Animal");

                    b.HasDiscriminator().HasValue("Amphibia");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Mammal", b =>
                {
                    b.HasBaseType("AnimalsOnPages.Models.Animal");

                    b.HasDiscriminator().HasValue("Mammal");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Reptile", b =>
                {
                    b.HasBaseType("AnimalsOnPages.Models.Animal");

                    b.HasDiscriminator().HasValue("Reptile");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Zoo", b =>
                {
                    b.HasOne("AnimalsOnPages.Models.Address", "Address")
                        .WithOne("Zoo")
                        .HasForeignKey("AnimalsOnPages.Models.Zoo", "AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.ZooAnimal", b =>
                {
                    b.HasOne("AnimalsOnPages.Models.Animal", "Animal")
                        .WithMany()
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimalsOnPages.Models.Zoo", "Zoo")
                        .WithMany()
                        .HasForeignKey("ZooId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Zoo");
                });

            modelBuilder.Entity("AnimalsOnPages.Models.Address", b =>
                {
                    b.Navigation("Zoo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
