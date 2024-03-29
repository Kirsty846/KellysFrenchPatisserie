﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatisserieAPI.Model;

#nullable disable

namespace PatisserieAPI.Migrations
{
    [DbContext(typeof(PatisserieDbContext))]
    partial class PatisserieDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PatisserieAPI.Model.Flavour", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Flavour");
                });

            modelBuilder.Entity("PatisserieAPI.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Product");
                });

            modelBuilder.Entity("PatisserieAPI.Model.CelebrationCake", b =>
                {
                    b.HasBaseType("PatisserieAPI.Model.Product");

                    b.Property<string>("FlavourId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("CelebrationCake_FlavourId");

                    b.Property<string>("IcingFlavour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tiers")
                        .HasColumnType("int");

                    b.HasIndex("FlavourId");

                    b.HasDiscriminator().HasValue("CelebrationCake");
                });

            modelBuilder.Entity("PatisserieAPI.Model.Fudge", b =>
                {
                    b.HasBaseType("PatisserieAPI.Model.Product");

                    b.Property<string>("FlavourId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Fudge_FlavourId");

                    b.Property<double>("Size")
                        .HasColumnType("float")
                        .HasColumnName("Fudge_Size");

                    b.HasIndex("FlavourId");

                    b.HasDiscriminator().HasValue("Fudge");
                });

            modelBuilder.Entity("PatisserieAPI.Model.Macaroon", b =>
                {
                    b.HasBaseType("PatisserieAPI.Model.Product");

                    b.Property<string>("FlavourId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Size")
                        .HasColumnType("float");

                    b.HasIndex("FlavourId");

                    b.HasDiscriminator().HasValue("Macaroon");
                });

            modelBuilder.Entity("PatisserieAPI.Model.MiniTart", b =>
                {
                    b.HasBaseType("PatisserieAPI.Model.Product");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("MiniTart");
                });

            modelBuilder.Entity("PatisserieAPI.Model.CelebrationCake", b =>
                {
                    b.HasOne("PatisserieAPI.Model.Flavour", "Flavour")
                        .WithMany()
                        .HasForeignKey("FlavourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Flavour");
                });

            modelBuilder.Entity("PatisserieAPI.Model.Fudge", b =>
                {
                    b.HasOne("PatisserieAPI.Model.Flavour", "Flavour")
                        .WithMany()
                        .HasForeignKey("FlavourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Flavour");
                });

            modelBuilder.Entity("PatisserieAPI.Model.Macaroon", b =>
                {
                    b.HasOne("PatisserieAPI.Model.Flavour", "Flavour")
                        .WithMany()
                        .HasForeignKey("FlavourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Flavour");
                });
#pragma warning restore 612, 618
        }
    }
}
