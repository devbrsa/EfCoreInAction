using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Chapter08ConcurrencyTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "VoterName",
                table: "Review",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromotionalText",
                table: "PriceOffers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NewPrice",
                table: "PriceOffers",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Books",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Books",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                type: "decimal(9,2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "varchar(512)",
                unicode: false,
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ConcurrencyBooks",
                columns: table => new
                {
                    ConcurrencyBookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChangeCheck = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcurrencyBooks", x => x.ConcurrencyBookId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublishedOn",
                table: "Books",
                column: "PublishedOn");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcurrencyBooks");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublishedOn",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "VoterName",
                table: "Review",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PromotionalText",
                table: "PriceOffers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<decimal>(
                name: "NewPrice",
                table: "PriceOffers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Publisher",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedOn",
                table: "Books",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(9,2)");

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Books",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(512)",
                oldUnicode: false,
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
