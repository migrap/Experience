using Experience.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections;

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

        public AttachmentCollection Attachment { get; } = new AttachmentCollection();
    }

    public class AttachmentCollection : IEnumerable<Attachment> {
        private readonly List<Attachment> _attachments = new List<Attachment>();

        public AttachmentCollection() {
        }

        public AttachmentCollection(IEnumerable<Attachment> collection) {
            _attachments.AddRange(collection);
        }

        public void Add(Attachment item) {
            _attachments.Add(item);
        }

        public IEnumerator<Attachment> GetEnumerator() {
            return _attachments.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
