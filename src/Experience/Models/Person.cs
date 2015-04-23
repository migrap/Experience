using System;
using System.Collections.Generic;

namespace Experience.Models {
    public class Person : InverseFunctionalIdentifier {
        public string ObjectType => ObjectTypes.Person;

        public ICollection<string> Name { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    }
}