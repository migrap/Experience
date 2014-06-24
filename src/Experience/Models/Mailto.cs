﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Mailto : Uri {
        public Mailto(string value) : base(Create(value), UriKind.Absolute) {
        }

        public static implicit operator string (Mailto value) {
            return value.ToString();
        }

        public static implicit operator Mailto(string value) {
            return new Mailto(value);
        }

        private static string Create(string value) {
            return (value.StartsWith(Uri.UriSchemeMailto)) ? value : Uri.UriSchemeMailto + ":" + value;
        }
    }
}