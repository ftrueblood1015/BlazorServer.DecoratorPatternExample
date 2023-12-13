﻿// <auto-generated />
using System;
using BlazorServer.DecoratorPatternExample.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorServer.DecoratorPatternExample.Migrations
{
    [DbContext(typeof(DecoratorPatternContext))]
    partial class DecoratorPatternContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.25");

            modelBuilder.Entity("BlazorServer.DecoratorPatternExample.Domain.Models.Anniversary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Anniversaries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "My Anniversay",
                            Date = new DateTime(2015, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "My Anniversay",
                            IsActive = true,
                            Name = "My Anniversay"
                        },
                        new
                        {
                            Id = 2,
                            Comments = "Not My Anniversay",
                            Date = new DateTime(2014, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Not My Anniversay",
                            IsActive = true,
                            Name = "Not My Anniversay"
                        });
                });

            modelBuilder.Entity("BlazorServer.DecoratorPatternExample.Domain.Models.Birthday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Birthdays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "My Bday",
                            Date = new DateTime(2000, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Fletcher Bday",
                            IsActive = true,
                            Name = "Fletcher Bday"
                        },
                        new
                        {
                            Id = 2,
                            Comments = "Not My Bday",
                            Date = new DateTime(1981, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Not My Bday",
                            IsActive = true,
                            Name = "Not My Bday"
                        });
                });

            modelBuilder.Entity("BlazorServer.DecoratorPatternExample.Domain.Models.EventLogger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActionDateTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("RequestData")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Service")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("BlazorServer.DecoratorPatternExample.Domain.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Holidays");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Comments = "Its Christmas",
                            Date = new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Christmas",
                            IsActive = true,
                            Name = "Christmas"
                        },
                        new
                        {
                            Id = 2,
                            Comments = "Its New Years Eve",
                            Date = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "New Years Eve",
                            IsActive = true,
                            Name = "New Years Eve"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}