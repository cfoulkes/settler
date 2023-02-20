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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false)
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
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false)
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
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
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
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false)
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
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7760), "Admin", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7760), 0L },
                    { 2, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7770), "Intake", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7770), 0L },
                    { 3, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7770), "Manager", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7770), 0L }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7510), "Active", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7510), 0L },
                    { 2, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7510), "Pending", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7510), 0L },
                    { 3, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7520), "Locked", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7520), 0L }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "UserStatusId", "Username" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7790), "", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7790), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1, "admin" },
                    { 2, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7790), "", "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7790), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1, "all" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "RoleId", "RowVer", "UserId" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7810), "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7810), 1, 0L, 1 },
                    { 2, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7830), "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7830), 1, 0L, 2 },
                    { 3, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7840), "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7840), 2, 0L, 2 },
                    { 4, "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7850), "", new DateTime(2023, 2, 20, 13, 10, 19, 907, DateTimeKind.Utc).AddTicks(7850), 3, 0L, 2 }
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
                name: "Clients");

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
