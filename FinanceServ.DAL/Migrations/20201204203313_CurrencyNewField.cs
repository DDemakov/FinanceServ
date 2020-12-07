using Microsoft.EntityFrameworkCore.Migrations;

namespace FinanceServ.DAL.Migrations
{
    public partial class CurrencyNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Currencies",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Currencies");
        }
    }
}
