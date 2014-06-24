using Experience.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class ContextActivities {
        public Sorray<Activity> Parent { get; set; }
        public Sorray<Activity> Grouping { get; set; }
        public Sorray<Activity> Category { get; set; }
        public Sorray<Activity> Other { get; set; }
    }
}
