using System;
using System.Text;

namespace CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string ToBase64String(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var inputBase64String = Convert.ToBase64String(inputBytes);
            return inputBase64String;
        }

        public static string FromBase64String(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var inputBytes = Convert.FromBase64String(input);
            var result = Encoding.UTF8.GetString(inputBytes);
            return result;
        }
    }
}
