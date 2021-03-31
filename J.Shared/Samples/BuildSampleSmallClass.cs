using J.Shared.Samples.Classes;
using System.Collections.Generic;

namespace J.Shared.Samples
{
	public class BuildSampleSmallClass : SampleBuilder<IList<SmallClass>>
	{
		public const int Count = 10000;

		public BuildSampleSmallClass()
		{
			var list = new List<SmallClass>();
			while (list.Count < Count)
			{
				list.Add(new SmallClass()
				{
					Id = list.Count + 1,
					Name = GetRandomString(),
					Value = GetRandomDecimal()
				});
			}

			_sample = list;
		}
	}
}
