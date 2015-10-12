namespace ChartNado.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class UtilExtensions
    {
        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct, IConvertible
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse(value, true, out result) ? result : defaultValue;
        }

        public static string ToString(this IEnumerable<string> sourceList, string delimiter = ",")
        {
            return sourceList.Aggregate((current, next) => current + delimiter + next);
        }
    }
}