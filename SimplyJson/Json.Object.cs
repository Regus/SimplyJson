using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {
	public partial class Json {

		public List<string> Keys {
			get {
				if (_obj == null) {
					throw new JsonException($"{Type} is not an Object");
				}
				return _obj.Keys.ToList();
			}
		}

		public bool Has(string key) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			return _obj.ContainsKey(key);
		}

		public Json this[string key] {
			get {
				if (_obj == null) {
					throw new JsonException($"{Type} is not an Object");
				}
				return _obj[key];
			}
		}

		public Json Delete(string key) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj.Remove(key);
			return this;
		}


		public Json Object(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var result = _obj[name];
			if (result.Type != JsonType.Object) {
				throw new JsonException($"{name} ({result.Type}) is not an Object");
			}
			return result;
		}

		public Json Object(string name, Json obj) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			if (obj.Type != JsonType.Object) {
				throw new JsonException($"Argument 'obj' ({obj.Type}) is not an Object");
			}
			_obj[name] = obj;
			return this;
		}

		public Json NewObject(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateObject();
			return this;
		}

		public Json Array(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var result = _obj[name];
			if (result.Type != JsonType.Array) {
				throw new JsonException($"{name} ({result.Type}) is not an Array");
			}
			return result;
		}

		public Json Array(string name, Json array) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			if (array.Type != JsonType.Array) {
				throw new JsonException($"{name} ({array.Type}) is not an Array");
			}
			_obj[name] = array;
			return this;
		}

		public Json NewArray(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateArray();
			return this;
		}

		public string String(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return item._string;
			}
			if (item.Type != JsonType.Simple) {
				return item._simple;
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a string");
			}
		}

		public Json String(string name, string item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateString(item);
			return this;
		}

		public bool Boolean(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return bool.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return item._simple == "true";
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Boolean");
			}
		}

		public Json Boolean(string name, bool item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item ? "true" : "false");
			return this;
		}

		public sbyte SByte(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return sbyte.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return sbyte.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a SByte");
			}
		}

		public Json SByte(string name, sbyte item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public byte Byte(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return byte.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return byte.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Byte");
			}
		}

		public Json Byte(string name, byte item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public short Int16(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return short.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return short.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Int16");
			}
		}

		public Json Int16(string name, short item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public ushort UInt16(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return ushort.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return ushort.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a UInt16");
			}
		}

		public Json UInt16(string name, ushort item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public int Int32(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return int.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return int.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Int32");
			}
		}

		public Json Int32(string name, int item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public uint UInt32(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return uint.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return uint.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a UInt32");
			}
		}

		public Json UInt32(string name, uint item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString());
			return this;
		}

		public long Int64(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return long.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return long.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Int64");
			}
		}

		public Json Int64(string name, long item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			if (item >= -9007199254740991 && item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_obj[name] = CreateSimple(item.ToString());
			}
			else {
				_obj[name] = CreateString(item.ToString());
			}
			return this;
		}

		public ulong UInt64(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return ulong.Parse(item._string);
			}
			if (item.Type != JsonType.Simple) {
				return ulong.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a UInt64");
			}
		}

		public Json UInt64(string name, ulong item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			if (item <= 9007199254740991) { // max safe integer in javascript (2^53-1)
				_obj[name] = CreateSimple(item.ToString());
			}
			else {
				_obj[name] = CreateString(item.ToString());
			}
			return this;
		}

		public float Single(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return float.Parse(item._string, enUS);
			}
			if (item.Type != JsonType.Simple) {
				return float.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Single");
			}
		}

		public Json Single(string name, float item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString(enUS));
			return this;
		}

		public double Double(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return double.Parse(item._string, enUS);
			}
			if (item.Type != JsonType.Simple) {
				return double.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Double");
			}
		}

		public Json Double(string name, double item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateSimple(item.ToString(enUS));
			return this;
		}

		public decimal Decimal(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return decimal.Parse(item._string, enUS);
			}
			if (item.Type != JsonType.Simple) {
				return decimal.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a Decimal");
			}
		}

		public Json Decimal(string name, decimal item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			string str = item.ToString(enUS);
			if (str.Length <= 15) { // definitely safe
				_obj[name] = CreateSimple(str);
			}
			else {
				_obj[name] = CreateString(str);
			}
			return this;
		}

		public DateTime DateTime(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			var item = _obj[name];
			if (item.Type != JsonType.String) {
				return System.DateTime.Parse(item._string, null, DateTimeStyles.AdjustToUniversal);
			}
			else {
				throw new JsonException($"Cannot convert {name} ({item.Type}) to a DateTime");
			}
		}

		public Json DateTime(string name, DateTime item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = CreateString(item.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
			return this;
		}

		public Json Value(string name) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			return _obj[name];
		}

		public Json Value(string name, Json item) {
			if (_obj == null) {
				throw new JsonException($"{Type} is not an Object");
			}
			_obj[name] = item;
			return this;
		}
	}
}
