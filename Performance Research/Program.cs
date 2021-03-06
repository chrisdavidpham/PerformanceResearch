﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Collections.Generic;
using RandomExtensions;
using StopwatchExtensions;

namespace PerformanceResearch
{
    class Program
    {
        private static Random Rand = new Random();
        private static long[] count;

        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
            count = new long[19];
            TestLongMagnitude(10000000);
            TestLongAppend(10000000);

            for (int i = 0; i < 19; i++)
                Console.WriteLine($"{i} : {count[i]}");

            //TestTokenizing(1000, Int64.MaxValue);
        }
         
        static List<string> TokenizeByEnumerator(string expression)
        {
            List<string> tokens           = new List<string>();
            StringBuilder stringBuilder   = new StringBuilder();
            CharEnumerator charEnumerator = expression.GetEnumerator();
            while (charEnumerator.MoveNext())
            {
                char symbol = charEnumerator.Current;
                if (char.IsDigit(symbol))
                {
                    stringBuilder.Append(symbol);
                }
                else 
                {
                    if (stringBuilder.Length > 0)
                    {
                        tokens.Add(stringBuilder.ToString());
                        stringBuilder.Clear();
                    }
                    tokens.Add(symbol.ToString());
                }
            }
            if (stringBuilder.Length > 0)
            {
                tokens.Add(stringBuilder.ToString());
            }
            return tokens;
        }

        static void TestTokenizing(int n, long max)
        {
            Stopwatch stopwatch           = new Stopwatch();
            string[] expressions          = new string[n];
            MathExpression.MathExpression mathExpression = new MathExpression.MathExpression();
            Func<string, List<string>>[] funcs = new Func<string, List<string>>[]
            {
                TokenizeByEnumerator,
                TokenizeByRegex,
            };
            
            for (int i = 0; i < n; i++)
                expressions[i] = mathExpression.GenerateRandom(n, max);
            
            foreach (Func<string, List<string>> func in funcs)
            {
                Action action = () => Array.ForEach(expressions, e => func(e));
                TimeSpan timeSpan = stopwatch.Time(action);
                int milliSeconds  = Convert.ToInt32(timeSpan.TotalMilliseconds);
                Console.WriteLine($"{func.Method.Name,-27} : {milliSeconds,4} ms");
            }
        }

        static List<string> TokenizeByRegex(string expression)
        {
            List<string> matches = new List<string>();
            Match match = Regex.Match(expression, @"(\b(\d+)+\b)|\D");
            while (match.Success)
            {
                matches.Add(match.Value);
                expression = expression.Substring(match.Value.Length);
                match = Regex.Match(expression, @"(\b(\d+)+\b)|\D");
            }
            return matches;
        }

        static void TestLongMagnitude(int n)
        {
            long[] randoms           = new long[n];
            Stopwatch stopwatch      = new Stopwatch();
            Func<long, long>[] funcs = new Func<long, long>[]
            {
                LongExtensions.LongExtensions.MagnitudeByMultiplication,
                LongExtensions.LongExtensions.MagnitudeByMultiplication2,
                LongExtensions.LongExtensions.MagnitudeByRange,
                LongExtensions.LongExtensions.MagnitudeByMultiplication3,
                LongExtensions.LongExtensions.MagnitudeByDivision,
            };
            for (int i = 0; i < n; i++)
                randoms[i] = Rand.NextLong();

            Console.WriteLine($"n = {n}");
            foreach (Func<long, long> func in funcs)
            {
                Action action     = () => Array.ForEach(randoms, i => func(i));
                TimeSpan timeSpan = stopwatch.Time(action);
                int milliSeconds  = Convert.ToInt32(timeSpan.TotalMilliseconds);
                Console.WriteLine($"{func.Method.Name,-27} : {milliSeconds,4} ms");
            }
        }

        static void TestLongAppend(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            Tuple<long, long>[] appendableRandoms = new Tuple<long, long>[n];
            Func<long, long, long>[] funcs = new Func<long, long, long>[]
            {
                LongExtensions.LongExtensions.AppendByRangeChecked,
                LongExtensions.LongExtensions.AppendLoop,
                LongExtensions.LongExtensions.AppendByRange,
                LongExtensions.LongExtensions.AppendByMagnitude,
            };
            for (int i = 0; i < n; i++)
                appendableRandoms[i] = GetRandomAppendableTuple();

            Console.WriteLine($"n = {n}");
            foreach (Func<long, long, long> func in funcs)
            {
                Action action     = () => Array.ForEach(appendableRandoms, t => func(t.Item1, t.Item2));
                TimeSpan timeSpan = stopwatch.Time(action);
                int milliSeconds  = Convert.ToInt32(timeSpan.TotalMilliseconds);
                Console.WriteLine($"{func.Method.Name,-27} : {milliSeconds,4} ms");
            }
        }

        private static Tuple<long, long> GetRandomAppendableTuple()
        {
            // Random magnitudes
            int p1 = Rand.Next(1, 19);
            int p2 = Rand.Next(1, 19 - p1);
            count[p1]++;
            count[p2]++;
            long max1 = (long)Math.Pow(10, p1);
            long max2 = (long)Math.Pow(10, p2);
            long min1 = (long)Math.Pow(10, p1 - 1) - 1;
            long min2 = (long)Math.Pow(10, p2 - 1) - 1;
            long maxAppend = MaxAppend(max2 - 1);
            if (max1 > maxAppend)
            {
                max1 = maxAppend;
                min1 /= 10;
            }
            long r1 = Rand.NextLong(min1, max1);
            long r2 = Rand.NextLong(min2, max2);
            return new Tuple<long, long>(r1, r2);
        }

        private static long MaxAppend(long i)
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


