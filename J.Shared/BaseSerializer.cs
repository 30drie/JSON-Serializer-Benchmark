namespace J.Shared
{
	public abstract class BaseSerializer<T> where T: new()
	{

		public abstract string Serialize(T input);

		public abstract T Deserialize(string input);

	}
}
