using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Group : Actor {
        private ICollection<Agent> _agents = new List<Agent>();
        public override string ObjectType {
            get { return "Group"; }
        }

        public ICollection<Agent> Agents {
            get { return _agents; }
            set { _agents = value; }
        }

        public InverseFunctionalIdentifier Ifi {
            get;
            set;
        }
    }
}