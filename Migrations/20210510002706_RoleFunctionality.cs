using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolAPI.Migrations
{
    public partial class RoleFunctionality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Users",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(4169), new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(4521) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 933, DateTimeKind.Local).AddTicks(1831), new DateTime(2021, 5, 9, 20, 27, 5, 933, DateTimeKind.Local).AddTicks(2179) });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d0ef81f-6fb7-495e-81e3-7c9c686525a5", "b60bc95e-5cb5-4d9d-8c80-50070847a441", "Admin", "ADMIN" },
                    { "f9f6bde3-ba8a-4f83-bc5b-2ecfcbf8947a", "ce696377-c652-4f28-a2f4-de9e5e20dfd9", "Student", "STUDENT" }
                });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 931, DateTimeKind.Local).AddTicks(6630), new DateTime(2021, 5, 9, 20, 27, 5, 931, DateTimeKind.Local).AddTicks(6994) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 933, DateTimeKind.Local).AddTicks(5213), new DateTime(2021, 5, 9, 20, 27, 5, 933, DateTimeKind.Local).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(469), new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(817) });

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "SubmissionID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(8135), new DateTime(2021, 5, 9, 20, 27, 5, 932, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "DateCreated", "DateUpdated", "Id", "SecurityStamp" },
                values: new object[] { "af2656e4-14f0-40ae-b0f7-0c45edf87c70", new DateTime(2021, 5, 9, 20, 27, 5, 930, DateTimeKind.Local).AddTicks(4253), new DateTime(2021, 5, 9, 20, 27, 5, 930, DateTimeKind.Local).AddTicks(4766), "0f4e37f3-f447-4738-bb14-2bf2289aef60", "8d817ebf-3caa-49a9-90ef-c57d607b7f39" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "AssignmentID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 196, DateTimeKind.Local).AddTicks(1570), new DateTime(2021, 5, 9, 19, 52, 46, 196, DateTimeKind.Local).AddTicks(1936) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 196, DateTimeKind.Local).AddTicks(9787), new DateTime(2021, 5, 9, 19, 52, 46, 197, DateTimeKind.Local).AddTicks(150) });

            migrationBuilder.UpdateData(
                table: "Organizations",
                keyColumn: "OrganizationID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 195, DateTimeKind.Local).AddTicks(3928), new DateTime(2021, 5, 9, 19, 52, 46, 195, DateTimeKind.Local).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Schools",
                keyColumn: "SchoolID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 197, DateTimeKind.Local).AddTicks(3299), new DateTime(2021, 5, 9, 19, 52, 46, 197, DateTimeKind.Local).AddTicks(3660) });

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "SectionID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 195, DateTimeKind.Local).AddTicks(7800), new DateTime(2021, 5, 9, 19, 52, 46, 195, DateTimeKind.Local).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "Submissions",
                keyColumn: "SubmissionID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 196, DateTimeKind.Local).AddTicks(5786), new DateTime(2021, 5, 9, 19, 52, 46, 196, DateTimeKind.Local).AddTicks(6144) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateUpdated" },
                values: new object[] { new DateTime(2021, 5, 9, 19, 52, 46, 194, DateTimeKind.Local).AddTicks(494), new DateTime(2021, 5, 9, 19, 52, 46, 194, DateTimeKind.Local).AddTicks(1052) });
        }
    }
}
