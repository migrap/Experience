using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Agent : Actor {
        public override string ObjectType {
            get { return "Agent"; }
        }

        public InverseFunctionalIdentifier Ifi {
            get;
            set;
        }
    }
}
