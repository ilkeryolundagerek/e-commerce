using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    UID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Galery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MediaLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    GaleryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaLibrary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaLibrary_Galery_GaleryId",
                        column: x => x.GaleryId,
                        principalTable: "Galery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    SubCategoryId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    CampaingPrice = table.Column<decimal>(nullable: false),
                    IsInCampaign = table.Column<bool>(nullable: false),
                    FeaturedImage = table.Column<string>(nullable: true),
                    GaleryId = table.Column<int>(nullable: false),
                    IsInStock = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Galery_GaleryId",
                        column: x => x.GaleryId,
                        principalTable: "Galery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaLibrary_GaleryId",
                table: "MediaLibrary",
                column: "GaleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GaleryId",
                table: "Product",
                column: "GaleryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_CategoryId",
                table: "SubCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "MediaLibrary");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Galery");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
