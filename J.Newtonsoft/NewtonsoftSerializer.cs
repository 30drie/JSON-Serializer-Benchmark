using J.Shared;
using Newtonsoft.Json;

namespace J.Newtonsoft
{
	public class NewtonsoftSerializer<T> : BaseSerializer<T> where T : new()
	{

		public override string Serialize(T input)
		{
			return JsonConvert.SerializeObject(input);
		}

		public override T Deserialize(string input)
		{
			return JsonConvert.DeserializeObject<T>(input);
		}
	}
}
