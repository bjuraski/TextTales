using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TextTales.Api.Migrations;

/// <inheritdoc />
public partial class AddProductsTableAndSeedData : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Products",
            columns: table => new
            {
                Id = table.Column<long>(type: "bigint", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                Description = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                InternationalStandardBookNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Products", x => x.Id);
            });

        migrationBuilder.InsertData(
            table: "Products",
            columns: new[] { "Id", "Author", "Description", "InternationalStandardBookNumber", "Price", "Title" },
            values: new object[,]
            {
                { 1L, "Billy Spark", "In the heart-pounding world of \"Fortune of Time,\" a relentless thriller unfolds as a brilliant detective races against the clock to unravel a web of secrets and deception. Gripping suspense and unexpected twists will keep you on the edge of your seat until the very last page.", "SWD9999001", 90m, "Fortune of Time" },
                { 2L, "Nancy Hoover", "\"Dark Skies\" invites you into a realm of unrelenting terror, where ominous shadows and chilling horrors lurk in every corner. Prepare to be spellbound by the spine-tingling suspense and unearth the bone-chilling secrets hidden within the darkest of nights.", "CAW777777701", 30m, "Dark Skies" },
                { 3L, "Julian Button", "\"Vanish in the Sunset\" is a heart-pounding thriller that will take you on a rollercoaster ride of suspense and intrigue. When the sun sets, mysteries come to light, and you'll be captivated by the relentless pursuit of truth in this gripping tale.", "RITO5555501", 50m, "Vanish in the Sunset" },
                { 4L, "Abby Muscles", "\"Cotton Candy\" is a sweet and enchanting romance that will warm your heart. Follow the journey of two souls as they navigate the twists and turns of love, sprinkled with the delightful moments that make life as sweet as cotton candy.", "WS3333333301", 65m, "Cotton Candy" },
                { 5L, "Ron Parker", "Prepare to be submerged in a world of dread and terror with \"Rock in the Ocean.\" This bone-chilling horror story will take you on a treacherous voyage to uncover the horrifying secrets lurking beneath the waves. Beware of what lies beneath.", "SOTJ1111111101", 27m, "Rock in the Ocean" },
                { 6L, "Laura Phantom", "\"Leaves and Wonders\" is a romance that blooms amidst the beauty of nature. Discover a love story that transcends time, as two hearts find solace in the wonders of the world around them. Let this enchanting tale sweep you off your feet.", "FOT000000001", 23m, "Leaves and Wonders" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Products");
    }
}
