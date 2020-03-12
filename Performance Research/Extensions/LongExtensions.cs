using System;

namespace PerformanceResearch
{
    public static class LongExtensions
    {
        // Largest power of 10 less that Int64.MaxValue (10^18)
        private static readonly long MAX_MAGNITUDE = 1000000000000000000L;

        public static long Abs(this long x)
        {
            // Fast absolute value
            return (x + (x >> 63)) ^ (x >> 63);
        }

        #region Magnitude Methods

        public static long MagnitudeByMultiplication(this long x)
        {
            x = x.Abs();
            // Prevent overflow
            if (x >= MAX_MAGNITUDE)
                return MAX_MAGNITUDE;
            long magnitude = 1L;
            for (long m = 1L; m <= x; m *= 10L)
                magnitude = m;
            return magnitude;
        }

        public static long MagnitudeByMultiplication2(this long x)
        {
            x = x.Abs();
            // Prevent overflow
            if (x >= MAX_MAGNITUDE)
                return MAX_MAGNITUDE;
            long magnitude = 1L;
            while (magnitude * 10L <= x)
                magnitude *= 10L;
            return magnitude;
        }

        public static long MagnitudeByMultiplication3(this long x)
        {
            x = x.Abs();
            // Prevent overflow
            if (x >= MAX_MAGNITUDE)
                return MAX_MAGNITUDE;
            long magnitude = 10L;
            while (magnitude <= x)
                magnitude *= 10L;
            return magnitude / 10L;
        }

        public static long MagnitudeByRange(this long x)
        {
            x = x.Abs();
            if (x < 10L) return 1L;
            if (x < 100L) return 10L;
            if (x < 1000L) return 100L;
            if (x < 10000L) return 1000L;
            if (x < 100000L) return 10000L;
            if (x < 1000000L) return 100000L;
            if (x < 10000000L) return 1000000L;
            if (x < 100000000L) return 10000000L;
            if (x < 1000000000L) return 100000000L;
            if (x < 10000000000L) return 1000000000L;
            if (x < 100000000000L) return 10000000000L;
            if (x < 1000000000000L) return 100000000000L;
            if (x < 10000000000000L) return 1000000000000L;
            if (x < 100000000000000L) return 10000000000000L;
            if (x < 1000000000000000L) return 100000000000000L;
            if (x < 10000000000000000L) return 1000000000000000L;
            if (x < 100000000000000000L) return 10000000000000000L;
            if (x < MAX_MAGNITUDE) return 100000000000000000L;
            return MAX_MAGNITUDE;
        }

        public static long MagnitudeByDivision(this long x)
        {
            x = x.Abs();
            long magnitude = 1L;
            while ((x /= 10L) > 0L)
                magnitude *= 10L;
            return magnitude;
        }

        public static long MagnitudeBySwitch(this long x)
        {
            x = x.Abs();
            switch (x)
            {
                case long y when y < 10L: return 1L;
                case long y when y < 100L: return 10L;
                case long y when y < 1000L: return 100L;
                case long y when y < 10000L: return 1000L;
                case long y when y < 100000L: return 10000L;
                case long y when y < 1000000L: return 100000L;
                case long y when y < 10000000L: return 1000000L;
                case long y when y < 100000000L: return 10000000L;
                case long y when y < 1000000000L: return 100000000L;
                case long y when y < 10000000000L: return 1000000000L;
                case long y when y < 100000000000L: return 10000000000L;
                case long y when y < 1000000000000L: return 100000000000L;
                case long y when y < 10000000000000L: return 1000000000000L;
                case long y when y < 100000000000000L: return 10000000000000L;
                case long y when y < 1000000000000000L: return 100000000000000L;
                case long y when y < 10000000000000000L: return 1000000000000000L;
                case long y when y < 100000000000000000L: return 10000000000000000L;
                case long y when y < MAX_MAGNITUDE: return 100000000000000000L;
                default: return MAX_MAGNITUDE;
            }
        }

        #endregion

        #region Append Methods

        public static long AppendLoop(this long x, long y)
        {
            // Prevent overflow
            if (y >= MAX_MAGNITUDE)
                return checked(MAX_MAGNITUDE * x + y);
            long magnitude = 10L;
            while(y >= magnitude)
                magnitude = magnitude * 10L;
            return checked(magnitude * x + y);
        }

        public static long AppendByRangeChecked(this long x, long y)
        {
            if (y < 0L || x < 0L) throw new Exception("Appended numbers must be non-negative");
            if (y < 10L) return checked(10L * x + y);
            if (y < 100L) return checked(100L * x + y);
            if (y < 1000L) return checked(1000L * x + y);
            if (y < 10000L) return checked(10000L * x + y);
            if (y < 100000L) return checked(100000L * x + y);
            if (y < 1000000L) return checked(1000000L * x + y);
            if (y < 10000000L) return checked(10000000L * x + y);
            if (y < 100000000L) return checked(100000000L * x + y);
            if (y < 1000000000L) return checked(1000000000L * x + y);
            if (y < 10000000000L) return checked(10000000000L * x + y);
            if (y < 100000000000L) return checked(100000000000L * x + y);
            if (y < 1000000000000L) return checked(1000000000000L * x + y);
            if (y < 10000000000000L) return checked(10000000000000L * x + y);
            if (y < 100000000000000L) return checked(100000000000000L * x + y);
            if (y < 1000000000000000L) return checked(1000000000000000L * x + y);
            if (y < 10000000000000000L) return checked(10000000000000000L * x + y);
            if (y < 100000000000000000L) return checked(100000000000000000L * x + y);
            return checked(MAX_MAGNITUDE * x + y);
        }

