using Newtonsoft.Json;
using System;

namespace Experience.Converters {
    public class DateTimeOffsetConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(DateTimeOffset).IsAssignableFrom(objectType);
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.String) {
                var input = (string)reader.Value;
                return DateTimeOffset.Parse(input);
            }
            if(reader.TokenType == JsonToken.Date) {
                var datetime = (DateTime)reader.Value;
                return new DateTimeOffset(datetime);
            }
            throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            writer.WriteValue(((DateTimeOffset)value).ToString("yyyy-MM-ddTHH:mm:ssZ"));
        }
    }
}
