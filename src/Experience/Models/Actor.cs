using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public abstract class Actor {
        public abstract string ObjectType { get; }
        public string Name { get; set; }
    }
}