using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Context {
        public Guid Registration { get; set; }

        public object Instructor { get; set; }

        public object Team { get; set; }

        public ContextActivities ContextActivities { get;set; }

        public string Revision { get; set; }

        public string Platform { get; set; }

        public string Language { get; set; }

        public object Statement { get; set; }

        public object Extensions { get; set; }
    }
}
