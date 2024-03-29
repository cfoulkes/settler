﻿using System;
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
                name: "AgencyStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyStatuses", x => x.Id);
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
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberOfLicences = table.Column<int>(type: "integer", nullable: false),
                    AgencyStatusId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencies_AgencyStatuses_AgencyStatusId",
                        column: x => x.AgencyStatusId,
                        principalTable: "AgencyStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    AgencyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    xmin = table.Column<uint>(type: "xid", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguagePreference = table.Column<string>(type: "text", nullable: false),
                    AgencyId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: false),
                    RowVer = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
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
                table: "AgencyStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9970), "Active", "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9970), 0L },
                    { 2, "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9980), "Suspended", "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9980), 0L }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc), "SysAdmin", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), 0L },
                    { 2, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), "Admin", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), 0L },
                    { 3, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), "Intake", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), 0L },
                    { 4, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), "Manager", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(10), 0L }
                });

            migrationBuilder.InsertData(
                table: "UserStatuses",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), "Active", "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), 0L },
                    { 2, "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), "Pending", "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), 0L },
                    { 3, "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), "Locked", "", new DateTime(2023, 3, 11, 12, 57, 12, 957, DateTimeKind.Utc).AddTicks(9610), 0L }
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "AgencyStatusId", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate", "Name", "NumberOfLicences", "RowVer" },
                values: new object[] { 1, 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(120), "", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(120), "Test Agency 1", 0, 0L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "UserStatusId" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(40), "admin@settler.test", "", "", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(40), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1 },
                    { 2, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(80), "all@settler.test", "", "", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(80), "FC57D856266390FBEFE1E3BF64011C538A3CB25C4D048F867998351335F744059D6EB133A85FECC9B2A60088147EDDA18622FA95B3282C30BAAFABC0E1EA9A9D", "4A46744489B84AF9679B72BC470BC9401887A7CC2AA76D44CB450197BC05AC04633047A90949826784CD545CFA0885267FA8C1C9AE1918086D92DBC0FB5D64D7", 1 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AgencyId", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160), null, "Fred", "Flintstone", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160) },
                    { 2, 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160), null, "Wilma", "Flintstone", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160) },
                    { 3, 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160), null, "Barney", "Rubble", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(160) }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AgencyId", "CreatedBy", "CreatedDate", "LanguagePreference", "ModifiedBy", "ModifiedDate", "RowVer" },
                values: new object[] { 2, 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(140), "en-CA", "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(140), 0L });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "RoleId", "RowVer", "UserId" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(60), "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(60), 1, 0L, 1 },
                    { 2, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(90), "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(90), 1, 0L, 2 },
                    { 3, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(90), "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(90), 2, 0L, 2 },
                    { 4, "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(100), "", new DateTime(2023, 3, 11, 12, 57, 12, 958, DateTimeKind.Utc).AddTicks(100), 3, 0L, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_AgencyStatusId",
                table: "Agencies",
                column: "AgencyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AgencyId",
                table: "Clients",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_AgencyId",
                table: "UserProfiles",
                column: "AgencyId");

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
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AgencyStatuses");

            migrationBuilder.DropTable(
                name: "UserStatuses");
        }
    }
}
