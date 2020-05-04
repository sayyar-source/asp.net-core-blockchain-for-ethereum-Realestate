﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RealEstate.DataLayer.Context;

namespace RealEstate.DataLayer.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20200127124705_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("RealEstate.Domain.Admin.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RealEstate.Domain.Admin.Neighborhood", b =>
                {
                    b.Property<int>("NeighborhoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NeighborhoodName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NeighborhoodId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("RealEstate.Domain.Admin.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.EstateContract", b =>
                {
                    b.Property<int>("EstateContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("BuyerOK")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("BuyerOKTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("BuyerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<int?>("EstatesId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OwnerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaveTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("SellerOK")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SellerOKTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("SellerUserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstateContractId");

                    b.HasIndex("EstatesId");

                    b.ToTable("EstateContracts");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.EstateImage", b =>
                {
                    b.Property<int>("EstateImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EstateImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstateImageId");

                    b.ToTable("EstateImages");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.EstateStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("EstateStatusName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("EstateStatuses");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.Estates", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Baths")
                        .HasColumnType("int");

                    b.Property<int>("Beds")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<string>("EstateLogo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstateStatusId")
                        .HasColumnType("int");

                    b.Property<int>("Garages")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstateStatusId");

                    b.ToTable("Estates");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.RequestEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Enable")
                        .HasColumnType("bit");

                    b.Property<int>("EstateId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SaveUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EstateId");

                    b.HasIndex("SaveUserId");

                    b.ToTable("RequestEstate");
                });

            modelBuilder.Entity("RealEstate.Domain.User.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("EthAccountAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RealEstate.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RealEstate.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RealEstate.Domain.User.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.Domain.Admin.City", b =>
                {
                    b.HasOne("RealEstate.Domain.Admin.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.EstateContract", b =>
                {
                    b.HasOne("RealEstate.Domain.Estate.Estates", "Estates")
                        .WithMany()
                        .HasForeignKey("EstatesId");
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.Estates", b =>
                {
                    b.HasOne("RealEstate.Domain.Estate.EstateStatus", "EstateStatus")
                        .WithMany("Estates")
                        .HasForeignKey("EstateStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RealEstate.Domain.Estate.RequestEstate", b =>
                {
                    b.HasOne("RealEstate.Domain.Estate.Estates", "Estate")
                        .WithMany("RequestEstates")
                        .HasForeignKey("EstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RealEstate.Domain.User.ApplicationUser", "ApplicationUser")
                        .WithMany("RequestEstates")
                        .HasForeignKey("SaveUserId");
                });
#pragma warning restore 612, 618
        }
    }
}
