using System;

namespace PerformanceResearch
{
    public static class LongExtensions
    {
        // Fastest
        public static long MagnitudeByDivision(this long i)
        {
            long magnitude = 1;
            for (long p = i; p >= 10; p /= 10)
                magnitude *= 10;
            return magnitude;
        }

        public static long MagnitudeByRange(this long i)
        {
            if (i < 10) return 1;
            if (i < 100) return 10;
            if (i < 1000) return 100;
            if (i < 10000) return 1000;
            if (i < 100000) return 10000;
            if (i < 1000000) return 100000;
            if (i < 10000000) return 1000000;
            if (i < 100000000) return 10000000;
            if (i < 1000000000) return 100000000;
            if (i < 10000000000) return 1000000000;
            if (i < 100000000000) return 10000000000;
            if (i < 1000000000000) return 100000000000;
            if (i < 10000000000000) return 1000000000000;
            if (i < 100000000000000) return 10000000000000;
            if (i < 1000000000000000) return 100000000000000;
            if (i < 10000000000000000) return 1000000000000000;
            if (i < 100000000000000000) return 10000000000000000;
            if (i < 1000000000000000000) return 100000000000000000;
            return 1000000000000000000;
        }

        public static long MagnitudeBySwitch(this long i)
        {
            switch (i)
            {
                case long j when j < 10: return 1;
                case long j when j < 100: return 10;
                case long j when j < 1000: return 100;
                case long j when j < 10000: return 1000;
                case long j when j < 100000: return 10000;
                case long j when j < 1000000: return 100000;
                case long j when j < 10000000: return 1000000;
                case long j when j < 100000000: return 10000000;
                case long j when j < 1000000000: return 100000000;
                case long j when j < 10000000000: return 1000000000;
                case long j when j < 100000000000: return 10000000000;
                case long j when j < 1000000000000: return 100000000000;
                case long j when j < 10000000000000: return 1000000000000;
                case long j when j < 100000000000000: return 10000000000000;
                case long j when j < 1000000000000000: return 100000000000000;
                case long j when j < 10000000000000000: return 1000000000000000;
                case long j when j < 100000000000000000: return 10000000000000000;
                case long j when j < 1000000000000000000: return 100000000000000000;
                default: return 1000000000000000000;
            }
        }
        public static long MagnitudeByLog(this long i)
        {
            long magnitude = 1;
            while (i > double.MaxValue)
            {
                i /= 10;
                magnitude *= 10;
            }
            int power = (int)(Math.Log10(Convert.ToDouble(i)));
            for (int p = 1; p <= power; p++)
                magnitude *= 10;
            return magnitude;
        }

        public static int MagnitudeByString(this long i)
        {
            return i.ToString().Length - 1;
        }

        // Fastest
        public static long AppendByRangeChecked(this long i, long j)
        {
            if (j < 0 || i < 0) throw new Exception("Appended numbers must be non-negative");
            if (j <= 9) return checked(10 * i + j);
            if (j <= 99) return checked(100 * i + j);
            if (j <= 999) return checked(1000 * i + j);
            if (j <= 9999) return checked(10000 * i + j);
            if (j <= 99999) return checked(100000 * i + j);
            if (j <= 999999) return checked(1000000 * i + j);
            if (j <= 9999999) return checked(10000000 * i + j);
            if (j <= 99999999) return checked(100000000 * i + j);
            if (j <= 999999999) return checked(1000000000 * i + j);
            if (j <= 9999999999) return checked(10000000000 * i + j);
            if (j <= 99999999999) return checked(100000000000 * i + j);
            if (j <= 999999999999) return checked(1000000000000 * i + j);
            if (j <= 9999999999999) return checked(10000000000000 * i + j);
            if (j <= 99999999999999) return checked(100000000000000 * i + j);
            if (j <= 999999999999999) return checked(1000000000000000 * i + j);
            if (j <= 9999999999999999) return checked(10000000000000000 * i + j);
            if (j <= 99999999999999999) return checked(100000000000000000 * i + j);
            return checked(1000000000000000000 * i + j);
        }

