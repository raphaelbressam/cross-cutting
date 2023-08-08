using System.Text.Json;

namespace CrossCutting.Serializers.Json.Options
{
    public class CamelCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => ToCamelCase(name);

        private static string ToCamelCase(string name) => string.IsNullOrWhiteSpace(name) ? name : CamelCase.ConvertName(name);
    }
}