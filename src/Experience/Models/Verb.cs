using System;

namespace Experience.Models {
    public class Verb : IEquatable<Verb> {
        public Verb() {
        }

        public Verb(string id, Language display) {
            Id = id;
            Display = display;
        }

        public Verb(Verb value) {
            Id = value.Id;
            Display = value.Display;
        }

        public Verb(VerbExtensionDelegate verb)
            : this(verb()()) {
        }

        public string Id { get; }

        public Language Display { get; }

        public override string ToString() {
            return string.Format("{0}@{1}", Id, Display);
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public bool Equals(Verb other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            if (ReferenceEquals(this, other)) {
                return true;
            }

            return Id.Equals(other.Id, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            if (obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((Verb)obj);
        }
    }

    public interface IVerbExtension { }

    public delegate Func<Verb> VerbExtensionDelegate(IVerbExtension extension = null);

    public static partial class VerbExtensions {
        internal static readonly Verb _answered = new Verb(id: "http://adlnet.gov/expapi/verbs/answered", display: "answered");
        internal static readonly Verb _attempted = new Verb(id: "http://adlnet.gov/expapi/verbs/attempted", display: "attempted");
        internal static readonly Verb _attended = new Verb(id: "http://adlnet.gov/expapi/verbs/attended", display: "attended");
        internal static readonly Verb _completed = new Verb(id: "http://adlnet.gov/expapi/verbs/completed", display: "completed");
        internal static readonly Verb _experienced = new Verb(id: "http://adlnet.gov/expapi/verbs/experienced", display: "experienced");
        internal static readonly Verb _failed = new Verb(id: "http://adlnet.gov/expapi/verbs/failed", display: "failed");
        internal static readonly Verb _imported = new Verb(id: "http://adlnet.gov/expapi/verbs/imported", display: "imported");
        internal static readonly Verb _interacted = new Verb(id: "http://adlnet.gov/expapi/verbs/interacted", display: "interacted");
        internal static readonly Verb _passed = new Verb(id: "http://adlnet.gov/expapi/verbs/passed", display: "passed");
        internal static readonly Verb _shared = new Verb(id: "http://adlnet.gov/expapi/verbs/shared", display: "shared");

        public static Verb Answered<T>(this T source) where T : IVerbExtension {
            return _answered;
        }

        public static Verb Attempted<T>(this T source) where T : IVerbExtension {
            return _attempted;
		}

		public static Verb Attended<T>(this T source) where T : IVerbExtension {
            return _attempted;
		}

		public static Verb Completed<T>(this T source) where T : IVerbExtension {
            return _completed;
		}        

		public static Verb Experienced<T>(this T source) where T : IVerbExtension {
            return _experienced;
		}

		public static Verb Failed<T>(this T source) where T : IVerbExtension {
            return _failed;
		}

		public static Verb Imported<T>(this T source) where T : IVerbExtension {
            return _imported;
		}

		public static Verb Interacted<T>(this T source) where T : IVerbExtension {
            return _interacted;
		}

		public static Verb Passed<T>(this T source) where T : IVerbExtension {
            return _passed;
		}

		public static Verb Shared<T>(this T source) where T : IVerbExtension {
            return _shared;
		}
    }
}