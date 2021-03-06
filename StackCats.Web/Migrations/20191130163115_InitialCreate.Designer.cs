﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StackCats.Web.Context;

namespace StackCats.Web.Migrations
{
    [DbContext(typeof(ReleaseNotificationRequestContext))]
    [Migration("20191130163115_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("StackCats.Web.Context.ReleaseNotificationRequest", b =>
                {
                    b.Property<int>("ReleaseNotificationRequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RequesterEmail")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ReleaseNotificationRequestId");

                    b.ToTable("ReleaseNotificationRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
