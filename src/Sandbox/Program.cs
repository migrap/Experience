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
using System.Linq;
using System.Dynamic;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using Experience.Converters;

namespace Sandbox {


	class MainClass {
		public static void Main(string[] args) {
            var verb = new Verb(x => x.Experienced);

            var stmt = new Statement();
            stmt.Actor(x => x.Agent(name: "", mbox: ""));
            stmt.Verb(x => x.Experienced);

            stmt.Actor = new Agent(name: "Test User", mbox: "mailto:test@beta.projecttincan.com");
            stmt.Verb = new Verb(x => x.Experienced);
            stmt.Context = new Context {
                Registration = Guid.NewGuid(),                
            };

            stmt.Context.ContextActivities.Grouping.Add(new Activity {
                Id = "http://id.tincanapi.com/activity/tincan-prototypes",
            });

            stmt.Context.ContextActivities.Category.Add(new Activity {
                Id = "http://id.tincanapi.com/recipe/tincan-prototypes/launcher/1",
                Definition = new Definition {
                    Type = "http://id.tincanapi.com/activitytype/recipe"
                }
            });

            stmt.Context.ContextActivities.Category.Add(new Activity {
                Id = "http://id.tincanapi.com/activity/tincan-prototypes/launcher-template",
                Definition = new Definition {
                    Name = "Tin Can Launcher Template",
                    Type = "http://id.tincanapi.com/activitytype/source"
                },
            });

            stmt.Object = new Activity {
                Id = "http://id.tincanapi.com/activity/tincan-prototypes/launcher",
                Definition = new Definition {
                    Name = "Tin Can Prototypes Launcher",
                    Description="A tool for launching the Tin Can prototypes. Simulates the role of an LMS in launching experiences.",
                    Type = "http://id.tincanapi.com/activitytype/lms"
                },                                
            };

            stmt.Stored = DateTimeOffset.UtcNow;
            stmt.Timestamp = DateTimeOffset.UtcNow;

            var settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.ContractResolver = new ExperienceCamelCasePropertyNamesContractResolver();
            settings.NullValueHandling = NullValueHandling.Ignore;

            var json = JsonConvert.SerializeObject(stmt, settings);

            System.Console.WriteLine(json);

            var ci = CultureInfo.GetCultureInfo("en-US");

            //var authority = "{\"authority\":{\"account\":{\"homePage\":\"http://cloud.scorm.com/\",\"name\":\"anonymous\"},\"objectType\":\"Agent\"}}";
            //var a = Newtonsoft.Json.JsonConvert.DeserializeObject<Authority>(authority);

            //var json = "{\"id\":\"dac6f1e4-d670-45e0-9bf8-288289748d02\",\"actor\":{\"name\":\"Mr Coyle\",\"mbox\":\"mailto:mr@coyle.com\",\"objectType\":\"Agent\"},\"verb\":{\"id\":\"http://adlnet.gov/expapi/verbs/attempted\",\"display\":{\"en-US\":\"attempted\"}},\"context\":{\"contextActivities\":{\"grouping\":[{\"id\":\"http://tincanapi.com/GolfExample_TCAPI\",\"objectType\":\"Activity\"}]}},\"timestamp\":\"2014-06-23T23:34:11.265Z\",\"stored\":\"2014-06-23T23:34:11.882Z\",\"authority\":{\"account\":{\"homePage\":\"http://cloud.scorm.com/\",\"name\":\"anonymous\"},\"objectType\":\"Agent\"},\"version\":\"1.0.0\",\"object\":{\"id\":\"http://tincanapi.com/GolfExample_TCAPI\",\"definition\":{\"name\":{\"en-US\":\"Golf Example - Tin Can Course\"},\"description\":{\"en-US\":\"An overview of how to play the great game of golf.\"},\"type\":\"http://adlnet.gov/expapi/activities/course\"},\"objectType\":\"Activity\"}}";

            

            //statement.Context.ContextActivities.Category = new Activity();



			var client = new HttpClient();
			client.BaseAddress = new Uri("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/");
			client.DefaultRequestHeaders.Authorization("test", "test");
			client.DefaultRequestHeaders.Add("X-Experience-API-Version", "1.0.1");
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statement"	string
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=10}	System.Uri
            ////http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=25&related_activities=false&related_agents=false
            //var result = default(Task<HttpResponseMessage>);

