using System.Collections.Generic;

namespace Experience.Models {
    public class Group : Actor {
        public override string ObjectType => ObjectTypes.Group;

        public ICollection<Agent> Agents { get; } = new List<Agent>();

        public InverseFunctionalIdentifier Ifi { get; set; }
    }
}