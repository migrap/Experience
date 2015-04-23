using System;

namespace Experience.Models {
    public class Activity {
        public Uri Id { get; set; }
        public Definition Definition { get; set; }
        public string ObjectType => ObjectTypes.Activity;
    }
}
