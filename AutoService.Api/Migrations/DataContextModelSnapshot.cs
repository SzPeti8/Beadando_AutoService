﻿// <auto-generated />
using System;
using AutoService.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoService.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("AutoService.Shared.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("AutoService.Shared.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DateOfMake")
                        .HasColumnType("TEXT");

                    b.Property<string>("FaultDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("FaultSeverity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegPlate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkStatus")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
