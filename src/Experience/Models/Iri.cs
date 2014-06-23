using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Iri : Uri {
        public Iri(string value, UriKind kind) : base(value, kind) {
        }
    }
}
