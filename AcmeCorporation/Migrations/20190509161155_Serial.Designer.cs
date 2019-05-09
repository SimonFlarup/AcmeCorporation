﻿// <auto-generated />
using System;
using AcmeCorporation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AcmeCorporation.Migrations
{
    [DbContext(typeof(AcmeCorporationContext))]
    [Migration("20190509161155_Serial")]
    partial class Serial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Acme.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("AcmeCorporation.Models.DrawEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.HasKey("ID");

                    b.ToTable("DrawEntry");
                });

            modelBuilder.Entity("AcmeCorporation.Models.Serial", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(14);

                    b.HasKey("ID");

                    b.ToTable("Serial");
                });
#pragma warning restore 612, 618
        }
    }
}