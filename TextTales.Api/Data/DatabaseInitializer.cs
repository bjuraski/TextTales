using TextTales.Api.Entities;

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
}
