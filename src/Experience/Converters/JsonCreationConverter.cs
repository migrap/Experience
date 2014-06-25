using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;

namespace Experience.Converters {
    //TODO: maybe replace with CustomCreationConverter<T>?
    public abstract class JsonCreationConverter<T> : JsonConverter {
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
    }
}
