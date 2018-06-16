﻿// <auto-generated />
using System;
using Hackathon.Garbage.Dal.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hackathon.Garbage.Dal.Migrations
{
    [DbContext(typeof(FloraDbContext))]
    partial class FloraDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.AlertsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Message");

                    b.Property<DateTime?>("StartDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Alerts");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.CordinatesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FieldId");

                    b.Property<decimal>("lat")
                        .HasColumnName("Latitude")
                        .HasColumnType("decimal(18,8)");

                    b.Property<decimal>("lng")
                        .HasColumnName("Longitude ")
                        .HasColumnType("decimal(18,8)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Cordinates");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.ExecutiveEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Executives");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.FieldEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeadlineDate");

                    b.Property<int>("ExecutiveId");

                    b.Property<int>("FieldId");

                    b.Property<DateTime?>("FinishDate");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ExecutiveId");

                    b.HasIndex("FieldId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.PhotoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId");

                    b.Property<string>("Path");

                    b.Property<int?>("RatingId");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("RatingId");

                    b.ToTable("PhotoEntity");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.ProblemNotificationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("UrlImage");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("ProblemNotification");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.RatingEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment");

                    b.Property<int>("FieldId");

                    b.Property<int>("Score");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.CordinatesEntity", b =>
                {
                    b.HasOne("Hackathon.Garbage.Dal.Entities.FieldEntity", "Field")
                        .WithMany("Cordinates")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.OrderEntity", b =>
                {
                    b.HasOne("Hackathon.Garbage.Dal.Entities.ExecutiveEntity", "Executive")
                        .WithMany("Orders")
                        .HasForeignKey("ExecutiveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hackathon.Garbage.Dal.Entities.FieldEntity", "Field")
                        .WithMany("Orders")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.PhotoEntity", b =>
                {
                    b.HasOne("Hackathon.Garbage.Dal.Entities.OrderEntity", "Order")
                        .WithMany("Photos")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hackathon.Garbage.Dal.Entities.RatingEntity", "Rating")
                        .WithMany("Photos")
                        .HasForeignKey("RatingId");
                });

            modelBuilder.Entity("Hackathon.Garbage.Dal.Entities.RatingEntity", b =>
                {
                    b.HasOne("Hackathon.Garbage.Dal.Entities.FieldEntity", "Field")
                        .WithMany("Ratings")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
