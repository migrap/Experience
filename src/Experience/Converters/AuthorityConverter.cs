using Experience.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Experience.Converters {
    public class AuthorityConverter : JsonCreationConverter<Authority> {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public AuthorityConverter() : this(
            x => x.Name("Account").Type<Account>(), 
            x => x.Name("Group").Type<Group>()) {
        }

        public AuthorityConverter(params Action<IAuthorityConverterBuilder>[] builders) {
            foreach(var builder in builders) {
                var result = Factory<IAuthorityConverterBuilder, AuthorityConverterBuilder>(builder).Build();
                _types.Add(result.Key, result.Value);
            }
        }

        protected override Type GetType(Type objectType, JObject jObject) {
            if(_types.TryGetValue(GetType(jObject),out Type type)) {
                return type;
            }
            throw new Exception();
        }

        private static string GetType(JObject jObject) {
            return jObject["ObjectType"].ToObject<string>();
        }

        private static TResult Factory<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
            var result = new TResult();
            configure(result);
            return result;
        }
    }

    public interface IAuthorityConverterBuilder {
        IAuthorityConverterBuilder Name(string value);
        IAuthorityConverterBuilder Type(Type value);
    }

    internal class AuthorityConverterBuilder : IAuthorityConverterBuilder {
        private string _name;
        private Type _type;
        IAuthorityConverterBuilder IAuthorityConverterBuilder.Name(string value) {
            _name = value;
            return this;
        }

        IAuthorityConverterBuilder IAuthorityConverterBuilder.Type(Type value) {
            _type = value;
            return this;
        }

        public KeyValuePair<string,Type> Build() {
            return new KeyValuePair<string, Type>(_name, _type);
        }
    }

    public static partial class Extensions {
        public static IAuthorityConverterBuilder Type<T>(this IAuthorityConverterBuilder builder) {
            return builder.Type(typeof(T));
        }

        
    }
}
