using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
namespace array
{
    class Program
    {

        // constants
		private const int numElements = 1000;

		public static long MeasureA() 
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			int[,] list = new int[numElements, numElements];
			for (int i = 0; i < numElements; i++) 
			{
				for (int j = 0; j < numElements; j++) 
				{
					list [i, j] = 1;  //use 2-dimensional array, slower than the native one dimensional array, due to .net build in support.
				}
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB() 
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			int[] list = new int[numElements * numElements];
			for (int i = 0; i < numElements; i++) 
			{
				for (int j = 0; j < numElements; j++) 
				{
					int index = numElements * i + j;  //this is the flatterning technique
					list [index] = 1;
				}
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}



        static void Main(string[] args)
        {
            // measurement run
			long duration1 = MeasureA ();
			long duration2 = MeasureB ();

			Console.WriteLine ("int[,]: {0}", duration1);
			Console.WriteLine ("flattened int[,]: {0}", duration2);
        }
    }
}
