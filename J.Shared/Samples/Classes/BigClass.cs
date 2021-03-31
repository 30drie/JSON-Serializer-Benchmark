using System;
using System.Collections.Generic;

namespace J.Shared.Samples.Classes
{
	public class BigClass
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }

		public IList<SmallClass> SmallClassValues { get; set; }

		public DayOfWeek DayOfWeek { get; set; }

		public DateTimeKind DateTimeKind { get; set; }

		public double Value1 { get; set; }

		public double Value2 { get; set; }

		public double Value3 { get; set; }

		public decimal Value4 { get; set; }

		public decimal Value5 { get; set; }

		public decimal Value6 { get; set; }

		public IList<decimal> Values { get; set; }
	}
}
