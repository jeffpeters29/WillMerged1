using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Initial : Migration
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
                    Postcode = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<string>(maxLength: 100, nullable: false),
                    Street = table.Column<string>(nullable: true),
                    Village = table.Column<string>(maxLength: 100, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuneralTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuneralTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relationships",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partners",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partners_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Telephone = table.Column<string>(nullable: true),
                    MaritalStatusId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wills",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    WillStatus = table.Column<int>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true),
                    PartnerId = table.Column<Guid>(nullable: true),
                    FuneralTypeId = table.Column<Guid>(nullable: true),
                    FuneralWishes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wills_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wills_FuneralTypes_FuneralTypeId",
                        column: x => x.FuneralTypeId,
                        principalTable: "FuneralTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wills_Partners_PartnerId",
                        column: x => x.PartnerId,
                        principalTable: "Partners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CashRecipients",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CashRecipients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashRecipients_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CashRecipients_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Executors",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAwareFinances = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Executors_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Executors_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Executors_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftRecipients",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftRecipients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftRecipients_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftRecipients_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LegalGuardians",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalGuardians", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalGuardians_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalGuardians_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LegalGuardians_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NonProvisions",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    ReasonWhy = table.Column<string>(maxLength: 500, nullable: true),
                    RelationshipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonProvisions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonProvisions_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NonProvisions_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidueRecipients",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false),
                    Level = table.Column<int>(nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidueRecipients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResidueRecipients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidueRecipients_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResidueRecipients_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trustees",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    RelationshipId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trustees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trustees_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trustees_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trustees_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Witnesses",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: false),
                    Occupation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Witnesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Witnesses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Witnesses_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Children",
                columns: table => new
                {
                    CreatedUtc = table.Column<DateTime>(nullable: false),
                    UpdatedUtc = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    WillId = table.Column<Guid>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsAddressSame = table.Column<bool>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: true),
                    RelationshipId = table.Column<Guid>(nullable: false),
                    LegalGuardianId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Children", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Children_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Children_LegalGuardians_LegalGuardianId",
                        column: x => x.LegalGuardianId,
                        principalTable: "LegalGuardians",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Children_Relationships_RelationshipId",
                        column: x => x.RelationshipId,
                        principalTable: "Relationships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Children_Wills_WillId",
                        column: x => x.WillId,
                        principalTable: "Wills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "FuneralTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("01dd3472-4837-4934-8f6c-c350af361b8b"), "Burial" },
                    { new Guid("7d38792f-e84c-4a19-a1c5-b9047be50885"), "Cremation" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { new Guid("633976ac-1367-42cc-812e-cbfcbbefc789"), "Married" },
                    { new Guid("f01436ec-ef7b-4ec0-bb58-58c5ce6932d8"), "Civil Partnership" },
                    { new Guid("b2d98283-9bb5-4fcf-a584-2728c4c7c757"), "Single" },
                    { new Guid("7cd83800-507f-4160-a216-a6d92fd1edb6"), "Divorced" },
                    { new Guid("97acd8f0-e48a-4adf-8957-0f869f64a587"), "Separated" },
                    { new Guid("cfa9cd37-2267-4b9d-ae41-eb88c8e89881"), "Widowed" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CashRecipients_AddressId",
                table: "CashRecipients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashRecipients_RelationshipId",
                table: "CashRecipients",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CashRecipients_WillId",
                table: "CashRecipients",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Children_AddressId",
                table: "Children",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Children_LegalGuardianId",
                table: "Children",
                column: "LegalGuardianId",
                unique: true,
                filter: "[LegalGuardianId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Children_RelationshipId",
                table: "Children",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Children_WillId",
                table: "Children",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MaritalStatusId",
                table: "Customers",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Executors_AddressId",
                table: "Executors",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_RelationshipId",
                table: "Executors",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Executors_WillId",
                table: "Executors",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftRecipients_AddressId",
                table: "GiftRecipients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftRecipients_RelationshipId",
                table: "GiftRecipients",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GiftRecipients_WillId",
                table: "GiftRecipients",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalGuardians_AddressId",
                table: "LegalGuardians",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalGuardians_RelationshipId",
                table: "LegalGuardians",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LegalGuardians_WillId",
                table: "LegalGuardians",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_NonProvisions_RelationshipId",
                table: "NonProvisions",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NonProvisions_WillId",
                table: "NonProvisions",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Partners_AddressId",
                table: "Partners",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidueRecipients_AddressId",
                table: "ResidueRecipients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidueRecipients_RelationshipId",
                table: "ResidueRecipients",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResidueRecipients_WillId",
                table: "ResidueRecipients",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Trustees_AddressId",
                table: "Trustees",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trustees_RelationshipId",
                table: "Trustees",
                column: "RelationshipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trustees_WillId",
                table: "Trustees",
                column: "WillId");

            migrationBuilder.CreateIndex(
                name: "IX_Wills_CustomerId",
                table: "Wills",
                column: "CustomerId",
                unique: true,
                filter: "[CustomerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wills_FuneralTypeId",
                table: "Wills",
                column: "FuneralTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wills_PartnerId",
                table: "Wills",
                column: "PartnerId",
                unique: true,
                filter: "[PartnerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Witnesses_AddressId",
                table: "Witnesses",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Witnesses_WillId",
                table: "Witnesses",
                column: "WillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CashRecipients");

            migrationBuilder.DropTable(
                name: "Children");

            migrationBuilder.DropTable(
                name: "Executors");

            migrationBuilder.DropTable(
                name: "GiftRecipients");

            migrationBuilder.DropTable(
                name: "NonProvisions");

            migrationBuilder.DropTable(
                name: "ResidueRecipients");

            migrationBuilder.DropTable(
                name: "Trustees");

            migrationBuilder.DropTable(
                name: "Witnesses");

            migrationBuilder.DropTable(
                name: "LegalGuardians");

            migrationBuilder.DropTable(
                name: "Relationships");

            migrationBuilder.DropTable(
                name: "Wills");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "FuneralTypes");

            migrationBuilder.DropTable(
                name: "Partners");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
