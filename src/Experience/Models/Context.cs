﻿using System;

namespace Experience.Models {
    public class Context {
        public Guid Registration { get; set; }

        public object Instructor { get; set; }

        public object Team { get; set; }

        public ContextActivities ContextActivities { get; set; } = new ContextActivities();

        public string Revision { get; set; }

        public string Platform { get; set; }

        public string Language { get; set; }

        public object Statement { get; set; }

        public object Extensions { get; set; }
    }
}
