using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazingPizza.EFCore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class AddToppings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Queso extra", 47.50m },
                    { 2, "Tocino de pavo", 56.80m },
                    { 3, "Tocino de jabalí", 56.80m },
                    { 4, "Tocino de ternera", 56.80m },
                    { 5, "Té y bollos", 95.00m },
                    { 6, "Bollos recién horneados", 85.50m },
                    { 7, "Pimiento", 19.00m },
                    { 8, "Cebolla", 19.00m },
                    { 9, "Champiñones", 19.00m },
                    { 10, "Pepperoni", 19.00m },
                    { 11, "Salchicha de pato", 60.80m },
                    { 12, "Albóndigas de venado", 47.50m },
                    { 13, "Cubierta de langosta", 1225.50m },
                    { 14, "Caviar de esturión", 1933.25m },
                    { 15, "Corazones de alcachofa", 64.60m },
                    { 16, "Tomates frescos", 39.00m },
                    { 17, "Albahaca", 39.00m },
                    { 18, "Filete", 161.50m },
                    { 19, "Pimientos picantes", 79.80m },
                    { 20, "Pollo búfalo", 95.00m },
                    { 21, "Queso azul", 47.50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
