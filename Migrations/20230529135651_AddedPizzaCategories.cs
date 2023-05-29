using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    /// <inheritdoc />
    public partial class AddedPizzaCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaCategoryId",
                table: "Pizzas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PizzaCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaCategoryId",
                table: "Pizzas",
                column: "PizzaCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaCategories_PizzaCategoryId",
                table: "Pizzas",
                column: "PizzaCategoryId",
                principalTable: "PizzaCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaCategories_PizzaCategoryId",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "PizzaCategories");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaCategoryId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaCategoryId",
                table: "Pizzas");
        }
    }
}
