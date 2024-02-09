using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer_08012024.Migrations
{
    /// <inheritdoc />
    public partial class op : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnquiriesTabb",
                table: "EnquiriesTabb");

            migrationBuilder.RenameTable(
                name: "EnquiriesTabb",
                newName: "EnquiryTables");

            migrationBuilder.RenameColumn(
                name: "EnquiryId",
                table: "EnquiryTables",
                newName: "EnqId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnquiryTables",
                table: "EnquiryTables",
                column: "EnqId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnquiryTables",
                table: "EnquiryTables");

            migrationBuilder.RenameTable(
                name: "EnquiryTables",
                newName: "EnquiriesTabb");

            migrationBuilder.RenameColumn(
                name: "EnqId",
                table: "EnquiriesTabb",
                newName: "EnquiryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnquiriesTabb",
                table: "EnquiriesTabb",
                column: "EnquiryId");
        }
    }
}
