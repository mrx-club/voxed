﻿// <auto-generated />
using System;
using Core.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Data.EF.Sqlite.Migrations
{
    [DbContext(typeof(VoxedContext))]
    [Migration("20210404003807_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13");

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("MediaID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.HasIndex("MediaID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Entities.Comment", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("Bump")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT")
                        .HasMaxLength(500)
                        .IsUnicode(true);

                    b.Property<long>("CreatedOn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("MediaID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<Guid>("VoxID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.HasIndex("Hash")
                        .IsUnique();

                    b.HasIndex("MediaID");

                    b.HasIndex("UserID");

                    b.HasIndex("VoxID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Core.Entities.Media", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("MediaType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ThumbnailUrl")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<string>("Url")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.ToTable("Media");
                });

            modelBuilder.Entity("Core.Entities.Poll", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("OptionADescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("OptionAVotes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OptionBDescription")
                        .HasColumnType("TEXT");

                    b.Property<int>("OptionBVotes")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("Polls");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("CreatedOn")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.Vox", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<long>("Bump")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER")
                        .IsUnicode(true);

                    b.Property<string>("Content")
                        .HasColumnType("TEXT")
                        .HasMaxLength(1000)
                        .IsUnicode(true);

                    b.Property<long>("CreatedOn")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Hash")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("MediaID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.Property<Guid?>("PollID")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.Property<Guid>("UserID")
                        .HasColumnType("TEXT")
                        .IsUnicode(true);

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("Hash")
                        .IsUnique();

                    b.HasIndex("MediaID");

                    b.HasIndex("PollID");

                    b.HasIndex("UserID");

                    b.ToTable("Voxs");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.HasOne("Core.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Comment", b =>
                {
                    b.HasOne("Core.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaID");

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Vox", null)
                        .WithMany("Comments")
                        .HasForeignKey("VoxID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Entities.Vox", b =>
                {
                    b.HasOne("Core.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Poll", "Poll")
                        .WithMany()
                        .HasForeignKey("PollID");

                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}