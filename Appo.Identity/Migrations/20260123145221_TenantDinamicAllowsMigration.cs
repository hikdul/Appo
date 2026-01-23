using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appo.Identity.Migrations
{
    /// <inheritdoc />
    public partial class TenantDinamicAllowsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyUserHasAllowedDinamyc",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alloweds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUserHasAllowedDinamyc", x => new { x.CompanyId, x.UserId, x.Alloweds });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyUserHasAllowedDinamyc");
        }
    }
}
