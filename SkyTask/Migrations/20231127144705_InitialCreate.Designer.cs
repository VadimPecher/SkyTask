﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkyTask.Models;

#nullable disable

namespace SkyTask.Migrations
{
    [DbContext(typeof(SkyDbContext))]
    [Migration("20231127144705_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("SkyTask.Models.Tenant", b =>
                {
                    b.Property<Guid>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantCountry")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TenantId");

                    b.ToTable("Tenants");
                });
#pragma warning restore 612, 618
        }
    }
}
