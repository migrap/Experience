﻿using Experience.Models;
using Newtonsoft.Json.Linq;
using System;

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
