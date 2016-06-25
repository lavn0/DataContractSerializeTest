using DataContractSerializeTest.Serializable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DataContractSerializeTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			var target = new RootClass()
			{
				IntValue = 3,
				StringValue = "hoge1",
				StringArray = new[] { "val1", "val2" },
				StringList = new List<string>() { "val1", "val2" },
				Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
				SubClass = new SubClass(),
				SubClassesArray = new SubClass[]
					{
						new SubClass()
						{
							IntValue = 4,
							StringValue = "hoge2",
							StringArray = new[] { "val1-1", "val1-2" },
							StringList = new List<string>() { "val1", "val2" },
							Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
						},
						new SubClass()
						{
							IntValue = 5,
							StringValue = "hoge3",
							StringArray = new[] { "val1-1", "val1-2" },
							StringList = new List<string>() { "val1", "val2" },
							Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
						},
					},
				SubClassesList = new List<SubClass>()
					{
						new SubClass()
						{
							IntValue = 6,
							StringValue = "hoge4",
							StringArray = new[] { "val1-1", "val1-2" },
							StringList = new List<string>() { "val1", "val2" },
							Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
						},
						new SubClass()
						{
							IntValue = 7,
							StringValue = "hoge5",
							StringArray = new[] { "val1-1", "val1-2" },
							StringList = new List<string>() { "val1", "val2" },
							Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
						},
					},
				SubClassesDictionary = new Dictionary<int, SubClass>()
					{
						{ 1, new SubClass()
							{
								IntValue = 8,
								StringValue = "hoge6",
								StringArray = new[] { "val1-1", "val1-2" },
								StringList = new List<string>() { "val1", "val2" },
								Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
							}
						},
						{
							2, new SubClass()
							{
								IntValue = 9,
								StringValue = "hoge7",
								StringArray = new[] { "val1-1", "val1-2" },
								StringList = new List<string>() { "val1", "val2" },
								Dictionary = new Dictionary<int, string>() { { 1, "value1" }, { 2, "value2" } },
							}
						},
					}
			};

			var serialized = DataContractParser.ParseObject(target);
			var serializedXDocumentSlimed = XDocument.Parse(serialized).ToString();
			var expected = XDocument.Load("SerializedData.xml").ToString();
			Assert.AreEqual(expected, serializedXDocumentSlimed);
		}
	}
}
