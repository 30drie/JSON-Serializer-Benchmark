using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace J.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{

			List<object> sampleObjects = GetSampleObjects();
			List<Benchmarking> benchmarkObjects = GetSerializerBenchmarks(sampleObjects);

			foreach (Benchmarking b in benchmarkObjects)
			{
				b.Setup();
				var start = DateTime.Now;
				b.Serialize();
				var elapsed = DateTime.Now.Subtract(start);
				Console.WriteLine($"Serialize {b.GenericType,-80}\t: {elapsed.TotalSeconds:0.000} sec.");
				start = DateTime.Now;
				b.Deserialize();
				elapsed = DateTime.Now.Subtract(start);
				Console.WriteLine($"Deserialize {b.GenericType,-80}\t: {elapsed.TotalSeconds:0.000} sec.");
			}

			Console.WriteLine("Benchmarking finished.");
			Console.ReadLine();
		}

		private static List<object> GetSampleObjects()
		{
			// Get builders from shared library
			var assembly = Assembly.LoadFrom("J.Shared.dll");
			var sharedTypes = assembly.GetTypes();
			var sampleObjects = new List<object>();
			foreach (Type type in sharedTypes)
			{
				if (type.BaseType != null && type.BaseType.Name.StartsWith("SampleBuilder"))
				{
					var obj = type.GetConstructor(Array.Empty<Type>()).Invoke(null);
					sampleObjects.Add(obj);
				}
			}

			return sampleObjects;
		}

		private static List<Benchmarking> GetSerializerBenchmarks(List<object> sampleObjects)
		{
			var benchmarkers = new List<Benchmarking>();

			// Get referenced assemblies (optimization makes them not available in referenced assembly function).
			// Additional serializers can be created in a separate class library as long as they inherit from BaseSerializer
			var files = System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
			foreach (string file in files)
			{
				var assembly = Assembly.LoadFile(file);
				foreach (Type type in assembly.GetTypes())
				{
					if (type.BaseType != null && type.BaseType.Name.StartsWith("BaseSerializer"))
					{
						foreach (object sampleObject in sampleObjects)
						{
							benchmarkers.Add(GetBenchmark(type, sampleObject));
						}
					}
				}
			}

			return benchmarkers;
		}

		private static Benchmarking GetBenchmark(Type type, object sampleObject)
		{
			var genericType = type.MakeGenericType(sampleObject.GetType());
			var b = new Benchmarking()
			{
				GenericType = genericType,
				Sample = sampleObject
			};

			return b;
		}

	}

}
