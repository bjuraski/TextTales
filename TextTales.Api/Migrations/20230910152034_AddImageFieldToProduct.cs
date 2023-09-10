using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextTales.Api.Migrations;

/// <inheritdoc />
public partial class AddImageFieldToProduct : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "Image",
            table: "Products",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 1L,
            column: "Image",
            value: null);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 2L,
            column: "Image",
            value: null);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 3L,
            column: "Image",
            value: null);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 4L,
            column: "Image",
            value: null);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 5L,
            column: "Image",
            value: null);

        migrationBuilder.UpdateData(
            table: "Products",
            keyColumn: "Id",
            keyValue: 6L,
            column: "Image",
            value: null);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "Image",
            table: "Products");
    }
}
