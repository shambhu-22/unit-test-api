using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud2.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IceCreamItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IceCreamType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Flavour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Natural_synthetic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergens = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VegType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerPiece = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeOfPrice = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MfgDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreamItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCreamItems");
        }
    }
}
