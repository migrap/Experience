﻿using Experience.Builders;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Experience {
    public static partial class Extensions {
		private static TResult Factory<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
			var result = new TResult();
			configure(result);
			return result;
		}

		public static Task<HttpResponseMessage> GetAsync(this HttpClient client, Action<IStatementBuilder> statement = null) {
			return client.SendAsync(request: Factory<IStatementBuilder, GetStatementBuilder>(statement).Build());
		}

        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, Action<IPostStatementBuilder> statement = null) {
            return client.SendAsync(request: Factory<IPostStatementBuilder, PostStatementBuilder>(statement).Build());
        }

		//public delegate HttpRequestMessage GetStatement(Func<Func<IVerbBuilder, Verb>> verb = null, int? limit = null, string actor = null);

		//public static Task<HttpResponseMessage> Get(this HttpClient client, Func<GetStatement,HttpRequestMessage> statement=null){
		//	var request = statement((verb, limit, actor) => {
		//		return (HttpRequestMessage)null;
		//	});
		//	return client.SendAsync(request);
		//}
			
		//public delegate HttpRequestMessage PostStatement(string verb=null, string actor=null);

		//public static Task<HttpResponseMessage> Post(this HttpClient client, Func<Func<string,string,HttpRequestMessage>,HttpRequestMessage> statement=null){
		//	var request = statement((verb, actor) => {
		//		return (HttpRequestMessage)null;
		//	});
		//	return client.SendAsync(request);
		//}
	}
}