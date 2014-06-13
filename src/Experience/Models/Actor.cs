using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Actor {
        public string Type { get; set; }
        public string Name { get; set; }
        public dynamic Value { get; internal set; } 
    }
}
