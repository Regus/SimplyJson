using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimplyJson.Test {
	[TestClass]
	public class Parsing {
		[TestMethod]
		public void Simple() {
			string text = File.ReadAllText(@"TestCases\simple.json");
			Stopwatch watch = new Stopwatch();
			watch.Start();
			Json json = Json.Parse(text);
			watch.Stop();
			Console.WriteLine("Parse: " + watch.ElapsedMilliseconds);

			watch.Reset();
			watch.Start();
			string newText = json.ToString(true);
			watch.Stop();
			Console.WriteLine("Stringify: " + watch.ElapsedMilliseconds);
			Assert.AreEqual(newText, File.ReadAllText(@"E:\ProjectsGit\SimplyJson\SimplyJson.Test\Expected\simple.json"));
		}

	}
}
