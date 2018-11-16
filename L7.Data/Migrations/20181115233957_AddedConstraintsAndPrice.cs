using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace L7.Persistance.Migrations
{
    public partial class AddedConstraintsAndPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Price_Value");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShoppingCarts",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCartProductPrice",
                columns: table => new
                {
                    Price = table.Column<decimal>(nullable: false),
                    ShoppingCartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProductPrice", x => new { x.ShoppingCartId, x.Price });
                    table.ForeignKey(
                        name: "FK_ShoppingCartProductPrice_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartProductPrice");

            migrationBuilder.RenameColumn(
                name: "Price_Value",
                table: "Products",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ShoppingCarts",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
