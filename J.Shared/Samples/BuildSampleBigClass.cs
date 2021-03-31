using J.Shared.Samples.Classes;
using System;
using System.Collections.Generic;

namespace J.Shared.Samples
{
	public class BuildSampleBigClass : SampleBuilder<IList<BigClass>>
	{
		public const int Count = 1000;

		public BuildSampleBigClass()
		{
			var r = new Random();
			var list = new List<BigClass>();
			while (list.Count < Count)
			{
				var created = GetRandomDateTime();
				list.Add(new BigClass()
				{
					Id = list.Count,
					Name = GetRandomString(),
					Created = created,
					Modified = GetRandomDateTime(),
					SmallClassValues = GetSmallClassList(),
					DayOfWeek = created.DayOfWeek,
					DateTimeKind = (DateTimeKind)r.Next(0, 2),
					Value1 = GetRandomDouble(),
					Value2 = GetRandomDouble(),
					Value3 = GetRandomDouble(),
					Value4 = GetRandomDecimal(),
					Value5 = GetRandomDecimal(),
					Value6 = GetRandomDecimal(),
					Values = GetDecList()
				});
			}

			_sample = list;
		}

		private IList<decimal> GetDecList()
		{
			var list = new List<decimal>();
			while (list.Count < 10)
			{
				list.Add(GetRandomDecimal());
			}
			return list;
		}

		private IList<SmallClass> GetSmallClassList()
		{
			var list = new List<SmallClass>();
			while (list.Count < 10)
			{
				list.Add(new SmallClass()
				{
					Id = list.Count + 1,
					Name = GetRandomString(100),
					Value = GetRandomDecimal()
				});
			}

			return list;
		}
	}
}
