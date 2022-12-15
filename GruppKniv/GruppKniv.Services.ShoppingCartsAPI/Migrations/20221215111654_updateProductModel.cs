using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GruppKniv.Services.ShoppingCartsAPI.Migrations
{
    public partial class updateProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Ingridients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ingridients",
                table: "Products",
                newName: "Description");
        }
    }
}
