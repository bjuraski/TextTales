using TextTales.Models;

namespace TextTales.Api.Data;

public static class DatabaseInitializer
{
    public static List<Category> InitializeCategories()
    {
        var categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Thriller",
                DisplayOrder = 1
            },

            new Category
            {
                Id = 2,
                Name = "Romance",
                DisplayOrder = 2
            },

            new Category
            {
                Id = 3,
                Name = "Horror",
                DisplayOrder = 3
            }
        };

        return categories;
    }

    public static List<Product> InitializeProducts()
    {
        var products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Title = "Fortune of Time",
                Author ="Billy Spark",
                Description = "In the heart-pounding world of \"Fortune of Time,\" a relentless thriller unfolds as a brilliant detective races against the clock to unravel a web of secrets and deception. Gripping suspense and unexpected twists will keep you on the edge of your seat until the very last page.",
                InternationalStandardBookNumber ="SWD9999001",
                Price = 90,
                CategoryId = 1
            },
            new Product
            {
                Id = 2,
                Title = "Dark Skies",
                Author = "Nancy Hoover",
                Description = "\"Dark Skies\" invites you into a realm of unrelenting terror, where ominous shadows and chilling horrors lurk in every corner. Prepare to be spellbound by the spine-tingling suspense and unearth the bone-chilling secrets hidden within the darkest of nights.",
                InternationalStandardBookNumber = "CAW777777701",
                Price = 30,
                CategoryId = 3
            },
            new Product
            {
                Id = 3,
                Title = "Vanish in the Sunset",
                Author = "Julian Button",
                Description = "\"Vanish in the Sunset\" is a heart-pounding thriller that will take you on a rollercoaster ride of suspense and intrigue. When the sun sets, mysteries come to light, and you'll be captivated by the relentless pursuit of truth in this gripping tale.",
                InternationalStandardBookNumber = "RITO5555501",
                Price = 50,
                CategoryId = 1
            },
            new Product
            {
                Id = 4,
                Title = "Cotton Candy",
                Author = "Abby Muscles",
                Description = "\"Cotton Candy\" is a sweet and enchanting romance that will warm your heart. Follow the journey of two souls as they navigate the twists and turns of love, sprinkled with the delightful moments that make life as sweet as cotton candy.",
                InternationalStandardBookNumber = "WS3333333301",
                Price = 65,
                CategoryId = 2
            },
            new Product
            {
                Id = 5,
                Title = "Rock in the Ocean",
                Author = "Ron Parker",
                Description = "Prepare to be submerged in a world of dread and terror with \"Rock in the Ocean.\" This bone-chilling horror story will take you on a treacherous voyage to uncover the horrifying secrets lurking beneath the waves. Beware of what lies beneath.",
                InternationalStandardBookNumber = "SOTJ1111111101",
                Price = 27,
                CategoryId = 3
            },
            new Product
            {
                Id = 6,
                Title = "Leaves and Wonders",
                Author = "Laura Phantom",
                Description = "\"Leaves and Wonders\" is a romance that blooms amidst the beauty of nature. Discover a love story that transcends time, as two hearts find solace in the wonders of the world around them. Let this enchanting tale sweep you off your feet.",
                InternationalStandardBookNumber = "FOT000000001",
                Price = 23,
                CategoryId = 2
            }
        };

        return products;
    }
}
