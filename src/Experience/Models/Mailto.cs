using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Mailto : Uri{
        private string _value;

        private Mailto(string value) : base(Create(value), UriKind.Absolute) {

        }

        public override string ToString() {
            return "mailto:" + _value;
        }

        public static implicit operator string(Mailto value) {
            return value.ToString();
        }

        public static implicit operator Mailto(string value) {
            return new Mailto(value);
        }

        private static string Create(string value) {
            return (value.StartsWith("mailto:")) ? value : "mailto:" + value;
        }
    }
}
