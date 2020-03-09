using System;
using System.Linq;
using System.Collections.Generic;

namespace PerformanceResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeLongExtensions(10000000);
        }

        static void TimeLongExtensions(int n)
        {
            Random random = new Random();
            long max = long.MaxValue;
            int time;

            Tuple<long, long>[] appendableTuples = Enumerable.Repeat(0, n).Select(i => 
            { 
                long r = random.NextLong(max);
                max -= 1000000000;
                return new Tuple<long, long>(r, maxAppend(r));
            }).ToArray();

            // Magnitude

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.Magnitude()));
            Console.WriteLine($"Magnitude by division: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.MagnitudeByRange()));
            Console.WriteLine($"Magnitude by range: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.MagnitudeBySwitch()));
            Console.WriteLine($"Magnitude by switch: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.MagnitudeByLog()));
            Console.WriteLine($"Magnitude by log: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.MagnitudeByString()));
            Console.WriteLine($"Magnitude by string: {time} ms");

            // Append

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.Append(t.Item2)));
            Console.WriteLine($"Append by range checked: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.AppendByRange(t.Item2)));
            Console.WriteLine($"Append by range: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.AppendClean(t.Item2)));
            Console.WriteLine($"Append by range checked clean: {time} ms");

            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.AppendByMagnitude(t.Item2)));
            Console.WriteLine($"Append by magnitude: {time} ms");
            
            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.AppendByConvertString(t.Item2)));
            Console.WriteLine($"Append by convert string: {time} ms");
            
            time = Timer.Time(() => Array.ForEach(appendableTuples, t => t.Item1.AppendByParseString(t.Item2)));
            Console.WriteLine($"Append by parse string: {time} ms");
        }

        private static long maxAppend(long i)
        {
            if (i < 0) throw new Exception("Appended numbers must be non-negative");
            if (i <= 7) return 922337203685477580;
            if (i <= 9) return 922337203685477579;
            if (i <= 99) return 92233720368547757;
            if (i <= 807) return 9223372036854775;
            if (i <= 999) return 9223372036854774;
            if (i <= 5807) return 922337203685477;
            if (i <= 9999) return 922337203685476;
            if (i <= 75807) return 92233720368547;
            if (i <= 99999) return 92233720368546;
            if (i <= 775807) return 9223372036854;
            if (i <= 999999) return 9223372036853;
            if (i <= 4775807) return 922337203685;
            if (i <= 9999999) return 922337203684;
            if (i <= 54775807) return 92233720368;
            if (i <= 99999999) return 92233720367;
            if (i <= 854775807) return 9223372036;
            if (i <= 999999999) return 9223372035;
            if (i <= 6854775807) return 922337203;
            if (i <= 9999999999) return 922337202;
            if (i <= 36854775807) return 92233720;
            if (i <= 99999999999) return 92233719;
            if (i <= 2036854775807) return 922337;
            if (i <= 9999999999999) return 922336;
            if (i <= 72036854775807) return 92233;
            if (i <= 99999999999999) return 92232;
            if (i <= 372036854775807) return 9223;
            if (i <= 999999999999999) return 9222;
            if (i <= 3372036854775807) return 922;
            if (i <= 9999999999999999) return 921;
            if (i <= 23372036854775807) return 92;
            if (i <= 99999999999999999) return 91;
            if (i <= 223372036854775807) return 9;
            if (i <= 999999999999999999) return 8;
            return -1;
        }
    }
}


