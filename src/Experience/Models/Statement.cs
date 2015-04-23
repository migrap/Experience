using Experience.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Experience.Models {    
    
    [JsonConverter(typeof(StatementConverter))]
    public class Statement {
        public Uuid Id { get; set; }

        [JsonConverter(typeof(ActorConverter))]
        public Actor Actor { get; set; }

        public Verb Verb { get; set; }

        [JsonConverter(typeof(ObjectConverter))]            
        public object Object { get; set; }

        public object Result { get; set; }

        public Context Context { get; set; }

        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset Timestamp { get; set; }

        [JsonConverter(typeof(DateTimeOffsetConverter))]
        public DateTimeOffset Stored { get; set; }

        public Authority Authority { get; set; }

        public Version Version { get; set; }

        public ICollection<Attachment> Attachment { get; } = new List<Attachment>();
    }
}
