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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<string>(type: "text", nullable: false),
                    UserStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserStatuses_UserStatusId",
                        column: x => x.UserStatusId,
                        principalTable: "UserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140), "Admin", new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140) },
                    { 2, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140), "Intake", new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140) },
                    { 3, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140), "Manager", new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6140) }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "CreatedDate", "Description", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5250), "Active", new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5260) },
                    { 2, new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5260), "Pending", new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5260) },
                    { 3, new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5260), "Locked", new DateTime(2023, 2, 10, 12, 31, 38, 255, DateTimeKind.Utc).AddTicks(5260) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "Email", "ModifiedDate", "PasswordHash", "PasswordSalt", "UserStatusId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6180), "", new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6180), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1, "admin" },
                    { 2, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6190), "", new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6190), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1, "all" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6330), new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6330), 1, 1 },
                    { 2, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6350), new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6350), 1, 2 },
                    { 3, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6370), new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6370), 2, 2 },
                    { 4, new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6390), new DateTime(2023, 2, 10, 12, 31, 38, 256, DateTimeKind.Utc).AddTicks(6390), 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStatusId",
                table: "Users",
                column: "UserStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
