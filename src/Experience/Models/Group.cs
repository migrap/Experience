using System.Collections.Generic;

namespace Experience.Models {
    public class Group : Actor {
        private ICollection<Agent> _agents = new List<Agent>();
        public override string ObjectType {
            get { return ObjectTypes.Group; }
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