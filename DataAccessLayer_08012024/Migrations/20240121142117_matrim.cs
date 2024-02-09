using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer_08012024.Migrations
{
    /// <inheritdoc />
    public partial class matrim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryMasterTabb",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMasterTabb", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "EducationMaasterTabb",
                columns: table => new
                {
                    EducationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationMaasterTabb", x => x.EducationId);
                });

            migrationBuilder.CreateTable(
                name: "EnquiriesTabb",
                columns: table => new
                {
                    EnquiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnquiyFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiriesTabb", x => x.EnquiryId);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionTab",
                columns: table => new
                {
                    ProfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionTab", x => x.ProfessionId);
                });

            migrationBuilder.CreateTable(
                name: "SubCasteMasterTabb",
                columns: table => new
                {
                    SubCasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCasteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCasteMasterTabb", x => x.SubCasteId);
                });

            migrationBuilder.CreateTable(
                name: "StateMasterTabb",
                columns: table => new
                {
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateMasterTabb", x => x.StateId);
                    table.ForeignKey(
                        name: "FK_StateMasterTabb_CountryMasterTabb_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryMasterTabb",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GotraMasterTabb",
                columns: table => new
                {
                    GotraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GortaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SubCasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Createdby = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GotraMasterTabb", x => x.GotraId);
                    table.ForeignKey(
                        name: "FK_GotraMasterTabb_SubCasteMasterTabb_SubCasteId",
                        column: x => x.SubCasteId,
                        principalTable: "SubCasteMasterTabb",
                        principalColumn: "SubCasteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DistrictMasterTabb",
                columns: table => new
                {
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistrictMasterTabb", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_DistrictMasterTabb_StateMasterTabb_StateId",
                        column: x => x.StateId,
                        principalTable: "StateMasterTabb",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DistrictMasterTabb_StateId",
                table: "DistrictMasterTabb",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_GotraMasterTabb_SubCasteId",
                table: "GotraMasterTabb",
                column: "SubCasteId");

            migrationBuilder.CreateIndex(
                name: "IX_StateMasterTabb_CountryId",
                table: "StateMasterTabb",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DistrictMasterTabb");

            migrationBuilder.DropTable(
                name: "EducationMaasterTabb");

            migrationBuilder.DropTable(
                name: "EnquiriesTabb");

            migrationBuilder.DropTable(
                name: "GotraMasterTabb");

            migrationBuilder.DropTable(
                name: "ProfessionTab");

            migrationBuilder.DropTable(
                name: "StateMasterTabb");

            migrationBuilder.DropTable(
                name: "SubCasteMasterTabb");

            migrationBuilder.DropTable(
                name: "CountryMasterTabb");
        }
    }
}
