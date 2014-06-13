using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience {
    public static partial class Extensions {
        internal static readonly Verb _answered = new Verb { Id = "http://adlnet.gov/expapi/verbs/answered", Display = "answered" };
        internal static readonly Verb _attempted = new Verb { Id = "http://adlnet.gov/expapi/verbs/attempted", Display = "attempted" };
        internal static readonly Verb _attended = new Verb { Id = "http://adlnet.gov/expapi/verbs/attended", Display = "attended" };
        internal static readonly Verb _completed = new Verb { Id = "http://adlnet.gov/expapi/verbs/completed", Display = "completed" };
        internal static readonly Verb _experienced = new Verb { Id = "http://adlnet.gov/expapi/verbs/experienced", Display = "experienced" };
        internal static readonly Verb _failed = new Verb { Id = "http://adlnet.gov/expapi/verbs/failed", Display = "failed" };
        internal static readonly Verb _imported = new Verb { Id = "http://adlnet.gov/expapi/verbs/imported", Display = "imported" };
        internal static readonly Verb _interacted = new Verb { Id = "http://adlnet.gov/expapi/verbs/interacted", Display = "interacted" };
        internal static readonly Verb _passed = new Verb { Id = "http://adlnet.gov/expapi/verbs/passed", Display = "passed" };
        internal static readonly Verb _shared = new Verb { Id = "http://adlnet.gov/expapi/verbs/shared", Display = "shared" };

        public static Verb Answered<T>(this T builder) {
            return _answered;
        }

        public static Verb Attempted<T>(this T builder) {
            return _attempted;
        }

        public static Verb Attended<T>(this T builder) {
            return _attended;
        }

        public static Verb Completed<T>(this T builder) {
            return _completed;
        }

        public static Verb Experienced<T>(this T builder) {
            return _experienced;
        }

        public static Verb Failed<T>(this T builder) {
            return _failed;
        }

        public static Verb Answered() {
            return _answered;
        }
    }
}
