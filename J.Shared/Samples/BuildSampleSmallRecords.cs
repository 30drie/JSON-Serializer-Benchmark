using J.Shared.Samples.Classes;
using System.Collections.Generic;

namespace J.Shared.Samples
{
	public class BuildSampleSmallRecords : SampleBuilder<IList<SmallRecord>>
	{
		public const int Count = 10000;

		public BuildSampleSmallRecords()
		{
			var list = new List<SmallRecord>();
			while (list.Count < Count)
			{
				list.Add(new SmallRecord()
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
