using Experience.Converters;
using Newtonsoft.Json;
using System;

namespace Experience.Models {
    public class Verb {
        public Verb() {
        }

        public Verb(Verb value) {
            Id = value.Id;
            Display = value.Display;
        }

        public Verb(VerbExtensionDelegate verb)
            : this(verb()()) {
        }

        public string Id { get; set; }

        [JsonConverter(typeof(LanguageConverter))]
        public Language Display { get; set; }

        public override string ToString() {
            return string.Format("[Verb: Id={0}, Display={1}]", Id, Display);
        }
    }

    public interface IVerbFluent { }

    public interface IVerbExtension : IVerbFluent { }

    public delegate Func<Verb> VerbExtensionDelegate(IVerbExtension extension = null);

    public delegate Func<Verb> VerbBuilderDelegate(IVerbBuilder builder = null);

    public static partial class VerbExtensions {
        public static Verb Answered<T>(this T source) where T : IVerbFluent {
            return Verbs._answered;
        }

        public static Verb Attempted<T>(this T source) where T : IVerbFluent {
			return Verbs._attempted;
		}

		public static Verb Attended<T>(this T source) where T : IVerbFluent {
			return Verbs._attended;
		}

		public static Verb Completed<T>(this T source) where T : IVerbFluent {
			return Verbs._completed;
		}        

		public static Verb Experienced<T>(this T source) where T : IVerbFluent {
			return Verbs._experienced;
		}

		public static Verb Failed<T>(this T source) where T : IVerbFluent {
			return Verbs._failed;
		}

		public static Verb Imported<T>(this T source) where T : IVerbFluent {
			return Verbs._imported;
		}

		public static Verb Interacted<T>(this T source) where T : IVerbFluent {
			return Verbs._interacted;
		}

		public static Verb Passed<T>(this T source) where T : IVerbFluent {
			return Verbs._passed;
		}

		public static Verb Shared<T>(this T source) where T : IVerbFluent {
			return Verbs._shared;
		}
    }
}