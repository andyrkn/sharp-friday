using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace L7.Persistance.Migrations
{
    public partial class fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProductPrice",
                table: "ShoppingCartProductPrice");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ShoppingCartProductPrice",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProductPrice",
                table: "ShoppingCartProductPrice",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProductPrice_ShoppingCartId",
                table: "ShoppingCartProductPrice",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCartProductPrice",
                table: "ShoppingCartProductPrice");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartProductPrice_ShoppingCartId",
                table: "ShoppingCartProductPrice");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ShoppingCartProductPrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCartProductPrice",
                table: "ShoppingCartProductPrice",
                columns: new[] { "ShoppingCartId", "Price" });
        }
    }
}
