namespace TextTales.Web;

public static class Endpoints
{
    public static class Category
    {
        public const string BaseUrl = "/categories";
        public const string AddUrl = $"{BaseUrl}/add";
        public const string EditUrl = BaseUrl + "/edit/{id:long}";
        public static string SetEditUrl(long id) => $"{BaseUrl}/edit/{id}";
    }
}
