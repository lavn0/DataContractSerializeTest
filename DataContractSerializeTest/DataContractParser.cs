// add reference to System.Runtime.Serialization, Version=4.0.0.0
// add reference to System.XML, Version=4.0.0.0
using System.IO;
using System.Runtime.Serialization;
using System.Text;

public static class DataContractParser
{
	public static T ReadObject<T>(Stream stream)
	{
		return (T)new DataContractSerializer(typeof(T)).ReadObject(stream);
	}

	public static T ReadObject<T>(string fileName)
	{
		using (var sr = new StreamReader(fileName))
		{
			return ReadObject<T>(sr.BaseStream);
		}
	}

	public static void WriteObject<T>(T obj, Stream stream)
	{
		new DataContractSerializer(typeof(T)).WriteObject(stream, obj);
	}

	public static void WriteObject<T>(T obj, string fileName)
	{
		using (var sw = new StreamWriter(fileName))
		{
			WriteObject<T>(obj, sw.BaseStream);
		}
	}

	public static T ParseObject<T>(string jsonString)
	{
		using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
		{
			return ReadObject<T>(ms);
		}
	}

	public static string ParseObject<T>(T obj)
	{
		MemoryStream ms = null;

		try
		{
			ms = new MemoryStream();
			WriteObject<T>(obj, ms);
			ms.Seek(0, SeekOrigin.Begin);
			using (var sr = new StreamReader(ms))
			{
				ms = null;
				return sr.ReadToEnd();
			}
		}
		finally
		{
			ms?.Dispose();
		}
	}
}
