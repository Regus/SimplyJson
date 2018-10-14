using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {
	public partial class Json {

		public static Json Parse(string json) {
			int index = 0;
			var tokens = JsonTokenizer.Tokenize(json);
			return new Json(tokens, ref index);
		}

		private Json(List<string> tokens, ref int index) {
			if (tokens[index] == "{") {
				ReadObject(tokens, ref index);
			}
			else if (tokens[index] == "[") {
				ReadArray(tokens, ref index);
			}
			else if (tokens[index].StartsWith("\"")) {
				ReadString(tokens, ref index);
			}
			else {
				ReadSimple(tokens, ref index);
			}
		}

		private void ReadObject(List<string> tokens, ref int index) {
			_obj = new Dictionary<string, Json>();
			for (; index < tokens.Count; index++) {
				if (tokens[index] == "}") {
					break;
				}
				index++;
				string name = tokens[index++];
				if (name.StartsWith("\"")) {
					name = name.Substring(1);
				}
				if (name == "}") {
					index--;
					break;
				}
				index++; // :
				if (!_obj.ContainsKey(name)) {
					_obj.Add(name, new Json(tokens, ref index));
				}
				else {
					throw new Exception($"Malformed JSON: Key '{name}' already exists.");
				}
			}
		}

		private void ReadArray(List<string> tokens, ref int index) {
			_array = new List<Json>();
			for (; index < tokens.Count; index++) {
				if (tokens[index] == "]") {
					break;
				}
				index++;
				string OValue = tokens[index];
				if (OValue == "]") {
					break;
				}
				_array.Add(new Json(tokens, ref index));
			}
		}

		private void ReadString(List<string> tokens, ref int index) {
			_string = tokens[index].Substring(1);
		}

		private void ReadSimple(List<string> tokens, ref int index) {
			_simple = tokens[index];
		}
		
	}
}
