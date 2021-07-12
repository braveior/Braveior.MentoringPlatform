using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Braveior.MentoringPlatform.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Institutions",
                columns: table => new
                {
                    InstitutionId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutions", x => x.InstitutionId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Kanboards",
                columns: table => new
                {
                    KanboardId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kanboards", x => x.KanboardId);
                    table.ForeignKey(
                        name: "FK_Kanboards_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionId = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Institutions_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Institutions",
                        principalColumn: "InstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoryPoint = table.Column<int>(type: "int", nullable: false),
                    Attachment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstimatedDays = table.Column<int>(type: "int", nullable: false),
                    ActualDays = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    KanboardId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Kanboards_KanboardId",
                        column: x => x.KanboardId,
                        principalTable: "Kanboards",
                        principalColumn: "KanboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Institutions",
                columns: new[] { "InstitutionId", "City", "Country", "District", "Name", "Pincode", "State", "Type" },
                values: new object[,]
                {
                    { 1L, "Coimbatore", "India", "Coimbatore", "Modern Engineering College", "641035", "Tamilnadu", "College" },
                    { 2L, "Coimbatore", "India", "Coimbatore", "West Arts College", "641035", "Tamilnadu", "College" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "", "Kube Assist" },
                    { 2L, "", "Braveior Kanboard " }
                });

            migrationBuilder.InsertData(
                table: "Kanboards",
                columns: new[] { "KanboardId", "InstitutionId", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, "Kube Assist -  Modern Engineering College " },
                    { 2L, 2L, "Kube Assist -  West Arts College" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "InstitutionId", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 1L, "ramesh@email.com", 1L, "Ramesh Kumar", "password", "student" },
                    { 2L, "mary@email.com", 2L, "Mary John", "password", "student" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "ActualDays", "Attachment", "CompletionDate", "Description", "EstimatedDays", "KanboardId", "Name", "ProductId", "StartDate", "Status", "StoryPoint" },
                values: new object[,]
                {
                    { 1L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 309, DateTimeKind.Local).AddTicks(9288), "Task 1 description", 10, 1L, "Task 1", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 308, DateTimeKind.Local).AddTicks(2039), "NOT-STARTED", 5 },
                    { 2L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(758), "Task 2 description", 10, 1L, "Task 2", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(749), "NOT-STARTED", 5 },
                    { 3L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(763), "Task 3 description", 10, 1L, "Task 3", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(761), "NOT-STARTED", 5 },
                    { 4L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(768), "Task 4 description", 10, 1L, "Task 4", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(767), "NOT-STARTED", 5 },
                    { 5L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(774), "Task 5 description", 10, 1L, "Task 5", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(773), "NOT-STARTED", 5 },
                    { 6L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(778), "Task 6 description", 10, 1L, "Task 6", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(777), "NOT-STARTED", 5 },
                    { 7L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(786), "Task 7 description", 10, 1L, "Task 7", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(784), "NOT-STARTED", 5 },
                    { 8L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(789), "Task 8 description", 10, 1L, "Task 8", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(788), "NOT-STARTED", 5 },
                    { 9L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(794), "Task 9 description", 10, 1L, "Task 9", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(793), "NOT-STARTED", 5 },
                    { 10L, 5, null, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(799), "Task 10 description", 10, 1L, "Task 10", 1L, new DateTime(2021, 7, 12, 11, 20, 0, 310, DateTimeKind.Local).AddTicks(797), "NOT-STARTED", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kanboards_InstitutionId",
                table: "Kanboards",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_KanboardId",
                table: "Tasks",
                column: "KanboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProductId",
                table: "Tasks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InstitutionId",
                table: "Users",
                column: "InstitutionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Kanboards");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Institutions");
        }
    }
}
