using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class LowerCaseTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_User_CustomerID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Product_ProductID",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admin",
                table: "Admin");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "orderitem");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "category");

            migrationBuilder.RenameTable(
                name: "Admin",
                newName: "admin");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "product",
                newName: "IX_product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_ProductID",
                table: "orderitem",
                newName: "IX_orderitem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderID",
                table: "orderitem",
                newName: "IX_orderitem_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerID",
                table: "order",
                newName: "IX_order_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderitem",
                table: "orderitem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order",
                table: "order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_category",
                table: "category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_admin",
                table: "admin",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_order_user_CustomerID",
                table: "order",
                column: "CustomerID",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderitem_order_OrderID",
                table: "orderitem",
                column: "OrderID",
                principalTable: "order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orderitem_product_ProductID",
                table: "orderitem",
                column: "ProductID",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product",
                column: "CategoryId",
                principalTable: "category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_user_CustomerID",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_orderitem_order_OrderID",
                table: "orderitem");

            migrationBuilder.DropForeignKey(
                name: "FK_orderitem_product_ProductID",
                table: "orderitem");

            migrationBuilder.DropForeignKey(
                name: "FK_product_category_CategoryId",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderitem",
                table: "orderitem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order",
                table: "order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_category",
                table: "category");

            migrationBuilder.DropPrimaryKey(
                name: "PK_admin",
                table: "admin");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "orderitem",
                newName: "OrderItem");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "category",
                newName: "Category");

            migrationBuilder.RenameTable(
                name: "admin",
                newName: "Admin");

            migrationBuilder.RenameIndex(
                name: "IX_product_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_orderitem_ProductID",
                table: "OrderItem",
                newName: "IX_OrderItem_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_orderitem_OrderID",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_order_CustomerID",
                table: "Order",
                newName: "IX_Order_CustomerID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admin",
                table: "Admin",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_User_CustomerID",
                table: "Order",
                column: "CustomerID",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Product_ProductID",
                table: "OrderItem",
                column: "ProductID",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
