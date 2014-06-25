using System;

namespace Experience.Models {
    public class StatementReference {
        public string ObjectType {
            get { return ObjectTypes.StatementRef; }
        }

        public Guid Id { get; set; }
    }
}
