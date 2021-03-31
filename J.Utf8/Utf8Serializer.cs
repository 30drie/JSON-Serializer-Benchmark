using J.Shared;
using System;

namespace J.Utf8
{
	public class Utf8Serializer<T> : BaseSerializer<T> where T : new()
	{
		public override string Serialize(T input)
		{
			return Utf8Json.JsonSerializer.ToJsonString(input);
		}

		public override T Deserialize(string input)
		{
			return Utf8Json.JsonSerializer.Deserialize<T>(input);
		}

	}
}
