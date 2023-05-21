using Microsoft.EntityFrameworkCore.Migrations;

namespace BAI_1_1_EFCORE_CODEFIRST.Migrations
{
    public partial class tuanv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "tuanpa",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tuanpa",
                table: "Accounts");
        }
    }
}
