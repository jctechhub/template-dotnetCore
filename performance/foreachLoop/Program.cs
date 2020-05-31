using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;



namespace foreachloop
{
    class Program
    {
      // constants
		private const int numElements = 10000000;

		// fields
		private static ArrayList arrayList = new ArrayList (numElements);
		private static List<int> genericList = new List<int> (numElements);
		private static int[] array = new int[numElements];


		public static void PrepareList ()
		{
			Random random = new Random ();
			for (int i = 0; i < numElements; i++)
			{
				int number = random.Next (256);
				arrayList.Add (number);
				genericList.Add (number);
				array [i] = number;
			}

		}

		public static long MeasureA1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = (int)arrayList [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureA2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in arrayList)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

        public static long MeasureA3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
			arrayList.ToArray().ToList().ForEach(x =>
            {
                int result = (int)x;
			});
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
		public static long MeasureB1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = genericList [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureB2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in genericList)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

        //using ForEach in linq is the slowest.
        public static long MeasureB3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
			genericList.ForEach(x =>
            {
                int result = x;
			});
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }


		public static long MeasureC1 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			for (int i = 0; i < numElements; i++)
			{
				int result = array [i];
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

		public static long MeasureC2 ()
		{
			Stopwatch stopwatch = new Stopwatch ();
			stopwatch.Start ();
			foreach (int i in array)
			{
				int result = i;
			}
			stopwatch.Stop ();
			return stopwatch.ElapsedMilliseconds;
		}

        public static long MeasureC3()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
			array.ToList().ForEach(x =>
            {
                int result = x;
			});
           
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }


		public static void Main (string[] args)
		{
			// prepare lists
			PrepareList ();

			// measurement run
			long durationA1 = MeasureA1 ();
            long durationA2 = MeasureA2();
            long durationA3 = MeasureA3();

			long durationB1 = MeasureB1 ();
            long durationB2 = MeasureB2();
            long durationB3 = MeasureB3();

			long durationC1 = MeasureC1 ();
			long durationC2 = MeasureC2 ();
            long durationC3 = MeasureC3();


			Console.WriteLine ("ArrayList for: {0}", durationA1);
            Console.WriteLine("ArrayList foreach: {0}", durationA2);
            Console.WriteLine("ArrayList foreach linq: {0}", durationA3);
			Console.WriteLine ("List<int> for: {0}", durationB1);
			Console.WriteLine ("List<int> foreach: {0}", durationB2);
            Console.WriteLine("List<int> foreach linq: {0}", durationB3);  //slowest in List<T>, dont' use.
			Console.WriteLine ("int[] for: {0}", durationC1); //use array [] and use for loop
			Console.WriteLine ("int[] foreach: {0}", durationC2);
            Console.WriteLine("int[] foreach linq: {0}", durationC3);
		}
    }
}
