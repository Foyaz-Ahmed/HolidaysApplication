using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HolidaysApplication.Data.Migrations
{
    public partial class AddHolidayModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LocalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fixed = table.Column<bool>(type: "bit", nullable: false),
                    Global = table.Column<bool>(type: "bit", nullable: false),
                    Counties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Types = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");
        }
    }
}
