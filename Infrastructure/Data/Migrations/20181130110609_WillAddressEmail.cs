using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class WillAddressEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wills_Addresses_AddressId",
                table: "Wills");

            migrationBuilder.DropIndex(
                name: "IX_Wills_AddressId",
                table: "Wills");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Wills",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Wills",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Wills_AddressId",
                table: "Wills",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Wills_Addresses_AddressId",
                table: "Wills",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wills_Addresses_AddressId",
                table: "Wills");

            migrationBuilder.DropIndex(
                name: "IX_Wills_AddressId",
                table: "Wills");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Wills");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Wills",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wills_AddressId",
                table: "Wills",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Wills_Addresses_AddressId",
                table: "Wills",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
