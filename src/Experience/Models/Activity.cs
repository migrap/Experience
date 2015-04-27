using System;

namespace Experience.Models {
    public class Activity {
        public string Id { get; set; }
        public Definition Definition { get; set; }
        public string ObjectType => ObjectTypes.Activity;
    }
}
