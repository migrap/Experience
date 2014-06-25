#if MGP_LATER
using System;

namespace Experience.Models {
    public class Iri : Uri {
        public Iri(string value, UriKind kind) : base(value, kind) {
        }
    }
}

#endif