using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuditEntMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoiment_Customer_CustomerTenantId_CustomerPersonId",
                table: "Appoiment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appoiment_Partner_PartnerTenantId_PartnerPersonId",
                table: "Appoiment");

            migrationBuilder.DropForeignKey(
                name: "FK_Appoiment_WorkCenters_WorkCenterId",
                table: "Appoiment");

            migrationBuilder.DropForeignKey(
                name: "FK_Customer_Persons_PersonId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Partner_Persons_PersonId",
                table: "Partner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partner",
                table: "Partner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appoiment",
                table: "Appoiment");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partners");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Appoiment",
                newName: "Appoiments");

            migrationBuilder.RenameIndex(
                name: "IX_Partner_PersonId",
                table: "Partners",
                newName: "IX_Partners_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Customer_PersonId",
                table: "Customers",
                newName: "IX_Customers_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiment_WorkCenterId",
                table: "Appoiments",
                newName: "IX_Appoiments_WorkCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiment_PartnerTenantId_PartnerPersonId",
                table: "Appoiments",
                newName: "IX_Appoiments_PartnerTenantId_PartnerPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiment_CustomerTenantId_CustomerPersonId",
                table: "Appoiments",
                newName: "IX_Appoiments_CustomerTenantId_CustomerPersonId");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "WorkCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "WorkCenters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "WorkCenters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "WorkCenters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Persons",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Companys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Companys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Companys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Companys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Partners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Partners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Partners",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Customers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Appoiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Appoiments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Appoiments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Appoiments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partners",
                table: "Partners",
                columns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                columns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appoiments",
                table: "Appoiments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiments_Customers_CustomerTenantId_CustomerPersonId",
                table: "Appoiments",
                columns: new[] { "CustomerTenantId", "CustomerPersonId" },
                principalTable: "Customers",
                principalColumns: new[] { "TenantId", "PersonId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiments_Partners_PartnerTenantId_PartnerPersonId",
                table: "Appoiments",
                columns: new[] { "PartnerTenantId", "PartnerPersonId" },
                principalTable: "Partners",
                principalColumns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiments_WorkCenters_WorkCenterId",
                table: "Appoiments",
                column: "WorkCenterId",
                principalTable: "WorkCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Persons_PersonId",
                table: "Customers",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partners_Persons_PersonId",
                table: "Partners",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appoiments_Customers_CustomerTenantId_CustomerPersonId",
                table: "Appoiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appoiments_Partners_PartnerTenantId_PartnerPersonId",
                table: "Appoiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appoiments_WorkCenters_WorkCenterId",
                table: "Appoiments");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Persons_PersonId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Partners_Persons_PersonId",
                table: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partners",
                table: "Partners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appoiments",
                table: "Appoiments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WorkCenters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "WorkCenters");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "WorkCenters");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "WorkCenters");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Companys");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Partners");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Appoiments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Appoiments");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Appoiments");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Appoiments");

            migrationBuilder.RenameTable(
                name: "Partners",
                newName: "Partner");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Appoiments",
                newName: "Appoiment");

            migrationBuilder.RenameIndex(
                name: "IX_Partners_PersonId",
                table: "Partner",
                newName: "IX_Partner_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_PersonId",
                table: "Customer",
                newName: "IX_Customer_PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiments_WorkCenterId",
                table: "Appoiment",
                newName: "IX_Appoiment_WorkCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiments_PartnerTenantId_PartnerPersonId",
                table: "Appoiment",
                newName: "IX_Appoiment_PartnerTenantId_PartnerPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Appoiments_CustomerTenantId_CustomerPersonId",
                table: "Appoiment",
                newName: "IX_Appoiment_CustomerTenantId_CustomerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partner",
                table: "Partner",
                columns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                columns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appoiment",
                table: "Appoiment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiment_Customer_CustomerTenantId_CustomerPersonId",
                table: "Appoiment",
                columns: new[] { "CustomerTenantId", "CustomerPersonId" },
                principalTable: "Customer",
                principalColumns: new[] { "TenantId", "PersonId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiment_Partner_PartnerTenantId_PartnerPersonId",
                table: "Appoiment",
                columns: new[] { "PartnerTenantId", "PartnerPersonId" },
                principalTable: "Partner",
                principalColumns: new[] { "TenantId", "PersonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Appoiment_WorkCenters_WorkCenterId",
                table: "Appoiment",
                column: "WorkCenterId",
                principalTable: "WorkCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_Persons_PersonId",
                table: "Customer",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partner_Persons_PersonId",
                table: "Partner",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