        public static long AppendByRange(this long i, long j)
        {
            if (j <= 7 && i <= 922337203685477580) return 10 * i + j;
            if (j <= 9 && i <= 922337203685477579) return 10 * i + j;
            if (j <= 99 && i <= 92233720368547757) return 100 * i + j;
            if (j <= 807 && i <= 9223372036854775) return 1000 * i + j;
            if (j <= 999 && i <= 9223372036854774) return 1000 * i + j;
            if (j <= 5807 && i <= 922337203685477) return 10000 * i + j;
            if (j <= 9999 && i <= 922337203685476) return 10000 * i + j;
            if (j <= 75807 && i <= 92233720368547) return 100000 * i + j;
            if (j <= 99999 && i <= 92233720368546) return 100000 * i + j;
            if (j <= 775807 && i <= 9223372036854) return 1000000 * i + j;
            if (j <= 999999 && i <= 9223372036853) return 1000000 * i + j;
            if (j <= 4775807 && i <= 922337203685) return 10000000 * i + j;
            if (j <= 9999999 && i <= 922337203684) return 10000000 * i + j;
            if (j <= 54775807 && i <= 92233720368) return 100000000 * i + j;
            if (j <= 99999999 && i <= 92233720367) return 100000000 * i + j;
            if (j <= 854775807 && i <= 9223372036) return 1000000000 * i + j;
            if (j <= 999999999 && i <= 9223372035) return 1000000000 * i + j;
            if (j <= 6854775807 && i <= 922337203) return 10000000000 * i + j;
            if (j <= 9999999999 && i <= 922337202) return 10000000000 * i + j;
            if (j <= 36854775807 && i <= 92233720) return 100000000000 * i + j;
            if (j <= 99999999999 && i <= 92233719) return 1000000000000 * i + j;
            if (j <= 2036854775807 && i <= 922337) return 10000000000000 * i + j;
            if (j <= 9999999999999 && i <= 922336) return 10000000000000 * i + j;
            if (j <= 72036854775807 && i <= 92233) return 100000000000000 * i + j;
            if (j <= 99999999999999 && i <= 92232) return 100000000000000 * i + j;
            if (j <= 372036854775807 && i <= 9223) return 1000000000000000 * i + j;
            if (j <= 999999999999999 && i <= 9222) return 1000000000000000 * i + j;
            if (j <= 3372036854775807 && i <= 922) return 10000000000000000 * i + j;
            if (j <= 9999999999999999 && i <= 921) return 10000000000000000 * i + j;
            if (j <= 23372036854775807 && i <= 92) return 100000000000000000 * i + j;
            if (j <= 99999999999999999 && i <= 91) return 100000000000000000 * i + j;
            if (j <= 223372036854775807 && i <= 9) return 1000000000000000000 * i + j;
            if (j <= 999999999999999999 && i <= 8) return 1000000000000000000 * i + j;
            if (j < 0 || i < 0) throw new Exception("Appended numbers must be non-negative");
            if (i == 0) return j;
            throw new System.OverflowException($"Concatenation exceeds {long.MaxValue}");
        }

        public static long AppendClean(this long i, long j)
        {
            long magnitude = 10;
            while(j >= magnitude && magnitude < 100000000000000000)
                magnitude = magnitude * 10;
            return checked(magnitude * i + j);
        }

        public static long AppendByMagnitude(this long i, long j)
        {
            long magnitudej = j.MagnitudeByDivision();
            return checked(i * magnitudej + j);
        }

        public static long AppendByParseString(this long i, long j)
        {
            return long.Parse($"{i}{j}");
        }

        public static long AppendByConvertString(this long i, long j)
        {
            new long().
            return Convert.ToInt64($"{i}{j}");
        }
    }
}
