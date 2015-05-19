using Experience.Collections.Generic;

namespace Experience.Models {
    public class ContextActivities {
        public Sorray<Activity> Parent { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Grouping { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Category { get; set; } = new Sorray<Activity>();
        public Sorray<Activity> Other { get; set; } = new Sorray<Activity>();
    }

    public static partial class ContextActivitiesExtensions {
        public static ContextActivities AddCategory(this ContextActivities source, Activity activity) {
            source.Category.Add(activity);
            return source;
        }

        public static ContextActivities AddParent(this ContextActivities source, Activity activity) {
            source.Parent.Add(activity);
            return source;
        }

        public static ContextActivities AddGrouping(this ContextActivities source, Activity activity) {
            source.Grouping.Add(activity);
            return source;
        }

        public static ContextActivities AddOther(this ContextActivities source, Activity activity) {
            source.Other.Add(activity);
            return source;
        }
    }
}