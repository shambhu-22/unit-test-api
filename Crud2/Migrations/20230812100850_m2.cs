using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Crud2.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IceCreamImages",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IceCreamId = table.Column<int>(type: "int", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageContent = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreamImages", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_IceCreamImages_IceCreamItems_IceCreamId",
                        column: x => x.IceCreamId,
                        principalTable: "IceCreamItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IceCreamImages_IceCreamId",
                table: "IceCreamImages",
                column: "IceCreamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCreamImages");
        }
    }
}
