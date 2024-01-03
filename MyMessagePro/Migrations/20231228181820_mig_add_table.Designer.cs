﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyMessagePro.DAL.Context;

#nullable disable

namespace MyMessagePro.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231228181820_mig_add_table")]
    partial class mig_add_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MyMessagePro.DAL.Entities.Admin", b =>
                {
                    b.Property<int>("adminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminID"), 1L, 1);

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("adminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("MyMessagePro.DAL.Entities.Friendship", b =>
                {
                    b.Property<int>("friendshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("friendshipID"), 1L, 1);

                    b.Property<string>("friendDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("friendReceiverMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("friendSenderMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("friendshipID");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("MyMessagePro.DAL.Entities.UMessage", b =>
                {
                    b.Property<int>("messageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("messageID"), 1L, 1);

                    b.Property<string>("content")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("draft")
                        .HasColumnType("bit");

                    b.Property<string>("receiverMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("senderMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("messageID");

                    b.ToTable("UMessages");
                });

            modelBuilder.Entity("MyMessagePro.DAL.Entities.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
