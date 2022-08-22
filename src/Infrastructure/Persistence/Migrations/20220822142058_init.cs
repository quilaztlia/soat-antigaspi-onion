using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Tsql.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "antigaspi");

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "antigaspi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(300)", nullable: true),
                    OfferId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDatetime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Offer",
                schema: "antigaspi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Availability = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact",
                schema: "antigaspi");

            migrationBuilder.DropTable(
                name: "Offer",
                schema: "antigaspi");
        }
    }
}
