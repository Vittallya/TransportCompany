using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Migrations
{
    public partial class dateGIvenDriver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateDriverGiven",
                table: "Transits",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateDriverGiven",
                table: "Transits");
        }
    }
}
