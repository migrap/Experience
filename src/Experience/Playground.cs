using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Experience;
using Experience.Builders;
using Experience.Models;
using Experience.Extensions;

namespace Experience {
    internal static class Playground {
        static Playground() {
            (new HttpClient()).Get(statement: s => s
            .Uuid("")
            //.Verb(x => x.Answered)            
            .Limit(10)
            .Attachments()
            .Ascending()
            .Actor()             
           );

            (new HttpClient()).Post(statement: s => s
                .Uuid("")
            );
        }
    }

    public interface IActorBuilder {
        IActorBuilder Name(string value);
        IActorBuilder Type(string value="Agent");
        IActorBuilder Mbox(Mailto value);
    }

    internal class ActorBuilder : IActorBuilder {
        IActorBuilder IActorBuilder.Mbox(Mailto value) {
            throw new NotImplementedException();
        }

        IActorBuilder IActorBuilder.Name(string value) {
            throw new NotImplementedException();
        }

        IActorBuilder IActorBuilder.Type(string value) {
            throw new NotImplementedException();
        }
    }

    public static partial class Extensions {
        public static IStatementBuilder Actor(this IStatementBuilder builder, Action<IActorBuilder> value = null) {
            return builder;
        }

        public static IStatementBuilder Verb(this IStatementBuilder builder, Func<Verb> answered) {
            return builder;
        }
    }
}
