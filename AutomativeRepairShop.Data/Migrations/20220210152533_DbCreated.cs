using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomativeRepairShop.Data.Migrations
{
    public partial class DbCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isApproved = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreateDate", "DeleteDate", "Email", "Name", "PhoneNumber", "Surname", "UpdateDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1236), null, "mulayimsert@gmail.com", "Mülayim", "12345", "Sert", null },
                    { 2, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1243), null, "keanureeves@gmail.com", "Keanu", "12345", "Reeves", null },
                    { 3, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1244), null, "donaldtrump@gmail.com", "Donald", "12345", "Trump", null },
                    { 4, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1246), null, "testerenecmi@gmail.com", "Testere", "12345", "Necmi", null },
                    { 5, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(1247), null, "bugsbunny@gmail.com", "Bugs", "12345", "Bunny", null }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Brand", "CreateDate", "CustomerId", "DeleteDate", "LicensePlate", "Model", "UpdateDate", "Year" },
                values: new object[,]
                {
                    { 1, "Audi", new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4310), 1, null, "34 ABC 123", "A3 Sedan", null, 2020 },
                    { 2, "Fiat", new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4318), 2, null, "34 DSA 123", "Egea", null, 2018 },
                    { 3, "Honda", new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4320), 2, null, "34 FSD 123", "City", null, 2017 },
                    { 4, "Mercedes", new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(4322), 3, null, "34 HDS 123", "A Serisi", null, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreateDate", "CustomerId", "DeleteDate", "UpdateDate", "VehicleId", "isApproved" },
                values: new object[] { 1, new DateTime(2022, 2, 10, 18, 25, 33, 622, DateTimeKind.Local).AddTicks(4833), new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(704), 1, null, null, 1, false });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreateDate", "CustomerId", "DeleteDate", "UpdateDate", "VehicleId", "isApproved" },
                values: new object[] { 2, null, new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1069), 2, null, null, 2, true });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "AppointmentDate", "CreateDate", "CustomerId", "DeleteDate", "UpdateDate", "VehicleId", "isApproved" },
                values: new object[] { 3, new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1073), new DateTime(2022, 2, 10, 18, 25, 33, 623, DateTimeKind.Local).AddTicks(1075), 2, null, null, 3, true });

            migrationBuilder.InsertData(
                table: "WorkOrders",
                columns: new[] { "Id", "AppointmentId", "CreateDate", "DeleteDate", "UpdateDate" },
                values: new object[] { 1, 2, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(6121), null, null });

            migrationBuilder.InsertData(
                table: "WorkOrders",
                columns: new[] { "Id", "AppointmentId", "CreateDate", "DeleteDate", "UpdateDate" },
                values: new object[] { 2, 3, new DateTime(2022, 2, 10, 18, 25, 33, 624, DateTimeKind.Local).AddTicks(6128), null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CustomerId",
                table: "Appointments",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_VehicleId",
                table: "Appointments",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CustomerId",
                table: "Vehicles",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AppointmentId",
                table: "WorkOrders",
                column: "AppointmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
