using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;
using CrossCutting.Serializers.Json.Converters;
using CrossCutting.Serializers.Json.Options;

namespace CrossCutting.Serializers.Json
{

    public class JsonParser
    {
        public static readonly JsonSerializerOptions PascalCaseOption = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {
            new JsonStringEnumConverter(),
            new DateTimeConverter()
        }
        };

        public static readonly JsonSerializerOptions CamelCaseOption = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = new CamelCaseNamingPolicy(),
            Converters = {
            new JsonStringEnumConverter(),
            new DateTimeConverter()
        }
        };

        public static readonly JsonSerializerOptions SnakeCaseOption = new JsonSerializerOptions()
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = new SankeCaseNamingPolicy(),
            Converters = {
            new JsonStringEnumConverter(),
            new DateTimeConverter()
        }
        };

        private static JsonSerializerOptions ResolveCaseOption(JsonFormatCaseEnum jsonFormatCase)
        => jsonFormatCase switch
        {
            JsonFormatCaseEnum.CamelCase => CamelCaseOption,
            JsonFormatCaseEnum.PascalCase => PascalCaseOption,
            _ => SnakeCaseOption
        };

        public static string Serialize(object obj, JsonFormatCaseEnum jsonFormatCase = JsonFormatCaseEnum.SnakeCase)
        => JsonSerializer.Serialize(obj, ResolveCaseOption(jsonFormatCase));

        public static T? Deserialize<T>(string value, JsonFormatCaseEnum jsonFormatCase = JsonFormatCaseEnum.SnakeCase)
        where T : class
        => JsonSerializer.Deserialize<T>(value, ResolveCaseOption(jsonFormatCase));

        public static async Task<T?> DeserializeAsync<T>(Stream value, JsonFormatCaseEnum jsonFormatCase = JsonFormatCaseEnum.SnakeCase)
        where T : class
        => await JsonSerializer.DeserializeAsync<T>(value, ResolveCaseOption(jsonFormatCase));
    }
}