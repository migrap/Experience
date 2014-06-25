using Experience.Models;
using System;

namespace Experience.Builders {
    public interface IStatementBuilder {
        IStatementBuilder Uuid(string value);
        IStatementBuilder Verb(Verb value);
        IStatementBuilder Limit(int value = 0);
        IStatementBuilder Attachments(bool value = true);
		IStatementBuilder Ascending(bool value = true);
		IStatementBuilder RelatedActivities(bool value=true);
		IStatementBuilder RelatedAgents(bool value=true);
		IStatementBuilder Since(DateTimeOffset value);
		IStatementBuilder Until(DateTimeOffset value);
    }
}