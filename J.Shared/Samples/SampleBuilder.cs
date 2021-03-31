using System;
using System.Text;

namespace J.Shared.Samples
{
	public abstract class SampleBuilder<T>
	{

		protected T _sample;

		public T Sample { get => _sample; }

		private readonly Random random = new();

		protected string GetRandomString(int length = 16)
		{
			string result = string.Empty;
			while (result.Length<length)
			{
				result += UTF8Encoding.UTF8.GetString(new byte[] { (byte)random.Next(32, 127) });
			}
			return result;
		}

		protected decimal GetRandomDecimal()
		{
			return random.Next(0, 1000) + random.Next(0, 1000) / 1000m;
		}

		protected double GetRandomDouble()
		{
			return random.NextDouble();
		}

		protected DateTime GetRandomDateTime()
		{
			var year = 2000 + random.Next(-10, 10);
			var month = random.Next(1, 12);
			var day = random.Next(1, 28);
			var hour = random.Next(0, 23);
			var minutes = random.Next(0, 59);
			var seconds = random.Next(0, 59);
			return new DateTime(year, month, day, hour, minutes, seconds);
		}

		protected int GetRandomInt()
		{
			return random.Next();
		}
	}
}
