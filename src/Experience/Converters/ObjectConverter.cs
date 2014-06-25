using Experience.Models;
using Newtonsoft.Json.Linq;
using System;

namespace Experience.Converters {
    public class ObjectConverter : JsonCreationConverter<Object> {
        protected override Type GetType(Type objectType, JObject jObject) {
            var type = GetType(jObject);
            switch(type) {
                case "Activity":
                    return typeof(Activity);
                case "Agent":
                    return typeof(Agent);
                case "Group":
                    return typeof(Group);
                case "StatementRef":
                    return typeof(StatementReference);
                //case "Sub-Statement":
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetType(JObject jObject) {
            return jObject["objectType"].ToObject<string>();
        }
    }
}
