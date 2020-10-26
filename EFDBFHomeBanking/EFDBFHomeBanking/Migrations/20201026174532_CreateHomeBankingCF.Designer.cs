﻿// <auto-generated />
using System;
using EFDBFHomeBanking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDBFHomeBanking.Migrations
{
    [DbContext(typeof(HomeBankingContext))]
    [Migration("20201026174532_CreateHomeBankingCF")]
    partial class CreateHomeBankingCF
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDBFHomeBanking.Models.Account", b =>
                {
                    b.Property<string>("accountId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("balance")
                        .HasColumnType("real");

                    b.Property<int?>("clientId")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("accountId");

                    b.HasIndex("clientId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("EFDBFHomeBanking.Models.Bank", b =>
                {
                    b.Property<int>("bankId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("bankId");

                    b.ToTable("banks");
                });

            modelBuilder.Entity("EFDBFHomeBanking.Models.Client", b =>
                {
                    b.Property<int>("clientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("bankId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nroDoc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("clientId");

                    b.HasIndex("bankId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EFDBFHomeBanking.Models.Account", b =>
                {
                    b.HasOne("EFDBFHomeBanking.Models.Client", null)
                        .WithMany("accounts")
                        .HasForeignKey("clientId");
                });

            modelBuilder.Entity("EFDBFHomeBanking.Models.Client", b =>
                {
                    b.HasOne("EFDBFHomeBanking.Models.Bank", null)
                        .WithMany("clients")
                        .HasForeignKey("bankId");
                });
#pragma warning restore 612, 618
        }
    }
}