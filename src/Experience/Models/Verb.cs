using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Verb {
        public string Id { get; set; }
        public Language Display { get; set; }

		public override string ToString() {
			return string.Format("[Verb: Id={0}, Display={1}]", Id, Display);
		}
    }
}