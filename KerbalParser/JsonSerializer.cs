using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KerbalParser
{
	public class JsonSerializer
	{
		public static string To<T>(T obj)
		{
			string retVal;
			var serializer = new DataContractJsonSerializer(obj.GetType());
			using (var ms = new MemoryStream())
			{
				serializer.WriteObject(ms, obj);
				retVal = Encoding.Default.GetString(ms.ToArray());
			}

			return retVal;
		}

		public static T From<T>(string json)
		{
			var obj = Activator.CreateInstance<T>();
			using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
			{
				var serializer =
					new DataContractJsonSerializer(obj.GetType());
				obj = (T) serializer.ReadObject(ms);
			}

			return obj;
		}
	}
}