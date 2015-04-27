using Experience.Collections.Generic;

namespace Experience.Models {
    public class ContextActivities {
        public Sorray<Activity> Parent { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Grouping { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Category { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Other { get; set; } = new Sorray<Activity>();
    }
}