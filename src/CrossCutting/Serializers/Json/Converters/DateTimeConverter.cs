using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrossCutting.Serializers.Json.Converters
{
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? value = reader.GetString();

            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value), value);

            return DateTime.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
        }
    }
}