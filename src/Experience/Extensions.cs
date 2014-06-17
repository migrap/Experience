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

		public static Task<HttpResponseMessage> Get(this HttpClient client, Action<IStatementBuilder> statement = null) {
			return client.SendAsync(request: Factory<IStatementBuilder, GetStatementBuilder>(statement).Build());
        }

		public delegate HttpRequestMessage GetStatement(string verb=null, int? limit=null, string actor=null);

		public static Task<HttpResponseMessage> Get(this HttpClient client, Func<GetStatement,HttpRequestMessage> statement=null){
			var request = statement((verb, limit,actor) => {
				return (HttpRequestMessage)null;
			});
			return client.SendAsync(request);
		}
			
		public delegate HttpRequestMessage PostStatement(string verb=null, string actor=null);

		public static Task<HttpResponseMessage> Post(this HttpClient client, Func<Func<string,string,HttpRequestMessage>,HttpRequestMessage> statement=null){
			var request = statement((verb, actor) => {
				return (HttpRequestMessage)null;
			});
			return client.SendAsync(request);
		}
    }
}