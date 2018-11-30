using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Postcode = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wills",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wills_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Over18 = table.Column<bool>(nullable: false),
                    WillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Children_WillId",
                table: "Children",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Wills_AddressId",
                table: "Wills",
                column: "AddressId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Wills");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
