using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson.Dev {
	class Program {
		static void Main(string[] args) {
			Json.SerializationFormat = JsonSerializationFormat.CamelCase;
			var item = new TestObject {
				Id = 42,
				Name = "Regus",
				NotSerialized = "Should not be serialized",
				Raw = Json.Parse(@"{""foo"":""bar""}")
			};
			item.Dict.Add("Foo", 21);
			item.Dict.Add("Bar", 84);
			item.List.Add("Fizz");
			item.List.Add("buzz");
			var user1 = new TestObject {
				Id = 1,
				Name = "Name1"
			};
			user1.Dict.Add("Foo", 44);
			user1.Dict.Add("Bar", 48);
			user1.List.Add("fIzz");
			user1.List.Add("buUz");
			item.ObjDict.Add("User1", user1);
			item.ObjDict.Add("User2", new TestObject {
				Id = 2,
				Name = "Name2"
			});
			var json = Json.Serialize(item);
			Console.WriteLine(json.ToString(true));
			var testObj = json.Deserialize<TestObject>();
			Console.WriteLine(testObj);

			Console.WriteLine(Json.Serialize(testObj).ToString(true));


		}
	}
}
