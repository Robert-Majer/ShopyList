using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopyList.DataAccess.Migrations
{
    public partial class AddNumberOfProductsToShoppingList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfProducts",
                table: "ShoppingLists",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfProducts",
                table: "ShoppingLists");
        }
    }
}