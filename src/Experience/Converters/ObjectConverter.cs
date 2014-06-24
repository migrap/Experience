using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Experience.Models;

namespace Experience.Converters {
    public class ObjectConverter : JsonCreationConverter<Object> {
        protected override Type GetType(Type objectType, JObject jObject) {
            var type = GetType(jObject);
            switch(type) {
                case "Activity":
                    return typeof(Activity);
                case "Agent":
                    return typeof(Agent);
                case "Statement":
                    return typeof(Statement);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetType(JObject jObject) {
            return jObject["objectType"].ToObject<string>();
        }
    }
}
