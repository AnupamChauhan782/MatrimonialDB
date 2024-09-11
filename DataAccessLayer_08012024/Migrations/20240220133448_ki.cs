using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer_08012024.Migrations
{
    /// <inheritdoc />
    public partial class ki : Migration
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
                name: "EnquiryTables",
                columns: table => new
                {
                    EnqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnquiyFor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnquiryTables", x => x.EnqId);
                });

            migrationBuilder.CreateTable(
                name: "NewRegistarTabbColl",
                columns: table => new
                {
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaritalStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caste = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complexion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomeLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnqId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GotraId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCasteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewRegistarTabbColl", x => x.ProfileID);
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
                name: "QualificationTabb",
                columns: table => new
                {
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationTabb", x => x.QualificationId);
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
                name: "UserTabb",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTabb", x => x.Id);
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
                name: "ImageUploadTabb",
                columns: table => new
                {
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileUpLoadOne = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUploadTwo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileUploadThree = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageUploadTabb", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_ImageUploadTabb_NewRegistarTabbColl_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "NewRegistarTabbColl",
                        principalColumn: "ProfileID",
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
                name: "IX_ImageUploadTabb_ProfileID",
                table: "ImageUploadTabb",
                column: "ProfileID");

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
                name: "EnquiryTables");

            migrationBuilder.DropTable(
                name: "GotraMasterTabb");

            migrationBuilder.DropTable(
                name: "ImageUploadTabb");

            migrationBuilder.DropTable(
                name: "ProfessionTab");

            migrationBuilder.DropTable(
                name: "QualificationTabb");

            migrationBuilder.DropTable(
                name: "UserTabb");

            migrationBuilder.DropTable(
                name: "StateMasterTabb");

            migrationBuilder.DropTable(
                name: "SubCasteMasterTabb");

            migrationBuilder.DropTable(
                name: "NewRegistarTabbColl");

            migrationBuilder.DropTable(
                name: "CountryMasterTabb");
        }
    }
}
