using System;

namespace Experience.Models {
	public struct Account {
		private string _value;

		private Account(string value) {
			_value = value;
		}

		public override string ToString() {
			return _value;
		}

		public static implicit operator string(Account value) {
			return value.ToString();
		}

		public static implicit operator Account(string value) {
			return new Account(value);
		}
	}
}