using J.Shared;
using System.Text.Json;

namespace J.SystemText
{
	public class SystemSerializer<T> : BaseSerializer<T> where T : new()
	{

		public override string Serialize(T input)
		{
			return JsonSerializer.Serialize(input);
		}

		public override T Deserialize(string input)
		{
			return JsonSerializer.Deserialize<T>(input);
		}

	}
}
