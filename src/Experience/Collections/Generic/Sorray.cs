using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experience.Collections.Generic {
    public interface ISorray<T> : ICollection<T> {        
    }

    public class Sorray<T> : ISorray<T> {
        private ICollection<T> _collection;

        public Sorray() {
            _collection = new List<T>();
        }

        public Sorray(T item) {
            _collection = new List<T> { item };
        }

        public Sorray(IEnumerable<T> collection) {
            _collection = new List<T>(collection);
        }

        public Sorray(ICollection<T> collection) {
            _collection = collection;
        }

        public int Count {
            get { return _collection.Count; }
        }

        public bool IsReadOnly {
            get { return _collection.IsReadOnly; }
        }

        public void Add(T item) {
            _collection.Add(item);
        }

        public void Clear() {
            _collection.Clear();
        }

        public bool Contains(T item) {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex) {
            _collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() {
            return _collection.GetEnumerator();
        }

        public bool Remove(T item) {
            return _collection.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        public static implicit operator Sorray<T>(T item) {
            return new Sorray<T>(item);
        }

        public static implicit operator T(Sorray<T> value) {
            return value.FirstOrDefault();
        }
    }
}
