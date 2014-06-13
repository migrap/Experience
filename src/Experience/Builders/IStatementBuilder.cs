using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Builders {
    public interface IStatementBuilder {
        IStatementBuilder Uuid(string value);
        IStatementBuilder Verb(Verb value);
        IStatementBuilder Limit(int value = 0);
        IStatementBuilder Attachments(bool value = false);
        IStatementBuilder Ascending(bool value = false);
    }
}