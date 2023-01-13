using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp4.Server.Migrations
{
    public partial class changeInUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Ingerdients_IngredientName_Amount",
                table: "Ingerdients");

            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "Ingerdients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IngredientName",
                table: "Ingerdients",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Ingerdients_IngredientName_Amount",
                table: "Ingerdients",
                columns: new[] { "IngredientName", "Amount" },
                unique: true);
        }
    }
}
