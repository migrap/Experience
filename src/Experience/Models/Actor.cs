namespace Experience.Models {
    public abstract class Actor : InverseFunctionalIdentifier {
        public abstract string ObjectType { get; }
        public string Name { get; set; }
    }
}