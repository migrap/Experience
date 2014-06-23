﻿using System;
using System.Net.Http;
using Experience;
using System.Net.Http.Headers;
using System.Text;
using Experience.Models;
using System.Threading.Tasks;

namespace Sandbox {


	class MainClass {
		public static void Main(string[] args) {
            var statement = new Statement { };
            statement.Verb = new Verb { Id = "http://adllnet.gov/expapi/verbs/created", Display = new Language("en-US", "created") };
            statement.Actor = new Agent {
                Ifi = new InverseFunctionalIdentifier {
                    Mbox="here@home.com",
                }
            };



			var client = new HttpClient();
			client.BaseAddress = new Uri("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/");
			client.DefaultRequestHeaders.Authorization("test", "test");
			client.DefaultRequestHeaders.Add("X-Experience-API-Version", "1.0.0");
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statement"	string
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=10}	System.Uri
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=25&related_activities=false&related_agents=false
			var result = default(Task<HttpResponseMessage>);

			result = client.PostAsync(statement: s => s
			  .Actor("here@home.com")
			  .Verb(verb => verb.Completed)
			  .Object()
			);

			result.Wait();

			var content = result.Result.Content.ReadAsStringAsync().Result;

			var got = client.GetAsync(statement: s => s
					   .Verb(x => x.Answered)
					   .Limit(10));

            //client.Get(statement: s => s(verb: Verbs.Answered, actor: "", limit: 10));
            //client.Post(statement: s => s(verb: "", actor: ""));


            client.xPostAsync(statement: s => s(null, null, null));
		   

			Console.WriteLine(result);

			Console.ReadLine();
		}
	}

    

    

    public class Account : Authority {
        public Account() : base("Account") {
        }
    }

    public delegate Statement PostStatementDelegate(Actor actor, Verb verb, Object @object, Object result = null, Object context = null, DateTimeOffset? timestamp = null, Authority authority = null, Object attachments = null);

	public static partial class Extensions{

        public static void xPostAsync(this HttpClient client, Func<PostStatementDelegate,Statement> statement) {
            statement((actor, verb, obj, result, context, timestamp, authority, attachements) => {
                return (Statement)null;
            });
        }

		public static void Authorization(this HttpRequestHeaders headers,string username, string password){
			headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", username, password))));
		}
	}
}


