using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class _migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false),
                    category_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    role_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.role_id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "int", nullable: false),
                    item_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    item_description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    warehouse_quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.item_id);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Specs",
                columns: table => new
                {
                    spec_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    spec_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs", x => x.spec_id);
                    table.ForeignKey(
                        name: "FK_Specs_Categories",
                        column: x => x.category_id,
                        principalTable: "Categories",
                        principalColumn: "category_id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    role_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.role_id,
                        principalTable: "Roles",
                        principalColumn: "role_id");
                });

            migrationBuilder.CreateTable(
                name: "Orders_item",
                columns: table => new
                {
                    order_item_id = table.Column<int>(type: "int", nullable: false),
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_item", x => x.order_item_id);
                    table.ForeignKey(
                        name: "FK_ItemsOrders_item",
                        column: x => x.item_id,
                        principalTable: "Products",
                        principalColumn: "item_id");
                });

            migrationBuilder.CreateTable(
                name: "Specs_item",
                columns: table => new
                {
                    spec_item_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    spec_id = table.Column<int>(type: "int", nullable: false),
                    spec_value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specs_item", x => x.spec_item_id);
                    table.ForeignKey(
                        name: "FK_ItemsSpecs_item",
                        column: x => x.item_id,
                        principalTable: "Products",
                        principalColumn: "item_id");
                    table.ForeignKey(
                        name: "FK_SpecsSpecs_item",
                        column: x => x.spec_id,
                        principalTable: "Specs",
                        principalColumn: "spec_id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    carts_id = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.carts_id);
                    table.ForeignKey(
                        name: "FK_ItemsCarts",
                        column: x => x.item_id,
                        principalTable: "Products",
                        principalColumn: "item_id");
                    table.ForeignKey(
                        name: "FK_UserCarts",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    delivery_id = table.Column<int>(type: "int", nullable: false),
                    status_id = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "date", nullable: false),
                    is_deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_UsersOrders",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_id_user",
                table: "Carts",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_item_id",
                table: "Carts",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_id_user",
                table: "Orders",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_item_item_id",
                table: "Orders_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_category_id",
                table: "Products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_category_id",
                table: "Specs",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_item_item_id",
                table: "Specs_item",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Specs_item_spec_id",
                table: "Specs_item",
                column: "spec_id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_role_id",
                table: "Users",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Orders_item");

            migrationBuilder.DropTable(
                name: "Specs_item");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Specs");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
