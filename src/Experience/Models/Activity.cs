using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Activity {
        public Uri Id { get; set; }
        public Definition Definition { get; set; }
        public string ObjectType {
            get { return "Activity"; }
        }
    }
}
