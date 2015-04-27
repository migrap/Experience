using Experience.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Experience.Converters {
    public class StatementConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Statement).IsEquivalentTo(objectType);
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            var jObject = JObject.Load(reader);
            var target = new Statement();
            var jObjectReader = jObject.CreateReader();
            serializer.Populate(jObjectReader, target);
            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}