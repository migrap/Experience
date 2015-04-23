using System;
using System.Diagnostics;

namespace Experience.Models {
    [DebuggerDisplay("{DebuggerDisplay()}")]
    public sealed class Version : IEquatable<Version> {
        private readonly string _value;

        public Version(string value) {
            _value = value;
        }

        public static implicit operator string (Version value) {
            return value._value;
        }

        public static implicit operator Version(string value) {
            return new Version(value);
        }

        private string DebuggerDisplay() {
            return _value;
        }

        public override int GetHashCode() {
            return _value.ToLower().GetHashCode();
        }

        public bool Equals(Version other) {
            if(ReferenceEquals(null, other)) {
                return false;
            }
            if(ReferenceEquals(this, other)) {
                return true;
            }

            return string.Equals(this, other, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj) {
            if(ReferenceEquals(null, obj)) {
                return false;
            }
            if(ReferenceEquals(this, obj)) {
                return true;
            }
            if(obj.GetType() != this.GetType()) {
                return false;
            }

            return Equals((Version)obj);
        }
    }
}