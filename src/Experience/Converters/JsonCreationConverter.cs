using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Experience.Converters {
    public abstract class JsonCreationConverter<T> : JsonConverter {
#if MGP_LATER
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType) {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) {
                return null;
            }

            // Load JObject from stream
            var jObject = JObject.Load(reader);

            // Create target object based on JObject
            var target = Create(objectType, jObject);

            // Populate the object properties
            var writer = new StringWriter();
            serializer.Serialize(writer, jObject);
            using (var newReader = new JsonTextReader(new StringReader(writer.ToString()))) {
                newReader.Culture = reader.Culture;
                newReader.DateParseHandling = reader.DateParseHandling;
                newReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;                
                serializer.Populate(newReader, target);
            }

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            serializer.Serialize(writer, value);
        }
#else
        protected abstract Type GetType(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType) {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(JsonReader reader, Type objectType,
            object existingValue, JsonSerializer serializer) {
            JObject jObject = JObject.Load(reader);

            Type targetType = GetType(objectType, jObject);

            // TODO: Change this to the Json.Net-built-in way of creating instances
            object target = Activator.CreateInstance(targetType);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }

        /// <summary>Serializes to the specified type</summary>
        /// <param name="writer">Newtonsoft.Json.JsonWriter</param>
        /// <param name="value">Object to serialize.</param>
        /// <param name="serializer">Newtonsoft.Json.JsonSerializer to use.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            serializer.Serialize(writer, value);
        }
#endif
    }
}
