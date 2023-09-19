namespace TextTales.Web;

public static class Endpoints
{
    public static class Access
    {
        public const string Login = "/identity/account/login";
        public const string Logout = "/identity/account/logout";
        public const string ManageAccount = "/identity/account/manage/index";
    }

    public static class Category
    {
        public const string BaseUrl = "/categories";
        public const string AddUrl = $"{BaseUrl}/add";
        public const string EditUrl = BaseUrl + "/edit/{id:long}";
        public static string SetEditUrl(long id) => $"{BaseUrl}/edit/{id}";
    }

    public static class Product
    {
        public const string BaseUrl = "/products";
        public const string AddUrl = $"{BaseUrl}/add";
        public const string EditUrl = BaseUrl + "/edit/{id:long}";
        public static string SetEditUrl(long id) => $"{BaseUrl}/edit/{id}";
    }
}
