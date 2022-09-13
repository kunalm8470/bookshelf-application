using System.Globalization;

namespace BookShelf.Domain.Extensions;

public static class DateTimeExtensions
{
    public static string FormatToReadableDateString(this DateTime? dateTime)
    {
        if (dateTime is null)
        {
            return null;
        }

        return dateTime.Value.FormatToReadableDateString();
    }

    public static string FormatToReadableDateString(this DateTime dateTime)
    {
        return dateTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture);
    }
}
