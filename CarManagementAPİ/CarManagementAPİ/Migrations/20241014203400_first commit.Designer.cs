﻿// <auto-generated />
using System;
using CarManagementAPİ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarManagementAPİ.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241014203400_first commit")]
    partial class firstcommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.Marka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Markas");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpeacialModelId")
                        .HasColumnType("int");

                    b.Property<int?>("SpecialModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SpeacialModelId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.SpeacialModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MarkaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MarkaId");

                    b.ToTable("SpeacialModels");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.Person", b =>
                {
                    b.HasOne("CarManagementAPİ.Data.Entity.SpeacialModel", "SpeacialModel")
                        .WithMany("Persons")
                        .HasForeignKey("SpeacialModelId");

                    b.Navigation("SpeacialModel");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.SpeacialModel", b =>
                {
                    b.HasOne("CarManagementAPİ.Data.Entity.Marka", "Marka")
                        .WithMany("SpeacialModels")
                        .HasForeignKey("MarkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marka");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.Marka", b =>
                {
                    b.Navigation("SpeacialModels");
                });

            modelBuilder.Entity("CarManagementAPİ.Data.Entity.SpeacialModel", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
