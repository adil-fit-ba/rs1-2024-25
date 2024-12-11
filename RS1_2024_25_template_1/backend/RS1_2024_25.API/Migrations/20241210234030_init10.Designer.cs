﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS1_2024_25.API.Data;

#nullable disable

namespace RS1_2024_25.API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241210234030_init10")]
    partial class init10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.AcademicYear", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Municipality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CityId");

                    b.HasIndex("RegionId");

                    b.ToTable("Municipalities");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Region", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CountryId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Tenant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DatabaseConnection")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAppUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FailedLoginAttempts")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDean")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LockoutUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("TenantId");

                    b.ToTable("MyAppUsers");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAuthenticationToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyAppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MyAppUserId");

                    b.HasIndex("TenantId");

                    b.ToTable("MyAuthenticationTokens");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("FacultyId");

                    b.HasIndex("TenantId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Faculty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("TenantId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Professor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Biography")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("Professors");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BirthCountryID")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("BirthMunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("BirthPlace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CitizenshipId")
                        .HasColumnType("int");

                    b.Property<string>("ContactMobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPrivateEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PermanentAddressStreet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PermanentMunicipalityId")
                        .HasColumnType("int");

                    b.Property<string>("StudentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("BirthCountryID");

                    b.HasIndex("BirthMunicipalityId");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("PermanentMunicipalityId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.City", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Municipality", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.SharedTables.Region", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAppUser", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAuthenticationToken", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAppUser", "MyAppUser")
                        .WithMany()
                        .HasForeignKey("MyAppUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MyAppUser");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Department", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Faculty", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Faculty");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Faculty", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Professor", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Student", b =>
                {
                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Country", "BirthCountry")
                        .WithMany()
                        .HasForeignKey("BirthCountryID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Municipality", "BirthMunicipality")
                        .WithMany()
                        .HasForeignKey("BirthMunicipalityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Country", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Municipality", "PermanentMunicipality")
                        .WithMany()
                        .HasForeignKey("PermanentMunicipalityId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("RS1_2024_25.API.Data.Models.SharedTables.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul1_Auth.MyAppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("BirthCountry");

                    b.Navigation("BirthMunicipality");

                    b.Navigation("Citizenship");

                    b.Navigation("PermanentMunicipality");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RS1_2024_25.API.Data.Models.TenantSpecificTables.Modul2_Basic.Faculty", b =>
                {
                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
