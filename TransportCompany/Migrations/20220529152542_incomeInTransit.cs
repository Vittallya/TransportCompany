using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Migrations
{
    public partial class incomeInTransit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Income",
                table: "Transits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Outcome",
                table: "Transits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "Transits",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Gruzs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Income",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "Outcome",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Gruzs");
        }
    }
}
