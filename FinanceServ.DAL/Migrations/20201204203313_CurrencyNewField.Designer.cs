﻿// <auto-generated />
using System;
using FinanceServ.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FinanceServ.DAL.Migrations
{
    [DbContext(typeof(FinanceServContext))]
    [Migration("20201204203313_CurrencyNewField")]
    partial class CurrencyNewField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("FinanceServ.DAL.Entities.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("AlphabeticCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NumericCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.HasKey("Id");

                    b.HasAlternateKey("AlphabeticCode");

                    b.HasAlternateKey("NumericCode");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Portfolio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Stock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasMaxLength(1500)
                        .HasColumnType("character varying(1500)");

                    b.Property<int>("Foundation")
                        .HasColumnType("integer");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sector")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Ticker");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Transaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<long>("PortfolioId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<long>("Quantity")
                        .HasColumnType("bigint");

                    b.Property<long>("StockId")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("Added")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("Changed")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Portfolio", b =>
                {
                    b.HasOne("FinanceServ.DAL.Entities.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Transaction", b =>
                {
                    b.HasOne("FinanceServ.DAL.Entities.Currency", "Currency")
                        .WithMany("Transactions")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanceServ.DAL.Entities.Portfolio", "Portfolio")
                        .WithMany("Transactions")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinanceServ.DAL.Entities.Stock", "Stock")
                        .WithMany("Transactions")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinanceServ.DAL.Entities.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("Portfolio");

                    b.Navigation("Stock");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Currency", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Portfolio", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.Stock", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FinanceServ.DAL.Entities.User", b =>
                {
                    b.Navigation("Portfolios");

                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
