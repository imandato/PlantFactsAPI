﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlantApi.Data;

#nullable disable

namespace PlantApi.Migrations
{
    [DbContext(typeof(PlantContext))]
    partial class PlantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlantApi.Models.GrowZone", b =>
                {
                    b.Property<long>("GrowZoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GrowZoneId"));

                    b.Property<string>("GrowZoneDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GrowZoneName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("GrowZoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("GrowZoneId");

                    b.ToTable("GrowZones");
                });

            modelBuilder.Entity("PlantApi.Models.PlantFact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Light")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScientificName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Water")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlantFacts");
                });

            modelBuilder.Entity("PlantApi.Models.PlantGrowZone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("GrowZoneId")
                        .HasColumnType("bigint");

                    b.Property<long>("PlantFactId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GrowZoneId");

                    b.HasIndex("PlantFactId");

                    b.ToTable("PlantGrowZones");
                });

            modelBuilder.Entity("PlantApi.Models.PlantGrowZone", b =>
                {
                    b.HasOne("PlantApi.Models.GrowZone", null)
                        .WithMany("PlantGrowZones")
                        .HasForeignKey("GrowZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlantApi.Models.PlantFact", null)
                        .WithMany("PlantGrowZones")
                        .HasForeignKey("PlantFactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlantApi.Models.GrowZone", b =>
                {
                    b.Navigation("PlantGrowZones");
                });

            modelBuilder.Entity("PlantApi.Models.PlantFact", b =>
                {
                    b.Navigation("PlantGrowZones");
                });
#pragma warning restore 612, 618
        }
    }
}
