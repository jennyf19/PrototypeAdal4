using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrototypeAdal4.Migrations
{
    public partial class ApprovedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Products_ProductID",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Releases_ReleaseID",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_ReleaseID",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ApprovedDateTime",
                table: "Approvals");

            migrationBuilder.DropColumn(
                name: "ReleaseID",
                table: "Approvals");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDate",
                table: "Approvals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ApprovalID",
                table: "Releases",
                column: "ApprovalID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ProductID",
                table: "Releases",
                column: "ProductID");

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                table: "Products",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseNotes",
                table: "Products",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Approvals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "Approvals",
                maxLength: 50,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Products_ProductID",
                table: "Approvals",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Approvals_ApprovalID",
                table: "Releases",
                column: "ApprovalID",
                principalTable: "Approvals",
                principalColumn: "ApprovalID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Products_ProductID",
                table: "Releases",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Products_ProductID",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Approvals_ApprovalID",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Products_ProductID",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_ApprovalID",
                table: "Releases");

            migrationBuilder.DropIndex(
                name: "IX_Releases_ProductID",
                table: "Releases");

            migrationBuilder.DropColumn(
                name: "ApprovedDate",
                table: "Approvals");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedDateTime",
                table: "Approvals",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ReleaseID",
                table: "Approvals",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "VersionNumber",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReleaseNotes",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductID",
                table: "Approvals",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovedBy",
                table: "Approvals",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_ReleaseID",
                table: "Approvals",
                column: "ReleaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Products_ProductID",
                table: "Approvals",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Releases_ReleaseID",
                table: "Approvals",
                column: "ReleaseID",
                principalTable: "Releases",
                principalColumn: "ReleaseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
