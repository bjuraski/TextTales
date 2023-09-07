using System.Text;

namespace TextTales.Web.Helpers;

public static class StringConverterHelper
{
    public static string PascalCaseToKebabCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var output = new StringBuilder();
        int startIndex = 0;

        for (int i = 1; i < input.Length; i++)
        {
            if (char.IsUpper(input[i]))
            {
                output.Append(input.Substring(startIndex, i - startIndex).ToLower());

                if (i - startIndex > 0)
                {
                    output.Append('-');
                }

                startIndex = i;
            }
        }

        output.Append(input.Substring(startIndex).ToLower());

        return output.ToString();
    }
}
