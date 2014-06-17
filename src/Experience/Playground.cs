using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Experience;
using Experience.Builders;
using Experience.Models;

namespace Experience {
    internal static class Playground {
        static Playground() {
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

	public interface IAttachmentBuilder {
		IAttachmentBuilder Name(string value);
	}

	public class AttachmentBuilder : IAttachmentBuilder{
				IAttachmentBuilder IAttachmentBuilder.Name(string value){
					return this;
				}
	}

	public interface IStateBuilder{
		IStateBuilder ActivityUuid(string value);
		IStateBuilder Actor(dynamic value);
		IStateBuilder Registration(Guid value);
		IStateBuilder Since(DateTimeOffset value);
	}

	internal class StateBuilder:IStateBuilder{
		IStateBuilder IStateBuilder.ActivityUuid(string value) {
			return this;
		}
		IStateBuilder IStateBuilder.Actor(dynamic value) {
			return this;
		}
		IStateBuilder IStateBuilder.Registration(Guid value) {
			return this;
		}
		IStateBuilder IStateBuilder.Since(DateTimeOffset value) {
			return this;
		}
	}

    public static partial class Extensions {
        public static IStatementBuilder Actor(this IStatementBuilder builder, Action<IActorBuilder> value = null) {
            return builder;
        }


		public static IStatementBuilder Attachments(this IStatementBuilder builder, Action<IAttachmentBuilder> add = null){
			return builder;
		}

		public static void Get(this HttpClient client, Action<IStateBuilder> state = null) {
		}

		public static void Post(this HttpClient client, Action<IStateBuilder> state = null) {

		}
    }
}
