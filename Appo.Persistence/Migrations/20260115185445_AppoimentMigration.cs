using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AppoimentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Appoiment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartnerTenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PartnerPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    WorkCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerRequest = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    WorkDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Gossip = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Finish = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appoiment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appoiment_Customer_CustomerTenantId_CustomerPersonId",
                        columns: x => new { x.CustomerTenantId, x.CustomerPersonId },
                        principalTable: "Customer",
                        principalColumns: new[] { "TenantId", "PersonId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appoiment_Partner_PartnerTenantId_PartnerPersonId",
                        columns: x => new { x.PartnerTenantId, x.PartnerPersonId },
                        principalTable: "Partner",
                        principalColumns: new[] { "TenantId", "PersonId" });
                    table.ForeignKey(
                        name: "FK_Appoiment_WorkCenters_WorkCenterId",
                        column: x => x.WorkCenterId,
                        principalTable: "WorkCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appoiment_CustomerTenantId_CustomerPersonId",
                table: "Appoiment",
                columns: new[] { "CustomerTenantId", "CustomerPersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appoiment_PartnerTenantId_PartnerPersonId",
                table: "Appoiment",
                columns: new[] { "PartnerTenantId", "PartnerPersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_Appoiment_WorkCenterId",
                table: "Appoiment",
                column: "WorkCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appoiment");
        }
    }
}
