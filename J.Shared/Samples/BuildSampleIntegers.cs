using J.Shared.Samples.Classes;
using System.Collections.Generic;

namespace J.Shared.Samples
{
	public class BuildSampleIntegers : SampleBuilder<IList<int>>
	{
		public const int Count = 100000;

		public BuildSampleIntegers()
		{
			var list = new List<int>();
			while (list.Count < Count)
			{
				list.Add(GetRandomInt());
			}

			_sample = list;
		}
	}
}
