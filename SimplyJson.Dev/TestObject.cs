using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyJson.Dev {
	public class TestObject {
		public int Id { get; set; }
		public string Name { get; set; }
		[JsonIgnore]
		public string NotSerialized { get; set; }
		public Dictionary<string, int> Dict { get; set; } = new Dictionary<string, int>();
		public List<string> List { get; set; } = new List<string>();
		public Dictionary<string, TestObject> ObjDict { get; set; } = new Dictionary<string, TestObject>();
		public Json Raw { get; set; }

	}
}
