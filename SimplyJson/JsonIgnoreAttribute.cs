using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyJson {
	[AttributeUsage(AttributeTargets.Property)]
	public class JsonIgnoreAttribute : Attribute {
	}
}
