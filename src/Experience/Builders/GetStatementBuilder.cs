using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Experience.Builders {
	internal class GetStatementBuilder : IStatementBuilder {
		private Dictionary<string,object> _parameters = new Dictionary<string, object>();

		public HttpRequestMessage Build() {
			var uri = "statements";
			if(_parameters.Any()) {
				uri += "?";
				uri += string.Join("&", _parameters.Select(x => string.Format("{0}={1}", Uri.EscapeUriString(x.Key), Uri.EscapeUriString(x.Value.ToString()))));
			}

			return new HttpRequestMessage(HttpMethod.Get, new Uri(uri, UriKind.RelativeOrAbsolute));
		}

		IStatementBuilder IStatementBuilder.Ascending(bool value) {
			return this;
		}

		IStatementBuilder IStatementBuilder.Attachments(bool value) {
			return this;
		}

		IStatementBuilder IStatementBuilder.Uuid(string value) {
			return this;
		}

		IStatementBuilder IStatementBuilder.Limit(int value) {
			_parameters["limit"] = value;
			return this;
		}

		IStatementBuilder IStatementBuilder.Verb(Verb value) {
			_parameters["verb"] = value.Display.First().Value;
			return this;
		}

		IStatementBuilder IStatementBuilder.RelatedActivities(bool value) {
			_parameters["related_activities"] = value;
			return this;
		}

		IStatementBuilder IStatementBuilder.RelatedAgents(bool value) {
			_parameters["related_actors"] = value;
			return this;
		}

		IStatementBuilder IStatementBuilder.Since(DateTimeOffset value) {
			_parameters["since"] = value;
			return this;
		}

		IStatementBuilder IStatementBuilder.Until(DateTimeOffset value) {
			_parameters["until"] = value;
			return this;
		}
	}
}

