using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Chapter07OwnerTypesPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeAddress",
                columns: table => new
                {
                    OrderInfoId = table.Column<int>(nullable: false),
                    NumberAndStreet = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ZipPostCode = table.Column<string>(nullable: true),
                    CountryCodeIso2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeAddress", x => x.OrderInfoId);
                    table.ForeignKey(
                        name: "FK_HomeAddress_OrderInfos_OrderInfoId",
                        column: x => x.OrderInfoId,
                        principalTable: "OrderInfos",
                        principalColumn: "OrderInfoId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeAddress");
        }
    }
}
