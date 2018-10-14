using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson {

	public partial class Json {
		public Json Add(Json item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(item);
			return this;
		}

		public Json Add(string item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateString(item));
			return this;
		}

		public Json Add(bool item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item ? "true" : "false"));
			return this;
		}

		public Json Add(sbyte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(byte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(char item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateString(item.ToString()));
			return this;
		}

		public Json Add(short item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(ushort item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(int item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(uint item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString()));
			return this;
		}

		public Json Add(long item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item >= -9007199254740991 && item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_array.Add(CreateSimple(item.ToString()));
			}
			else {
				_array.Add(CreateString(item.ToString()));
			}
			return this;
		}

		public Json Add(ulong item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_array.Add(CreateSimple(item.ToString()));
			}
			else {
				_array.Add(CreateString(item.ToString()));
			}
			return this;
		}

		public Json Add(float item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString(enUS)));
			return this;
		}

		public Json Add(double item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateSimple(item.ToString(enUS)));
			return this;
		}

		public Json Add(decimal item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			string str = item.ToString(enUS);
			if (str.Length <= 15) { // definitely safe
				_array.Add(CreateSimple(str));
			}
			else {
				_array.Add(CreateString(str));
			}
			return this;
		}

		public Json Add(DateTime item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Add(CreateString(item.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
			return this;
		}

		public Json Insert(int index, Json item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, item);
			return this;
		}

		public Json Insert(int index, string item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateString(item));
			return this;
		}

		public Json Insert(int index, sbyte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, byte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, char item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateString(item.ToString()));
			return this;
		}

		public Json Insert(int index, short item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, ushort item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, int item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, uint item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString()));
			return this;
		}

		public Json Insert(int index, long item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item >= -9007199254740991 && item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_array.Insert(index, CreateSimple(item.ToString()));
			}
			else {
				_array.Insert(index, CreateString(item.ToString()));
			}
			return this;
		}

		public Json Insert(int index, ulong item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item <= 9007199254740991) { // max safe integer in javascript (2^53-1)
				_array.Insert(index, CreateSimple(item.ToString()));
			}
			else {
				_array.Insert(index, CreateString(item.ToString()));
			}
			return this;
		}

		public Json Insert(int index, float item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString(enUS)));
			return this;
		}

		public Json Insert(int index, double item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateSimple(item.ToString(enUS)));
			return this;
		}

		public Json Insert(int index, decimal item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			string str = item.ToString(enUS);
			if (str.Length <= 15) { // definitely safe
				_array.Insert(index, CreateSimple(str));
			}
			else {
				_array.Insert(index, CreateString(str));
			}
			return this;
		}

		public Json Insert(int index, DateTime item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.Insert(index, CreateString(item.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")));
			return this;
		}

		public Json Delete(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array.RemoveAt(index);
			return this;
		}

		public Json Object(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var result = _array[index];
			if (result.Type != JsonType.Object) {
				throw new JsonException($"Item at {index} ({result.Type}) is not an Object");
			}
			return result;
		}

		public Json Object(int index, Json obj) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (obj.Type != JsonType.Object) {
				throw new JsonException($"Argument 'obj' ({obj.Type}) is not an Object");
			}
			_array[index] = obj;
			return this;
		}

		public Json Array(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var result = _array[index];
			if (result.Type != JsonType.Array) {
				throw new JsonException($"Item at {index} ({result.Type}) is not an Array");
			}
			return result;
		}

		public Json Array(int index, Json array) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (array.Type != JsonType.Array) {
				throw new JsonException($"Argument 'array' ({array.Type}) is not an Array");
			}
			_array[index] = array;
			return this;
		}

		public Json Value(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			return _array[index];
		}

		public Json Value(int index, Json item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = item;
			return this;
		}

		public string String(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return item._string;
			}
			if (item.Type == JsonType.Simple) {
				return item._simple;
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a string");
			}
		}

		public Json String(int index, string item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateString(item);
			return this;
		}

		public bool Boolean(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return bool.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return item._simple == "true";
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Boolean");
			}
		}

		public Json Boolean(int index, bool item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item ? "true" : "false");
			return this;
		}

		public sbyte SByte(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return sbyte.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return sbyte.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a SByte");
			}
		}

		public Json SByte(int index, sbyte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}

		public byte Byte(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return byte.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return byte.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Byte");
			}
		}

		public Json Byte(int index, byte item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}


		public short Int16(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return short.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return short.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Int16");
			}
		}

		public Json Int16(int index, short item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}

		public ushort UInt16(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return ushort.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return ushort.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a UInt16");
			}
		}

		public Json UInt16(int index, ushort item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}

		public int Int32(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return int.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return int.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Int32");
			}
		}

		public Json Int32(int index, int item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}

		public uint UInt32(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return uint.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return uint.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a UInt32");
			}
		}

		public Json UInt32(int index, uint item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString());
			return this;
		}

		public long Int64(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return long.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return long.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Int64");
			}
		}

		public Json Int64(int index, long item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item >= -9007199254740991 && item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_array[index] = CreateSimple(item.ToString());
			}
			else {
				_array[index] = CreateString(item.ToString());
			}
			return this;
		}

		public ulong UInt64(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return ulong.Parse(item._string);
			}
			if (item.Type == JsonType.Simple) {
				return ulong.Parse(item._simple);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a UInt64");
			}
		}

		public Json UInt64(int index, ulong item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			if (item <= 9007199254740991) { // min/max safe integer in javascript (2^53-1)
				_array[index] = CreateSimple(item.ToString());
			}
			else {
				_array[index] = CreateString(item.ToString());
			}
			return this;
		}

		public float Single(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return ulong.Parse(item._string, enUS);
			}
			if (item.Type == JsonType.Simple) {
				return ulong.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Single");
			}
		}

		public Json Single(int index, float item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString(enUS));
			return this;
		}

		public double Double(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return double.Parse(item._string, enUS);
			}
			if (item.Type == JsonType.Simple) {
				return double.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Double");
			}
		}

		public Json Double(int index, double item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateSimple(item.ToString(enUS));
			return this;
		}

		public decimal Decimal(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return decimal.Parse(item._string, enUS);
			}
			if (item.Type == JsonType.Simple) {
				return decimal.Parse(item._simple, enUS);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a Decimal");
			}
		}

		public Json Decimal(int index, decimal item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			string str = item.ToString(enUS);
			if (str.Length <= 15) { // definitely safe
				_array[index] = CreateSimple(str);
			}
			else {
				_array[index] = CreateString(str);
			}
			return this;
		}

		public DateTime DateTime(int index) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			var item = _array[index];
			if (item.Type == JsonType.String) {
				return System.DateTime.Parse(item._string, null, DateTimeStyles.AdjustToUniversal);
			}
			else {
				throw new JsonException($"Cannot convert item at index {index} ({item.Type}) to a DateTime");
			}
		}

		public Json DateTime(int index, DateTime item) {
			if (_array == null) {
				throw new JsonException($"{Type} is not an Array");
			}
			_array[index] = CreateString(item.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
			return this;
		}

		public int Count {
			get {
				if (_obj != null) {
					return _obj.Count;
				}
				if (_array != null) {
					return _array.Count;
				}
				throw new JsonException($"Count is not valid for {Type} (only valid for Object and Array)");
			}
		}
	}
}
