using System;
using System.Net.Http;
using Experience;
using System.Net.Http.Headers;
using System.Text;
using Experience.Models;

namespace Sandbox {


	class MainClass {
		public static void Main(string[] args) {
			var client = new HttpClient();
			client.BaseAddress = new Uri("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/");
			client.DefaultRequestHeaders.Authorization("test", "test");
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statement"	string
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=10}	System.Uri
			//http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=25&related_activities=false&related_agents=false

			var got = client.Get(statement: s => s
			           .Verb(x => x.Answered)
			           .Limit(10));

			client.Get(statement: s => s(verb: "", actor: "", limit: 10));
			//client.Post(statement: s => s(verb: "", actor: ""));

			//var result = got.Result.Content.ReadAsStringAsync().Result;
			//Console.WriteLine(result);

			Console.ReadLine();
		}
	}

	public static partial class Extensions{
		public static void Authorization(this HttpRequestHeaders headers,string username, string password){
			headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", username, password))));
		}



	}
}


