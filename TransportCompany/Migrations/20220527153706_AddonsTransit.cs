using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Migrations
{
    public partial class AddonsTransit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReciverFio",
                table: "Transits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReciverPhone",
                table: "Transits",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReciverFio",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "ReciverPhone",
                table: "Transits");
        }
    }
}
