using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gruzs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    MinTemp = table.Column<float>(type: "real", nullable: false),
                    MaxTemp = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gruzs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Length = table.Column<float>(type: "real", nullable: false),
                    HoursCount = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoadCapasity = table.Column<float>(type: "real", nullable: true),
                    Characteristics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransportPurpose = table.Column<int>(type: "int", nullable: false),
                    IsSpecial = table.Column<bool>(type: "bit", nullable: false),
                    TransportSpecialPurpose = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayToDriver = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserGroup = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountKilometers = table.Column<float>(type: "real", nullable: false),
                    CountHours = table.Column<float>(type: "real", nullable: false),
                    CountPoints = table.Column<int>(type: "int", nullable: false),
                    GruzId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reys_Gruzs_GruzId",
                        column: x => x.GruzId,
                        principalTable: "Gruzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reys_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contragents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenDirector = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contragents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contragents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Otchestvo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverCategory = table.Column<int>(type: "int", nullable: false),
                    IsDriverFree = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogorNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSend = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SenderAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReciverAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateGetGruz = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ContragentId = table.Column<int>(type: "int", nullable: false),
                    TranspId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    GruzId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transits_Contragents_ContragentId",
                        column: x => x.ContragentId,
                        principalTable: "Contragents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transits_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transits_Gruzs_GruzId",
                        column: x => x.GruzId,
                        principalTable: "Gruzs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transits_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transits_Transps_TranspId",
                        column: x => x.TranspId,
                        principalTable: "Transps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "UserGroup" },
                values: new object[] { 1, "admin", "Админ", "admin", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "UserGroup" },
                values: new object[] { 2, "driver", "Водитель", "driver", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "UserGroup" },
                values: new object[] { 3, "agent", "Контрагент", "agent", 2 });

            migrationBuilder.InsertData(
                table: "Contragents",
                columns: new[] { "Id", "Adres", "Country", "GenDirector", "Name", "Phone", "UserId" },
                values: new object[] { 1, "Пушкина, д. Кол", "Россия", "Иванов", "Петр", "8987957289", 3 });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Address", "DriverCategory", "IsDriverFree", "Name", "Otchestvo", "Phone", "Surname", "UserId" },
                values: new object[] { 1, "Ул. Леннина", 5, true, "Валя", "Петрович", "89984395879", "Снегирев", 2 });


            migrationBuilder.CreateIndex(
                name: "IX_Contragents_UserId",
                table: "Contragents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reys_GruzId",
                table: "Reys",
                column: "GruzId");

            migrationBuilder.CreateIndex(
                name: "IX_Reys_RouteId",
                table: "Reys",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_ContragentId",
                table: "Transits",
                column: "ContragentId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_DriverId",
                table: "Transits",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_GruzId",
                table: "Transits",
                column: "GruzId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_RouteId",
                table: "Transits",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_TranspId",
                table: "Transits",
                column: "TranspId");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reys");

            migrationBuilder.DropTable(
                name: "Transits");

            migrationBuilder.DropTable(
                name: "Contragents");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Gruzs");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Transps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
