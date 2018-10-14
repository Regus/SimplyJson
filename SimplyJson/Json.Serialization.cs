using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {
	public enum JsonSerializationFormat { AsIs, CamelCase, PascalCase };

	public partial class Json {
		public static JsonSerializationFormat SerializationFormat = JsonSerializationFormat.AsIs;

		private static string FormatName(string name, JsonSerializationFormat format) {
			switch (format) {
				case JsonSerializationFormat.AsIs:
					return name;
				case JsonSerializationFormat.CamelCase:
					return char.ToLower(name[0]) + name.Substring(1);
				case JsonSerializationFormat.PascalCase:
					return char.ToUpper(name[0]) + name.Substring(1);
				default:
					throw new NotImplementedException($"Serialization format {format} not implemented");
			}
		}

		public static Json Serialize(object item) {
			return Serialize(item, SerializationFormat);
		}

		public static Json Serialize(object item, JsonSerializationFormat format) {
			var type = item.GetType();
			Json json;
			if (typeof(IDictionary).IsAssignableFrom(type)) {
				json = CreateObject();
				foreach (DictionaryEntry pair in (IDictionary)item) {
					string name = pair.Key.ToString();
					var value = pair.Value;
					if (value != null) {
						SetValue(json, value.GetType(), name, value);
					}
				}
			}
			else if (typeof(ICollection).IsAssignableFrom(type)) {
				json = CreateArray();
				foreach (var entry in (ICollection)item) {
					if (entry != null) {
						AddValue(json, entry.GetType(), entry);
					}
				}
			}
			else {
				json = CreateObject();
				foreach (var prop in type.GetProperties()) {
					if (prop.GetCustomAttributes(false).FirstOrDefault(att => att is JsonIgnoreAttribute) == null) {
						var propType = prop.PropertyType;
						var name = FormatName(prop.Name, format);
						var value = prop.GetValue(item, new object[0]);
						if (value != null) {
							SetValue(json, propType, name, value);
						}
					}
				}
			}
			return json;
		}

		public T Deserialize<T>() where T : new() {
			return (T)Deserialize(typeof(T));
		}

		public object Deserialize(Type type) {
			Object obj = type.GetConstructor(new Type[0]).Invoke(null);
			if (typeof(IDictionary).IsAssignableFrom(type)) {
				foreach (string key in Keys) {
					MethodInfo method = type.GetMethod("Add");
					method.Invoke(obj, new object[] { key, GetValue(this, method.GetParameters()[1].ParameterType, key) });
				}
			}
			else if (typeof(ICollection).IsAssignableFrom(type)) {
				for (int i = 0; i < Count; i++) {
					MethodInfo method = type.GetMethod("Add");
					method.Invoke(obj, new object[] { GetValue(this, method.GetParameters()[0].ParameterType, i) });
				}
			}
			else {
				foreach (var prop in type.GetProperties()) {
					Dictionary<string, string> keyToKey = new Dictionary<string, string>();
					foreach (string key in Keys) {
						keyToKey.Add(key.ToLower(), key);
					}

					if (prop.GetCustomAttributes(false).FirstOrDefault(att => att is JsonIgnoreAttribute) == null) {
						var propType = prop.PropertyType;
						var name = prop.Name.ToLower();
						if (keyToKey.ContainsKey(name)) {
							prop.SetValue(obj, GetValue(this, propType, keyToKey[name]), new object[0]);
						}
					}
				}
			}
			return obj;
		}

		private static object GetValue(Json json, Type type, string name) {
			if (type == typeof(string)) {
				return json.String(name);
			}
			else if (type == typeof(bool)) {
				return json.Boolean(name);
			}
			else if (type == typeof(sbyte)) {
				return json.SByte(name);
			}
			else if (type == typeof(byte)) {
				return json.Byte(name);
			}
			else if (type == typeof(short)) {
				return json.Int16(name);
			}
			else if (type == typeof(ushort)) {
				return json.UInt16(name);
			}
			else if (type == typeof(int)) {
				return json.Int32(name);
			}
			else if (type == typeof(uint)) {
				return json.UInt32(name);
			}
			else if (type == typeof(long)) {
				return json.Int64(name);
			}
			else if (type == typeof(ulong)) {
				return json.UInt64(name);
			}
			else if (type == typeof(float)) {
				return json.Single(name);
			}
			else if (type == typeof(double)) {
				return json.Double(name);
			}
			else if (type == typeof(decimal)) {
				return json.Decimal(name);
			}
			else if (type == typeof(DateTime)) {
				return json.DateTime(name);
			}
			else if (type == typeof(Json)) {
				return json.Value(name);
			}
			else {
				return json.Value(name).Deserialize(type);
			}
		}

		private static object GetValue(Json json, Type type, int index) {
			if (type == typeof(string)) {
				return json.String(index);
			}
			else if (type == typeof(bool)) {
				return json.Boolean(index);
			}
			else if (type == typeof(sbyte)) {
				return json.SByte(index);
			}
			else if (type == typeof(byte)) {
				return json.Byte(index);
			}
			else if (type == typeof(short)) {
				return json.Int16(index);
			}
			else if (type == typeof(ushort)) {
				return json.UInt16(index);
			}
			else if (type == typeof(int)) {
				return json.Int32(index);
			}
			else if (type == typeof(uint)) {
				return json.UInt32(index);
			}
			else if (type == typeof(long)) {
				return json.Int64(index);
			}
			else if (type == typeof(ulong)) {
				return json.UInt64(index);
			}
			else if (type == typeof(float)) {
				return json.Single(index);
			}
			else if (type == typeof(double)) {
				return json.Double(index);
			}
			else if (type == typeof(decimal)) {
				return json.Decimal(index);
			}
			else if (type == typeof(DateTime)) {
				return json.DateTime(index);
			}
			else if (type == typeof(Json)) {
				return json.Value(index);
			}
			else {
				return json.Value(index).Deserialize(type);
			}
		}

		private static void SetValue(Json json, Type type, string name, object value) {
			if (type == typeof(string)) {
				json.String(name, (string)value);
			}
			else if (type == typeof(bool)) {
				json.Boolean(name, (bool)value);
			}
			else if (type == typeof(sbyte)) {
				json.SByte(name, (sbyte)value);
			}
			else if (type == typeof(byte)) {
				json.Byte(name, (byte)value);
			}
			else if (type == typeof(short)) {
				json.Int16(name, (short)value);
			}
			else if (type == typeof(ushort)) {
				json.UInt16(name, (ushort)value);
			}
			else if (type == typeof(int)) {
				json.Int32(name, (int)value);
			}
			else if (type == typeof(uint)) {
				json.UInt32(name, (uint)value);
			}
			else if (type == typeof(long)) {
				json.Int64(name, (long)value);
			}
			else if (type == typeof(ulong)) {
				json.UInt64(name, (ulong)value);
			}
			else if (type == typeof(float)) {
				json.Single(name, (float)value);
			}
			else if (type == typeof(double)) {
				json.Double(name, (double)value);
			}
			else if (type == typeof(decimal)) {
				json.Decimal(name, (decimal)value);
			}
			else if (type == typeof(DateTime)) {
				json.DateTime(name, (DateTime)value);
			}
			else if (type == typeof(Json)) {
				json.Value(name, (Json)value);
			}
			else {
				json.Value(name, Json.Serialize(value));
			}
		}

		private static void AddValue(Json json, Type type, object value) {
			if (type == typeof(string)) {
				json.Add((string)value);
			}
			else if (type == typeof(bool)) {
				json.Add((bool) value);
			}
			else if (type == typeof(sbyte)) {
				json.Add((sbyte)value);
			}
			else if (type == typeof(byte)) {
				json.Add((byte)value);
			}
			else if (type == typeof(short)) {
				json.Add((short)value);
			}
			else if (type == typeof(ushort)) {
				json.Add((ushort)value);
			}
			else if (type == typeof(int)) {
				json.Add((int)value);
			}
			else if (type == typeof(uint)) {
				json.Add((uint)value);
			}
			else if (type == typeof(long)) {
				json.Add((long)value);
			}
			else if (type == typeof(ulong)) {
				json.Add((ulong)value);
			}
			else if (type == typeof(float)) {
				json.Add((float)value);
			}
			else if (type == typeof(double)) {
				json.Add((double)value);
			}
			else if (type == typeof(decimal)) {
				json.Add((decimal)value);
			}
			else if (type == typeof(DateTime)) {
				json.Add((DateTime)value);
			}
			else if (type == typeof(Json)) {
				json.Add((Json)value);
			}
			else {
				json.Add(Json.Serialize(value));
			}
		}

	}
}
