using Experience.Builders;
using Experience.Models;
using System;

namespace Experience {
    public static partial class Extensions {
		public static IStatementBuilder Verb(this IStatementBuilder builder, Func<IVerbBuilder,Func<Verb>> verb) {
			return builder.Verb(verb((IVerbBuilder)null)());
		}
	}
}