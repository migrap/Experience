using Experience.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace Experience.Builders {
    public interface IPostStatementBuilder {
        IPostStatementBuilder Actor(Actor value);
        IPostStatementBuilder Actor(string value);
        IPostStatementBuilder Verb(Verb value);
        IPostStatementBuilder Object();
    }

    internal class PostStatementBuilder : IPostStatementBuilder {
        private JObject _jobject = new JObject();

        public PostStatementBuilder() {
            _jobject = new JObject(new JProperty("actor"), new JProperty("object"), new JProperty("verb"));                
        }

        public HttpRequestMessage Build() {
            var uri = "statements";
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri, UriKind.RelativeOrAbsolute));

            request.Content = new StringContent(_jobject.ToString(), Encoding.UTF8, "application/json");

            return request;
        }

        public IPostStatementBuilder Actor(Actor value) {
            _jobject["actor"] = new JObject(
                new JProperty("mbox", value.Mbox.ToString()),
                new JProperty("name", value.Name),
                new JProperty("objectType", value.ObjectType)
            );

            return this;
        }

        public IPostStatementBuilder Actor(string value) {
            _jobject["actor"] = new JObject(
                new JProperty("mbox", "mailto:here@home.com"),
                new JProperty("name", "Here"),
                new JProperty("objectType", "Agent")
            );

            return this;
        }

        public IPostStatementBuilder Object() {
            _jobject["object"] = new JObject(
                new JProperty("id", "http://www.example.com/tincan/activities/gLnvfUiJ"),
                new JProperty("objectType", "Activity"),
                new JProperty("definition")
            );

            _jobject["object"]["definition"] = new JObject(new JProperty("name"), new JProperty("description"));
            _jobject["object"]["definition"]["name"] = new JObject(new JProperty("en-US", "Example Activity"));
            _jobject["object"]["definition"]["description"] = new JObject(new JProperty("en-US", "Example activity definition"));

            return this;
        }

        public IPostStatementBuilder Verb(Verb value) {
            _jobject["verb"] = new JObject(
                new JProperty("id", "http://adlnet.gov/expapi/verbs/completed"),
                new JProperty("display")
            );

            _jobject["verb"]["display"] = new JObject(new JProperty("en-US", "completed"));

            return this;
        }
    }
}