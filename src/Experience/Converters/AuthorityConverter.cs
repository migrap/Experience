using Experience.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Experience.Converters {
    public class AuthorityConverter : JsonCreationConverter<Authority> {
        private Dictionary<string, Type> _types = new Dictionary<string, Type>();

        public AuthorityConverter() : this(x => x.Add<Agent>(), x => x.Add<Group>()) {
        }

        public AuthorityConverter(params Action<IAuthorityConverterBuilder>[] builders) {
            foreach(var builder in builders) {
                var result = Factory<IAuthorityConverterBuilder, AuthorityConverterBuilder>(builder).Build();
                _types.Add(result.Key, result.Value);
            }
        }

        protected override Type GetType(Type objectType, JObject jObject) {
            var type = (Type)null;
            if(_types.TryGetValue(GetType(jObject), out type)) {
                return type;
            }
            throw new Exception();
        }

        private static string GetType(JObject jObject) {
            return jObject["objectType"].ToObject<string>();
        }

        private static TResult Factory<TSource, TResult>(Action<TSource> configure) where TResult : TSource, new() {
            var result = new TResult();
            configure(result);
            return result;
        }
    }

    public interface IAuthorityConverterBuilder {
        void Add<T>(string name = null);
    }

    internal class AuthorityConverterBuilder : IAuthorityConverterBuilder {
        private string _name;
        private Type _type;

        void IAuthorityConverterBuilder.Add<T>(string name) {
            _type = typeof(T);
            _name = name ?? typeof(T).Name;
        }

        public KeyValuePair<string, Type> Build() {
            return new KeyValuePair<string, Type>(_name, _type);
        }
    }
}