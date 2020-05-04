using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstate.DataLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestEstate_Estates_EstateId",
                table: "RequestEstate");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestEstate_AspNetUsers_SaveUserId",
                table: "RequestEstate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestEstate",
                table: "RequestEstate");

            migrationBuilder.RenameTable(
                name: "RequestEstate",
                newName: "RequestEstates");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEstate_SaveUserId",
                table: "RequestEstates",
                newName: "IX_RequestEstates_SaveUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEstate_EstateId",
                table: "RequestEstates",
                newName: "IX_RequestEstates_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestEstates",
                table: "RequestEstates",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEstates_Estates_EstateId",
                table: "RequestEstates",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEstates_AspNetUsers_SaveUserId",
                table: "RequestEstates",
                column: "SaveUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequestEstates_Estates_EstateId",
                table: "RequestEstates");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestEstates_AspNetUsers_SaveUserId",
                table: "RequestEstates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestEstates",
                table: "RequestEstates");

            migrationBuilder.RenameTable(
                name: "RequestEstates",
                newName: "RequestEstate");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEstates_SaveUserId",
                table: "RequestEstate",
                newName: "IX_RequestEstate_SaveUserId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestEstates_EstateId",
                table: "RequestEstate",
                newName: "IX_RequestEstate_EstateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestEstate",
                table: "RequestEstate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEstate_Estates_EstateId",
                table: "RequestEstate",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestEstate_AspNetUsers_SaveUserId",
                table: "RequestEstate",
                column: "SaveUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
