using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate" },
                values: new object[] { 1, new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8350), "Administrator", new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8350) });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100), "Active", new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100) },
                    { 2, new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100), "Pending", new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100) },
                    { 3, new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100), "Locked", new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8100) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "ModifiedDate", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8380), "", new DateTime(2023, 2, 7, 13, 11, 2, 618, DateTimeKind.Utc).AddTicks(8380), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserStatuses");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
