using Experience.Models;
using Newtonsoft.Json;
using System;

namespace Experience.Converters {
    public class MailtoConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Mailto).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.String) {
                var input = (string)reader.Value;
                return new Mailto(input);
            }            
            throw new JsonReaderException(string.Format("Unexcepted token {0}", reader.TokenType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
