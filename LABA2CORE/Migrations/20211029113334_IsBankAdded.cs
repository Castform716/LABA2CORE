using Microsoft.EntityFrameworkCore.Migrations;

namespace LABA2CORE.Migrations
{
    public partial class IsBankAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBank",
                table: "InsuranceGiver",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBank",
                table: "InsuranceGiver");
        }
    }
}
