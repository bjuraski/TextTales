using TextTales.Web.Helpers;
using TextTales.Web.Interfaces;

namespace TextTales.Web.Services;

public abstract class ValidateFieldService : IValidateFieldService
{
    private readonly HttpClient _httpClient;

    public abstract string ControllerName { get; }

    public ValidateFieldService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public bool ValidateField<T>(long? id, T value, string fieldName)
    {
        var fieldNameBuildUrlPart = StringConverterHelper.PascalCaseToKebabCase(fieldName);

        var response = Task.Run(async () => await _httpClient.GetFromJsonAsync<bool>($"api/{ControllerName.ToLower()}/validate-{fieldNameBuildUrlPart}?id={id}&{fieldNameBuildUrlPart}={value}"));
        var result = response.GetAwaiter().GetResult();

        return result;
    }
}
