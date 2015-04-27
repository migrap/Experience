using System;

namespace Experience {
    internal static class ObjectTypes {
        public const string StatementRef = "StatementRef";
        public const string Agent = "Agent";
        public const string Group = "Group";
        public const string Activity = "Activity";
        public const string SubStatement = "SubStatement";
        public const string Person = "Person";
    }

    public interface IObjectTypeExtension { }

    public delegate Func<string> ObjectTypeExtensionDelegate(IObjectTypeExtension extension = null);

    public static partial class ObjectTypeExtensions {
        public static string Agent(this IObjectTypeExtension source) {
            return ObjectTypes.Agent;
        }

        public static string StatementRef(this IObjectTypeExtension source) {
            return ObjectTypes.StatementRef;
        }

        public static string Group(this IObjectTypeExtension source) {
            return ObjectTypes.Group;
        }

        public static string Activity(this IObjectTypeExtension source) {
            return ObjectTypes.Activity;
        }

        public static string SubStatement(this IObjectTypeExtension source) {
            return ObjectTypes.SubStatement;
        }

        public static string Person(this IObjectTypeExtension source) {
            return ObjectTypes.Person;
        }
    }    
}
