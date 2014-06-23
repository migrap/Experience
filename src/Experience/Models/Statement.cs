using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {

    using Attachments = System.Collections.Generic.ICollection<Attachment>;

    public class Statement {
        private ICollection<Attachment> _attachments = new List<Attachment>();

        public Guid Id { get; set; }
        public Actor Actor { get; set; }
        public Verb Verb { get; set; }

        public Object Object { get; set; }
        public Object Result { get; set; }
        public Object Context { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public DateTimeOffset Stored { get; set; }
        public Agent Authority { get; set; }

        public Attachments Attachment {
            get { return _attachments; }
            set { _attachments = value; }
        }
    }
}
