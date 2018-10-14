using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {
	public enum JsonType { Object, Array, String, Simple };

	public partial class Json {
		private static CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
		private Dictionary<string, Json> _obj;
		private List<Json> _array;
		private string _string;
		private string _simple;

		private Json() {

		}

		private static Json CreateString(string str) {
			return new Json { _string = str };
		}

		private static Json CreateSimple(string simple) {
			return new Json { _simple = simple };
		}

		public static Json CreateObject() {
			return new Json { _obj = new Dictionary<string, Json>() };
		}

		public static Json CreateArray() {
			return new Json { _array = new List<Json>() };
		}

		public JsonType Type {
			get {
				if (_obj != null) return JsonType.Object;
				if (_array != null) return JsonType.Array;
				if (_string != null) return JsonType.String;
				return JsonType.Simple;
			}
		}

		public override string ToString() {
			return ToString(false);
		}

	}
}
