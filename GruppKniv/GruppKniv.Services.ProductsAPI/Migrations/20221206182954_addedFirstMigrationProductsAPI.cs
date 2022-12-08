using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GruppKniv.Services.ProductsAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedFirstMigrationProductsAPI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingridients = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ImageUrl", "Ingridients", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://gruppkniv.blob.core.windows.net/gruppkniv/pizza-vesuvio.jpeg", "Ost, Skinka, Tomatsås Gluten", "Vesuvio", 85.0 },
                    { 2, "https://gruppkniv.blob.core.windows.net/gruppkniv/stellas-kebabpizza.png.jpg", "Ost, Kebab, Tomat, Färsk Sallad, Kebabsås, Gluten", "Kebab Pizza", 100.0 },
                    { 3, "https://gruppkniv.blob.core.windows.net/gruppkniv/calzone.jpg", "Ost, Skinka, Tomatsås, Gluten", "Calzone", 95.0 },
                    { 4, "https://gruppkniv.blob.core.windows.net/gruppkniv/hawaiian-pizza-recipe-605894-2.jpg", "Ost, Skinka, Ananas,Tomatsås, Gluten", "Hawaii", 85.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
