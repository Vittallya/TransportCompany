﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportCompany;

namespace TransportCompany.Migrations
{
    [DbContext(typeof(DbContextLocal))]
    partial class DbContextLocalModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Contragent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GenDirector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contragents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adres = "Пушкина, д. Кол",
                            Country = "Россия",
                            GenDirector = "Иванов",
                            Name = "Петр",
                            Phone = "8987957289",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverCategory")
                        .HasColumnType("int");

                    b.Property<bool>("IsDriverFree")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otchestvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Drivers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Ул. Леннина",
                            DriverCategory = 5,
                            IsDriverFree = true,
                            Name = "Валя",
                            Otchestvo = "Петрович",
                            Phone = "89984395879",
                            Surname = "Снегирев",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("Models.Gruz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("MaxTemp")
                        .HasColumnType("real");

                    b.Property<float>("MinTemp")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Size")
                        .HasColumnType("real");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Gruzs");
                });

            modelBuilder.Entity("Models.Reys", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("CountHours")
                        .HasColumnType("real");

                    b.Property<float>("CountKilometers")
                        .HasColumnType("real");

                    b.Property<int>("CountPoints")
                        .HasColumnType("int");

                    b.Property<int>("GruzId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("GruzId");

                    b.HasIndex("RouteId");

                    b.ToTable("Reys");
                });

            modelBuilder.Entity("Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("HoursCount")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Models.Transit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContragentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDriverGiven")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateGetGruz")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("datetime2");

                    b.Property<string>("DogorNum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<int>("GruzId")
                        .HasColumnType("int");

                    b.Property<decimal>("Income")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Outcome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Profit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ReciverAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciverFio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReciverPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<string>("SenderAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TranspId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContragentId");

                    b.HasIndex("DriverId");

                    b.HasIndex("GruzId");

                    b.HasIndex("RouteId");

                    b.HasIndex("TranspId");

                    b.ToTable("Transits");
                });

            modelBuilder.Entity("Models.Transp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Characteristics")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("bit");

                    b.Property<float?>("LoadCapasity")
                        .HasColumnType("real");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PayToDriver")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TransportPurpose")
                        .HasColumnType("int");

                    b.Property<int>("TransportSpecialPurpose")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Transps");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserGroup")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Login = "admin",
                            Name = "Админ",
                            Password = "admin",
                            UserGroup = 0
                        },
                        new
                        {
                            Id = 2,
                            Login = "driver",
                            Name = "Водитель",
                            Password = "driver",
                            UserGroup = 1
                        },
                        new
                        {
                            Id = 3,
                            Login = "agent",
                            Name = "Контрагент",
                            Password = "agent",
                            UserGroup = 2
                        });
                });

            modelBuilder.Entity("Models.Contragent", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Driver", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Models.Reys", b =>
                {
                    b.HasOne("Models.Gruz", "Gruz")
                        .WithMany()
                        .HasForeignKey("GruzId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gruz");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Models.Transit", b =>
                {
                    b.HasOne("Models.Contragent", "Contragent")
                        .WithMany()
                        .HasForeignKey("ContragentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Driver", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Gruz", "Gruz")
                        .WithMany()
                        .HasForeignKey("GruzId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Transp", "Transp")
                        .WithMany()
                        .HasForeignKey("TranspId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contragent");

                    b.Navigation("Driver");

                    b.Navigation("Gruz");

                    b.Navigation("Route");

                    b.Navigation("Transp");
                });
#pragma warning restore 612, 618
        }
    }
}
