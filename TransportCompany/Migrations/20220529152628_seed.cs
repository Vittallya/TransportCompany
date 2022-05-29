using Microsoft.EntityFrameworkCore.Migrations;

namespace TransportCompany.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(Properties.Resources.seed);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
