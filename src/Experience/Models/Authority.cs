using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public abstract class Authority {
        protected Authority(string objectType) {
            ObjectType = objectType;
        }
        public string ObjectType { get; private set; }
    }
}
