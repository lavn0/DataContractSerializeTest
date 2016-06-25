using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DataContractSerializeTest.Serializable
{
	[DataContract]
	public class SubClass
	{
		[DataMember]
		public int IntValue { get; set; }

		[DataMember]
		public string StringValue { get; set; }

		[DataMember]
		public string[] StringArray { get; set; }

		[DataMember]
		public List<string> StringList { get; set; }

		[DataMember]
		public Dictionary<int, string> Dictionary { get; set; }
	}
}