using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.EFCore.Infra.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<Guid>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 60, nullable: false),
                    ContactName = table.Column<string>(maxLength: 60, nullable: false),
                    ContactTitle = table.Column<string>(maxLength: 60, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Fax = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: true),
                    TitleOfCourtesy = table.Column<string>(maxLength: 60, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    HomePhone = table.Column<string>(maxLength: 15, nullable: true),
                    Extension = table.Column<string>(maxLength: 15, nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Notes = table.Column<string>(maxLength: 1000, nullable: true),
                    ReportsTo = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Hero",
                columns: table => new
                {
                    HeroID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Attribute = table.Column<string>(maxLength: 60, nullable: true),
                    Hit = table.Column<decimal>(nullable: false),
                    Mana = table.Column<decimal>(nullable: false),
                    Damage = table.Column<decimal>(nullable: false),
                    Armor = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    IsMelee = table.Column<bool>(nullable: false),
                    AghanimsEffect = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hero", x => x.HeroID);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Type = table.Column<string>(maxLength: 60, nullable: true),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    Cooldown = table.Column<decimal>(nullable: false),
                    IsChanneling = table.Column<bool>(nullable: false),
                    IsDisassemble = table.Column<bool>(nullable: false),
                    IsTargetable = table.Column<bool>(nullable: false),
                    UpgradeLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    RelationshipStatus = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Religion = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: false),
                    Barangay = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false),
                    Longtitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    SchoolID = table.Column<Guid>(nullable: false),
                    SchoolName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.SchoolID);
                });

            migrationBuilder.CreateTable(
                name: "Shipper",
                columns: table => new
                {
                    ShipperID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipper", x => x.ShipperID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    SupplierID = table.Column<Guid>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 60, nullable: false),
                    ContactName = table.Column<string>(maxLength: 60, nullable: false),
                    ContactTitle = table.Column<string>(maxLength: 60, nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false),
                    Region = table.Column<string>(maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 15, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: true),
                    Fax = table.Column<string>(maxLength: 15, nullable: true),
                    HomePage = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentID = table.Column<Guid>(nullable: false),
                    PersonID = table.Column<Guid>(nullable: false),
                    School = table.Column<string>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Student_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    EmployeeID = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    RequiredDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    ShipperID = table.Column<Guid>(nullable: false),
                    Freight = table.Column<decimal>(nullable: false),
                    ShipName = table.Column<string>(maxLength: 100, nullable: true),
                    ShipAddress = table.Column<string>(maxLength: 100, nullable: true),
                    ShipCity = table.Column<string>(maxLength: 100, nullable: true),
                    ShipRegion = table.Column<string>(maxLength: 100, nullable: true),
                    ShipPostalCode = table.Column<string>(maxLength: 15, nullable: true),
                    ShipCountry = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Shipper_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "Shipper",
                        principalColumn: "ShipperID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false),
                    SupplierID = table.Column<Guid>(nullable: false),
                    CategoryID = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    UnitsInStock = table.Column<decimal>(nullable: false),
                    UnitsOnOrder = table.Column<decimal>(nullable: false),
                    ReorderLevel = table.Column<decimal>(nullable: false),
                    Discontinued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailID = table.Column<Guid>(nullable: false),
                    OrderLineID = table.Column<int>(nullable: false),
                    OrderID = table.Column<Guid>(nullable: false),
                    ProductID = table.Column<Guid>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailID);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerID",
                table: "Order",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID",
                table: "Order",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShipperID",
                table: "Order",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierID",
                table: "Product",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_PersonID",
                table: "Student",
                column: "PersonID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hero");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Shipper");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