        public static long AppendByRange(this long x, long y)
        {
            if (y <= 7L && x <= 922337203685477580L) return 10L * x + y;
            if (y <= 9L && x <= 922337203685477579L) return 10L * x + y;
            if (y <= 99L && x <= 92233720368547757L) return 100L * x + y;
            if (y <= 807L && x <= 9223372036854775L) return 1000L * x + y;
            if (y <= 999L && x <= 9223372036854774L) return 1000L * x + y;
            if (y <= 5807L && x <= 922337203685477L) return 10000L * x + y;
            if (y <= 9999L && x <= 922337203685476L) return 10000L * x + y;
            if (y <= 75807L && x <= 92233720368547L) return 100000L * x + y;
            if (y <= 99999L && x <= 92233720368546L) return 100000L * x + y;
            if (y <= 775807L && x <= 9223372036854L) return 1000000L * x + y;
            if (y <= 999999L && x <= 9223372036853L) return 1000000L * x + y;
            if (y <= 4775807L && x <= 922337203685L) return 10000000L * x + y;
            if (y <= 9999999L && x <= 922337203684L) return 10000000L * x + y;
            if (y <= 54775807L && x <= 92233720368L) return 100000000L * x + y;
            if (y <= 99999999L && x <= 92233720367L) return 100000000L * x + y;
            if (y <= 854775807L && x <= 9223372036L) return 1000000000L * x + y;
            if (y <= 999999999L && x <= 9223372035L) return 1000000000L * x + y;
            if (y <= 6854775807L && x <= 922337203L) return 10000000000L * x + y;
            if (y <= 9999999999L && x <= 922337202L) return 10000000000L * x + y;
            if (y <= 36854775807L && x <= 92233720L) return 100000000000L * x + y;
            if (y <= 99999999999L && x <= 92233719L) return 1000000000000L * x + y;
            if (y <= 2036854775807L && x <= 922337L) return 10000000000000L * x + y;
            if (y <= 9999999999999L && x <= 922336L) return 10000000000000L * x + y;
            if (y <= 72036854775807L && x <= 92233L) return 100000000000000L * x + y;
            if (y <= 99999999999999L && x <= 92232L) return 100000000000000L * x + y;
            if (y <= 372036854775807L && x <= 9223L) return 1000000000000000L * x + y;
            if (y <= 999999999999999L && x <= 9222L) return 1000000000000000L * x + y;
            if (y <= 3372036854775807L && x <= 922L) return 10000000000000000L * x + y;
            if (y <= 9999999999999999L && x <= 921L) return 10000000000000000L * x + y;
            if (y <= 23372036854775807L && x <= 92L) return 100000000000000000L * x + y;
            if (y <= 99999999999999999L && x <= 91L) return 100000000000000000L * x + y;
            if (y <= 223372036854775807L && x <= 9L) return MAX_MAGNITUDE * x + y;
            if (y <= 999999999999999999L && x <= 8L) return MAX_MAGNITUDE * x + y;
            if (y < 0L || x < 0L) throw new Exception("Appended numbers must be non-negative");
            if (x == 0L) return y;
            throw new System.OverflowException($"Concatenation exceeds {long.MaxValue}");
        }

        public static long AppendByMagnitude(this long x, long y)
        {
            return checked(x * 10L * x.MagnitudeByMultiplication() + y);
        }

        #endregion

        #region Slow Methods

        public static long MagnitudeByString(this long x)
        {
            x = x.Abs();
            long magnitude = 1L;
            int power = x.ToString().Length;
            for (; power > 1L; power--)
                magnitude *= 10L;
            return magnitude;
        }

        public static long MagnitudeByLog(this long x)
        {
            x = x.Abs();
            long magnitude = 1L;
            int power = (int)(Math.Log10(Convert.ToDouble(x)));
            while (power-- >= 1L)
                magnitude *= 10L;
            return magnitude;
        }

        public static long AppendByParseString2(this long x, long y)
        {
            return long.Parse(x.ToString() + y.ToString());
        }

        public static long AppendByParseString(this long x, long y)
        {
            return long.Parse($"{x}{y}");
        }

        public static long AppendByConvertString(this long x, long y)
        {
            return Convert.ToInt64($"{x}{y}");
        }

        public static long AppendByConvertString2(this long x, long y)
        {
            return Convert.ToInt64(x.ToString() + y.ToString());
        }

        #endregion
    }
}
