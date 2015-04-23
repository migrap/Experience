using System;
using System.Net.Http;
using Experience;
using System.Net.Http.Headers;
using System.Text;
using Experience.Models;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Sandbox {


	class MainClass {
		public static void Main(string[] args) {
            var ci = CultureInfo.GetCultureInfo("en-US");

            //var authority = "{\"authority\":{\"account\":{\"homePage\":\"http://cloud.scorm.com/\",\"name\":\"anonymous\"},\"objectType\":\"Agent\"}}";
            //var a = Newtonsoft.Json.JsonConvert.DeserializeObject<Authority>(authority);

            var json = "{\"id\":\"dac6f1e4-d670-45e0-9bf8-288289748d02\",\"actor\":{\"name\":\"Mr Coyle\",\"mbox\":\"mailto:mr@coyle.com\",\"objectType\":\"Agent\"},\"verb\":{\"id\":\"http://adlnet.gov/expapi/verbs/attempted\",\"display\":{\"en-US\":\"attempted\"}},\"context\":{\"contextActivities\":{\"grouping\":[{\"id\":\"http://tincanapi.com/GolfExample_TCAPI\",\"objectType\":\"Activity\"}]}},\"timestamp\":\"2014-06-23T23:34:11.265Z\",\"stored\":\"2014-06-23T23:34:11.882Z\",\"authority\":{\"account\":{\"homePage\":\"http://cloud.scorm.com/\",\"name\":\"anonymous\"},\"objectType\":\"Agent\"},\"version\":\"1.0.0\",\"object\":{\"id\":\"http://tincanapi.com/GolfExample_TCAPI\",\"definition\":{\"name\":{\"en-US\":\"Golf Example - Tin Can Course\"},\"description\":{\"en-US\":\"An overview of how to play the great game of golf.\"},\"type\":\"http://adlnet.gov/expapi/activities/course\"},\"objectType\":\"Activity\"}}";

            

            //statement.Context.ContextActivities.Category = new Activity();



			var client = new HttpClient();
			client.BaseAddress = new Uri("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/");
			client.DefaultRequestHeaders.Authorization("test", "test");
			client.DefaultRequestHeaders.Add("X-Experience-API-Version", "1.0.0");
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statement"	string
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=10}	System.Uri
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=25&related_activities=false&related_agents=false
            //var result = default(Task<HttpResponseMessage>);

            //result = client.PostAsync(statement: s => s
            //  .Actor("here@home.com")
            //  .Verb(verb => verb.Completed)
            //  .Object()
            //);

            //result.Wait();

            //var content = result.Result.Content.ReadAsStringAsync().Result;

            //var got = client.GetAsync(statement: s => s
            //		   .Verb(x => x.Answered)
            //		   .Limit(10));

            var response = client.GetAsync("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=250&related_activities=false&related_agents=false");
            var result = response.Result.Content.ReadAsStringAsync().Result;
            var statement = (Statement)null;

            var jobj = (JObject)JsonConvert.DeserializeObject(result);
            foreach(var item in jobj["statements"]) {
                json = JsonConvert.SerializeObject(item);
                //json = json.Replace("und", "en-US");
                try {
                    statement = Newtonsoft.Json.JsonConvert.DeserializeObject<Statement>(json);
                    Console.WriteLine(statement);
                }catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }


            Console.WriteLine(result);

			Console.ReadLine();
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


