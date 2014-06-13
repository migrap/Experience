using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Builders {
    internal class StatementBuilder : IStatementBuilder {
        public HttpRequestMessage Build() {
            return (HttpRequestMessage)null;
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
            return this;
        }

        IStatementBuilder IStatementBuilder.Verb(Verb value) {
            return this;
        }
    }
}