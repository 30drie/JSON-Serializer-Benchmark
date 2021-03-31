using BenchmarkDotNet.Attributes;
using J.Shared;
using J.Shared.Samples;
using System;

namespace J.ConsoleApp
{
	public class Benchmarking
	{
		public Type GenericType { get; set; }

		public object Sample { get; set; }

		public string Serialized { get; private set; }

		private object _obj;

		[GlobalSetup]
		public void Setup()
		{
			_obj = GenericType.GetConstructor(Array.Empty<Type>()).Invoke(null);
		}

		[Benchmark]
		public string Serialize()
		{
			Serialized = GenericType.GetMethod("Serialize").Invoke(_obj, new object[] { Sample }).ToString();
			return Serialized;
		}

		[Benchmark]
		public object Deserialize()
		{
			return GenericType.GetMethod("Deserialize").Invoke(_obj, new object[] { Serialized });
		}

		[GlobalCleanup]
		public void Cleanup()
		{

		}
	}
}
