using Experience.Collections.Generic;

namespace Experience.Models {
    public class ContextActivities {
        public Sorray<Activity> Parent { get; set; }
        public Sorray<Activity> Grouping { get; set; }
        public Sorray<Activity> Category { get; set; }
        public Sorray<Activity> Other { get; set; }
    }
}
