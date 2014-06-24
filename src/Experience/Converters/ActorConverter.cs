using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Experience.Converters {
    public class ActorConverter : JsonCreationConverter<Actor> {
        protected override Type GetType(Type objectType, JObject jObject) {
            var type = GetType(jObject);
            switch(type) {
                case "Agent":
                    return typeof(Agent);
                default:
                    throw new NotImplementedException();
            }
        }

        private static string GetType(JObject jObject) {
            return jObject["objectType"].ToObject<string>();
        }
    }
}
