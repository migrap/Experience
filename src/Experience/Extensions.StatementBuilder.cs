using Experience.Builders;
using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Experience {
    public static partial class Extensions {
        public static IStatementBuilder Verb(this IStatementBuilder builder, Func<IVerbBuilder,Func<Verb>> verb) {
			return builder.Verb(verb((IVerbBuilder)null)());
        }
    }
}