using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class InitMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "DialShape",
                columns: table => new
                {
                    DialShapeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DialShapeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialShape", x => x.DialShapeID);
                });

            migrationBuilder.CreateTable(
                name: "DialSize",
                columns: table => new
                {
                    DialSizeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DialSizeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DialSize", x => x.DialSizeID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Original",
                columns: table => new
                {
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Original", x => x.OriginalID);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermissionDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StatusActive",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusActive", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "StatusInvoice",
                columns: table => new
                {
                    StatusInvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusInvoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusInvoice", x => x.StatusInvoiceID);
                });

            migrationBuilder.CreateTable(
                name: "StrapMaterial",
                columns: table => new
                {
                    StrapMaterialID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrapMaterialName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrapMaterial", x => x.StrapMaterialID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "VoucherStatus",
                columns: table => new
                {
                    VoucherStatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoucherStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherStatus", x => x.VoucherStatusID);
                });

            migrationBuilder.CreateTable(
                name: "WaterResistance",
                columns: table => new
                {
                    WaterResistanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterResistanceName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterResistance", x => x.WaterResistanceID);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OriginalID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                    table.ForeignKey(
                        name: "FK_Brand_Original_OriginalID",
                        column: x => x.OriginalID,
                        principalTable: "Original",
                        principalColumn: "OriginalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleToPermission",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToPermission", x => new { x.RoleID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_RoleToPermission_Permission_PermissionID",
                        column: x => x.PermissionID,
                        principalTable: "Permission",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleToPermission_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_StatusActive_StatusID",
                        column: x => x.StatusID,
                        principalTable: "StatusActive",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    TotalCart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalProduct = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusInvoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_StatusInvoice_StatusInvoiceID",
                        column: x => x.StatusInvoiceID,
                        principalTable: "StatusInvoice",
                        principalColumn: "StatusInvoiceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToRole",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRole", x => new { x.RoleID, x.UserID });
                    table.ForeignKey(
                        name: "FK_UserToRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    VoucherCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discount = table.Column<float>(type: "real", nullable: false),
                    CreatedByUserID = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VoucherStatusID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.VoucherCode);
                    table.ForeignKey(
                        name: "FK_Voucher_User_CreatedByUserID",
                        column: x => x.CreatedByUserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voucher_VoucherStatus_VoucherStatusID",
                        column: x => x.VoucherStatusID,
                        principalTable: "VoucherStatus",
                        principalColumn: "VoucherStatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetail",
                columns: table => new
                {
                    InvoiceDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetail", x => x.InvoiceDetailID);
                    table.ForeignKey(
                        name: "FK_InvoiceDetail_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<int>(type: "int", nullable: false),
                    TotalRating = table.Column<double>(type: "float", nullable: false),
                    BrandID = table.Column<int>(type: "int", nullable: false),
                    DialSizeID = table.Column<int>(type: "int", nullable: false),
                    StrapMaterialID = table.Column<int>(type: "int", nullable: false),
                    TagID = table.Column<int>(type: "int", nullable: false),
                    WaterResistanceID = table.Column<int>(type: "int", nullable: false),
                    GenderID = table.Column<int>(type: "int", nullable: false),
                    DialShapeID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDetailID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "BrandID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_DialShape_DialShapeID",
                        column: x => x.DialShapeID,
                        principalTable: "DialShape",
                        principalColumn: "DialShapeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_DialSize_DialSizeID",
                        column: x => x.DialSizeID,
                        principalTable: "DialSize",
                        principalColumn: "DialSizeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_InvoiceDetail_InvoiceDetailID",
                        column: x => x.InvoiceDetailID,
                        principalTable: "InvoiceDetail",
                        principalColumn: "InvoiceDetailID");
                    table.ForeignKey(
                        name: "FK_Product_StrapMaterial_StrapMaterialID",
                        column: x => x.StrapMaterialID,
                        principalTable: "StrapMaterial",
                        principalColumn: "StrapMaterialID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Tag_TagID",
                        column: x => x.TagID,
                        principalTable: "Tag",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_WaterResistance_WaterResistanceID",
                        column: x => x.WaterResistanceID,
                        principalTable: "WaterResistance",
                        principalColumn: "WaterResistanceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    CartDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetail", x => x.CartDetailID);
                    table.ForeignKey(
                        name: "FK_CartDetail_Cart_CartID",
                        column: x => x.CartID,
                        principalTable: "Cart",
                        principalColumn: "CartID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    CommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comment_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comment_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Brand_OriginalID",
                table: "Brand",
                column: "OriginalID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CustomerID",
                table: "Cart",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserID",
                table: "Cart",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_CartID",
                table: "CartDetail",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductID",
                table: "CartDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_CustomerID",
                table: "Comment",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ProductID",
                table: "Comment",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerID",
                table: "Invoice",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_StatusInvoiceID",
                table: "Invoice",
                column: "StatusInvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_UserID",
                table: "Invoice",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetail_InvoiceID",
                table: "InvoiceDetail",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DialShapeID",
                table: "Product",
                column: "DialShapeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_DialSizeID",
                table: "Product",
                column: "DialSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GenderID",
                table: "Product",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_InvoiceDetailID",
                table: "Product",
                column: "InvoiceDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_StrapMaterialID",
                table: "Product",
                column: "StrapMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TagID",
                table: "Product",
                column: "TagID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_WaterResistanceID",
                table: "Product",
                column: "WaterResistanceID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermission_PermissionID",
                table: "RoleToPermission",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_User_StatusID",
                table: "User",
                column: "StatusID");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRole_UserID",
                table: "UserToRole",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_CreatedByUserID",
                table: "Voucher",
                column: "CreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_VoucherStatusID",
                table: "Voucher",
                column: "VoucherStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "RoleToPermission");

            migrationBuilder.DropTable(
                name: "UserToRole");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "VoucherStatus");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "DialShape");

            migrationBuilder.DropTable(
                name: "DialSize");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "InvoiceDetail");

            migrationBuilder.DropTable(
                name: "StrapMaterial");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "WaterResistance");

            migrationBuilder.DropTable(
                name: "Original");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "StatusInvoice");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "StatusActive");
        }
    }
}
