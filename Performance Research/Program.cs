using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;

namespace PerformanceResearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            //TimeLongMagnitude(10000000, Convert.ToInt64(Int16.MaxValue));
            //TimeLongMagnitude(10000000, Convert.ToInt64(Int32.MaxValue));
            //TimeLongMagnitude(10000000, Int64.MaxValue);

            //TimeLongAppend(10000000, Convert.ToInt64(Int32.MaxValue));
            //TimeLongAppend(10000000, Convert.ToInt64(Int16.MaxValue));
            //TimeLongAppend(10000000, Int64.MaxValue);

            TimeStringTokenizing(10, 10);
        }
         
        static void TimeStringTokenizing(int n, int max)
        {
            Time(TokenizeRegex, n, max);

            // Method 2 - CharEnumerator - todo

        }

        static void TokenizeRegex(int n, int max)
        {
            MathExpression mathExpression = new MathExpression();

            string regex = @"(\b(\d+)+\b)|\D";
            // Method 1
            for (int i = 1; i <= n; i++)
            {
                string expression = mathExpression.GenerateRandom(n, max);
                Console.WriteLine(expression);
                List<string> matches = new List<string>();

                Match match = Regex.Match(expression, regex);
                while (match.Success)
                {
                    matches.Add(match.Value);
                    expression = expression.Substring(match.Value.Length);
                    match = Regex.Match(expression, regex);
                }
                Console.WriteLine(string.Join(string.Empty, matches));
            }
        }

        static void Time<T>(Action<T, T> func, T firstParameter, T secondParameter)
        {
            Action action = () => func(firstParameter, secondParameter);
            long time = new Stopwatch().Time(action);
            Console.WriteLine($"{func.Method.Name,-26} : {time,4} ms");
        }

        static void Time<T>(Func<T, T> func, T[] array)
        {
            Action action = () => Array.ForEach(array, l => func(l));
            long time = new Stopwatch().Time(action);
            Console.WriteLine($"{func.Method.Name,-26} : {time,4} ms");
        }

        static void Time<T>(Func<T, T, T> func, Tuple<T, T>[] tuples)
        {
            Action action = () => Array.ForEach(tuples, t => func(t.Item1, t.Item2));
            long time = new Stopwatch().Time(action);
            Console.WriteLine($"{func.Method.Name,-26} : {time,4} ms");
        }

        static void TimeLongMagnitude(int n, long max)
        {
            Random random = new Random();
            long[] randoms = Enumerable.Repeat(0, n).Select(i => random.NextLong(max)).ToArray();
            Console.WriteLine($"n = {n}, max = {max}");

            Func<long, long>[] funcs = new Func<long, long>[]
            {
                LongExtensions.MagnitudeByMultiplication,
                LongExtensions.MagnitudeByMultiplication2,
                LongExtensions.MagnitudeByMultiplication3,
                LongExtensions.MagnitudeByRange,
                LongExtensions.MagnitudeByDivision,
                //LongExtensions.MagnitudeBySwitch,
                //LongExtensions.MagnitudeByLog,
                //LongExtensions.MagnitudeByString
            };
            
            foreach (Func<long, long> func in funcs)
            {
                Time(func, randoms);
            }
        }

        static void TimeLongAppend(int n, long max)
        {
            Random random = new Random();
            Tuple<long, long>[] appendableRandoms = Enumerable.Repeat(0, n).Select(i => 
            { 
                long r = random.NextLong(max);
                return new Tuple<long, long>(r, maxAppend(r));
            }).ToArray();
            Console.WriteLine($"n = {n}, max = {max}");

            Func<long, long, long>[] funcs = new Func<long, long, long>[]
            {
                LongExtensions.AppendByRangeChecked,
                LongExtensions.AppendByRange,
                LongExtensions.AppendByMagnitude,
                LongExtensions.AppendLoop,
                //LongExtensions.AppendByConvertString2,
                //LongExtensions.AppendByParseString2,
                //LongExtensions.AppendByParseString,
                //LongExtensions.AppendByConvertString
            };
            
            foreach (Func<long, long, long> func in funcs)
            {
                Time(func, appendableRandoms);
            }
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


