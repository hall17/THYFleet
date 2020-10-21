using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AircraftData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircrafts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: false),
                    ModelType = table.Column<string>(nullable: false),
                    Registration = table.Column<string>(nullable: false),
                    Effectivity = table.Column<string>(nullable: false),
                    BodyNo = table.Column<string>(nullable: true),
                    LineNo = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
                    Engine = table.Column<string>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircrafts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aircrafts");
        }
    }
}