            //var sr = client.PostAsync(statement: s => s
            //    .Actor(stmt.Actor)
            //    .Verb(stmt.Verb)
            //    .Object()
            //);

            client.PostAsync(() => new ObjectContent<Statement>(stmt, new JsonMediaTypeFormatter { SerializerSettings = settings }));

            //var pr = client.PostAsync(statement: s => s
            //  .Actor("here@home.com")
            //  .Verb(verb => verb.Completed)
            //  .Object()
            //).Result;            

            //result.Wait();

            //var content = result.Result.Content.ReadAsStringAsync().Result;

            //var got = client.GetAsync(statement: s => s
            //		   .Verb(x => x.Answered)
            //		   .Limit(10));

            var response = client.GetAsync("http://cloud.scorm.com/ScormEngineInterface/TCAPI/public/statements?limit=250&related_activities=false&related_agents=false");
            var result = response.Result.Content.ReadAsStringAsync().Result;
            var statement = (Statement)null;

            var jobj = (JObject)JsonConvert.DeserializeObject(result);
            var statements = jobj["statements"].OfType<JObject>().Select(x => x.ToObject<Statement>());
            //foreach(var item in jobj["statements"]) {
            //    json = JsonConvert.SerializeObject(item);
            //    //json = json.Replace("und", "en-US");
            //    try {
            //        statement = Newtonsoft.Json.JsonConvert.DeserializeObject<Statement>(json);
            //        Console.WriteLine(statement);
            //    }catch(Exception ex) {
            //        Console.WriteLine(ex.Message);
            //    }
            //}


            Console.WriteLine(result);

			Console.ReadLine();
		}
	}

    public delegate Statement PostStatementDelegate(Actor actor, Verb verb, Object @object, Object result = null, Object context = null, DateTimeOffset? timestamp = null, Authority authority = null, Object attachments = null);

    public static partial class Extensions {

        public static void xPostAsync(this HttpClient client, Func<PostStatementDelegate, Statement> statement) {
            statement((actor, verb, obj, result, context, timestamp, authority, attachements) => {
                return (Statement)null;
            });
        }

        public static void Authorization(this HttpRequestHeaders headers, string username, string password) {
            headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(String.Format("{0}:{1}", username, password))));
        }

        public static string ObjectType(this Statement statement, ObjectTypeExtensionDelegate value) {
            return value()();
        }

        public static void Actor(this Statement statement, Func<Statement,Actor> actor) {
            statement.Actor = actor(statement);
        }        

        public static Agent Agent(this Statement statement, string name, string mbox) {
            return new Agent(name, mbox);
        }

        public static void Verb(this Statement statement, VerbExtensionDelegate verb) {
            statement.Verb = verb()();
        }
    }

    public interface IStatementExtension : IVerbExtension { }

    public class ExperienceCamelCasePropertyNamesContractResolver : CamelCasePropertyNamesContractResolver {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if(property.DeclaringType == typeof(Statement) && property.PropertyType == typeof(AttachmentCollection)) {
                property.ShouldSerialize = instance => {
                    return (instance as Statement).Attachment.Any();
                };
            }

            if(property.DeclaringType == typeof(ContextActivities) && typeof(IEnumerable<Activity>).IsAssignableFrom(property.PropertyType)) {
                property.ShouldSerialize = instance => {
                    var value = typeof(ContextActivities).GetPropertyIgnoringCase(property.PropertyName).GetValue(instance);
                    return (value as IEnumerable<Activity>).Any();
                };
            }

            if(typeof(InverseFunctionalIdentifier).IsAssignableFrom(property.DeclaringType) && property.PropertyName.Equals("Shasum")) {
                property.PropertyName = "mbox_sha1sum";
            }

            if(typeof(Language).IsAssignableFrom(property.PropertyType)) {
                property.Converter = new LanguageConverter();
            }

            return property;
        }
    }

    public static partial class Extensions {
        public static bool Any<TSource>(this IEnumerable<TSource> source) {
            return null != source && Enumerable.Any(source);
        }

        public static PropertyInfo GetPropertyIgnoringCase(this Type type, string name) {
            return type.GetProperty(name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}


