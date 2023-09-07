namespace TextTales.Web.Interfaces;

public interface IValidateFieldService
{
    bool ValidateField<T>(long? id, T value, string fieldName);
}
