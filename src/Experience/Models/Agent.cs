namespace Experience.Models {
    public class Agent : Actor {
        public Agent(string name = "", string mbox = "") {
            Name = name;
            Mbox = mbox;
        }

        public Agent() {
        }

        public override string ObjectType => ObjectTypes.Agent;
    }
}