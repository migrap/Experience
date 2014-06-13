using Experience.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Experience.Models;

namespace Experience {
    public static partial class Extensions {
        private static TResult Factory<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
            var result = new TResult();
            configure(result);
            return result;
        }

        public static void Get(this HttpClient client, Action<IStatementBuilder> statement = null) {
            Factory<IStatementBuilder, StatementBuilder>(statement).Build();
        }

        public static void Post(this HttpClient client, Action<IStatementBuilder> statement = null) {

        }
    }
}