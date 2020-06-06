using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace Arrays_on_the_stack_v2
{
	public class MainClass
	{
		// constants
		private const int repetitions = 5000;

		public static long MeasureA(int elements) 
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			int[] list = new int[elements];
			for (int r = 0; r < repetitions; r++) 
			{
				for (int i = 0; i < elements; i++) 
				{
					list [i] = i;
				}
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB(int elements) 
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			unsafe 
			{
				int* list = stackalloc int[elements];
				for (int r = 0; r < repetitions; r++) 
				{
					for (int i = 0; i < elements; i++) 
					{
						list [i] = i;
					}
				}
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static void Main (string[] args)
		{
			// measurement run
			for (int elements = 1000; elements < 100000; elements += 2000) 
			{
				long duration1 = MeasureA (elements);
				long duration2 = MeasureB (elements);
				Console.WriteLine ("{0}\t{1}\t{2}", elements, duration1, duration2);
			}
		}
	}
}
