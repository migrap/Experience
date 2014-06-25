using System.Collections.Generic;

namespace Experience.Models {
    public class Person : InverseFunctionalIdentifier {
        private ICollection<string> _name = new HashSet<string>();

        public string ObjectType {
            get { return ObjectTypes.Person; }
        }

        public ICollection<string> Name {
            get { return _name; }
            set { _name = value; }
        }
    }
}
