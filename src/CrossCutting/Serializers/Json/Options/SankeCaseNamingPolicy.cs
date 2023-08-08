using System;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CrossCutting.Serializers.Json.Options
{
    public class SankeCaseNamingPolicy : JsonNamingPolicy
    {
        const string _pattern = @"([a-z0-9])([A-Z])";
        const string _replacement = "$1_$2";
        public override string ConvertName(string name) => ToSnakeCase(name);

        private static string ToSnakeCase(string name)
        => string.IsNullOrWhiteSpace(name) ? name : Regex.Replace(name, _pattern, _replacement, RegexOptions.Compiled, TimeSpan.FromSeconds(0.2)).ToLower();
    }
}