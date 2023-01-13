using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp4.Server.Migrations
{
    public partial class AddUnitOfMeasureAndIngredientTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitOfMeasureName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsOfMeasure", x => x.UnitOfMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "Ingerdients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingerdients", x => x.IngredientId);
                    table.ForeignKey(
                        name: "FK_Ingerdients_UnitsOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingerdients_IngredientName_Amount",
                table: "Ingerdients",
                columns: new[] { "IngredientName", "Amount" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingerdients_UnitOfMeasureId",
                table: "Ingerdients",
                column: "UnitOfMeasureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingerdients");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");
        }
    }
}
