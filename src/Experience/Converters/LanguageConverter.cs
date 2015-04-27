using Experience.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Converters {
    public class LanguageConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Language).IsAssignableFrom(objectType);
        }

        public override bool CanRead => true;

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            if(reader.TokenType == JsonToken.Null) {
                return null;
            }

            var intermediate = new Dictionary<string, string>();
            serializer.Populate(reader, intermediate);

            var language = new Language();
            foreach(var kvp in intermediate) {
                var culture = (CultureInfo)null;
                try {
                    culture = new CultureInfo(kvp.Key);
                } catch {
                    culture = CultureInfo.CurrentCulture;
                }
                language.Add(culture, kvp.Value);
            }

            return language;
        }        

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }

}
