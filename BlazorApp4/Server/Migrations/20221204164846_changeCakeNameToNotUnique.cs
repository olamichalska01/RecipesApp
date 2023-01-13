using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp4.Server.Migrations
{
    public partial class changeCakeNameToNotUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cakes_CakeName",
                table: "Cakes");

            migrationBuilder.AlterColumn<string>(
                name: "CakeName",
                table: "Cakes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CakeName",
                table: "Cakes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Cakes_CakeName",
                table: "Cakes",
                column: "CakeName",
                unique: true);
        }
    }
}
