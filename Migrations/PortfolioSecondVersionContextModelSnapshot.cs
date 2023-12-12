﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PortfolioSecondVersion.Data;

#nullable disable

namespace PortfolioSecondVersion.Migrations
{
    [DbContext(typeof(PortfolioSecondVersionContext))]
    partial class PortfolioSecondVersionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PortfolioSecondVersion.Models.Image", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortfolioId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.LanguagePortfolio", b =>
                {
                    b.Property<Guid>("PortfolioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PortfolioId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("LanguagesPortfolios");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Surname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.Image", b =>
                {
                    b.HasOne("PortfolioSecondVersion.Models.Portfolio", "Portfolio")
                        .WithMany("Photo")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.LanguagePortfolio", b =>
                {
                    b.HasOne("PortfolioSecondVersion.Models.Language", "Language")
                        .WithMany("LanguagePortfolio")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PortfolioSecondVersion.Models.Portfolio", "Portfolio")
                        .WithMany("LanguagePortfolio")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.Language", b =>
                {
                    b.Navigation("LanguagePortfolio");
                });

            modelBuilder.Entity("PortfolioSecondVersion.Models.Portfolio", b =>
                {
                    b.Navigation("LanguagePortfolio");

                    b.Navigation("Photo");
                });
#pragma warning restore 612, 618
        }
    }
}
