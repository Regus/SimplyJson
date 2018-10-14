using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {

	public partial class Json {
		
		private string ObjectToString(int depth) {
			StringBuilder builder = new StringBuilder();
			builder.Append("{");
			bool first = true;
			foreach (var pair in _obj) {
				if (!first) {
					builder.Append(",");
				}
				if (depth >= 0) {
					builder.AppendLine();
					for (int i = 0; i < depth; i++) {
						builder.Append("\t");
					}
				}
				builder.Append("\"");
				builder.Append(pair.Key);
				builder.Append("\":");
				if (depth >= 0) {
					builder.Append(" ");
				}
				builder.Append(pair.Value.ToString(depth >= 0 ? depth + 1 : -1));
				first = false;
			}
			if (depth >= 0) {
				builder.AppendLine();
				for (int i = 0; i < depth - 1; i++) {
					builder.Append("\t");
				}
			}
			builder.Append("}");
			return builder.ToString();
		}

		private string ArrayToString(int depth) {
			StringBuilder builder = new StringBuilder();
			builder.Append("[");
			bool first = true;
			foreach (Json value in _array) {
				if (!first) {
					builder.Append(",");
				}
				if (depth >= 0) {
					builder.AppendLine();
					for (int i = 0; i < depth; i++) {
						builder.Append("\t");
					}
				}
				if (value.Type == JsonType.Object || value.Type == JsonType.Array) {
					builder.Append(value.ToString(depth >= 0 ? depth + 1 : -1));
				}
				else {
					builder.Append(value.ToString(depth));
				}
				first = false;
			}
			if (depth >= 0) {
				builder.AppendLine();
				for (int i = 0; i < depth - 1; i++) {
					builder.Append("\t");
				}
			}
			builder.Append("]");
			return builder.ToString();
		}

		public string ToString(int depth) {
			switch (Type) {
				case JsonType.Object:
					return ObjectToString(depth);
				case JsonType.Array:
					return ArrayToString(depth);
				case JsonType.String:
					return "\"" + _string + "\"";
				case JsonType.Simple:
					return _simple;
			}
			return "";
		}

		public string ToString(bool indent = false) {
			return ToString(indent ? 1 : -1);
		}
	}
}
