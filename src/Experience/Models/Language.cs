﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Models {
    public class Language : Dictionary<CultureInfo, string> {
        public Language() {            
        }

        public Language(string value)
            : this(CultureInfo.CurrentCulture, value) {
        }

        public Language(CultureInfo cultureInfo, string value) {
            base.Add(cultureInfo, value);
        }

        public Language(string name, string value) : this(CultureInfo.GetCultureInfo(name), value) {
        }

        public static implicit operator Language(string value) {
            return new Language(value);
        }
    }
}
