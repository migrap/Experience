using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experience.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace Experience.Builders {
    public interface IPostStatementBuilder {
        IPostStatementBuilder Actor(string value);
        IPostStatementBuilder Verb(Verb value);
        IPostStatementBuilder Object();
    }

    internal class PostStatementBuilder : IPostStatementBuilder {
        private JObject _jobject = new JObject();

        public PostStatementBuilder() {
            _jobject = new JObject(new JProperty("actor"), new JProperty("object"), new JProperty("verb")
                , new JProperty("id"), new JProperty("timestamp"), new JProperty("stored"), new JProperty("authority"), new JProperty("version"));

            _jobject["id"] = "3fd37a7d-2404-4dbd-a3f0-4288a4ed6614";
            _jobject["timestamp"] = "2014-06-19T00:32:54.783Z";
            _jobject["stored"] = "2014-06-19T00:32:54.783Z";
            _jobject["version"] = "1.0.0";
            _jobject["authority"] = new JObject(new JProperty("account"), new JProperty("objectType"));
            _jobject["authority"]["account"] = new JObject(new JProperty("homePage", "http://cloud.scorm.com/"), new JProperty("name", "anonymous"));
            _jobject["authority"]["objectType"] = "Agent";
        }

        public HttpRequestMessage Build() {
            var uri = "statements";
            var request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri, UriKind.RelativeOrAbsolute));
            request.Content = new StringContent(_jobject.ToString(), Encoding.UTF8, "application/json");
            return request;
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