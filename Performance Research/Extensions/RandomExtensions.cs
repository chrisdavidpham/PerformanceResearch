using System;

namespace RandomExtensions
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random long number between 0 and Int64.MaxValue
        /// </summary>
        /// <param name="random">This Random object</param>
        /// <param name="max">Maximum allowed random number. Defaults to Int64.MaxValue</param>
        /// <returns></returns>
        public static Int64 NextLong(this Random random)
        {
            return (Int64)random.NextDouble() * Int64.MaxValue;
        }

        /// <summary>
        /// Returns a random long number between 0 and max
        /// </summary>
        /// <param name="random">This Random object</param>
        /// <param name="max">Maximum allowed random number. Defaults to Int64.MaxValue</param>
        /// <returns></returns>
        public static Int64 NextLong(this Random random, Int64 max = Int64.MaxValue)
        {
            return (Int64)random.NextDouble() * max;
        }

        /// <summary>
        /// Returns a random long number between min and max
        /// </summary>
        /// <param name="random">This Random object</param>
        /// <param name="max">Maximum allowed random number. Defaults to Int64.MaxValue</param>
        /// <param name="min">Minimum allowed random number. Defaults to Int64.MinValue</param>
        /// <returns></returns>        
        public static Int64 NextLong(this Random random, Int64 min = Int64.MinValue, Int64 max = Int64.MaxValue)
        {
            if (min < 0 || max < 0)
            {
                throw new Exception("Numbers must be greater than 0.");
            }
            if (min > max)
            {
                throw new Exception("Max must be greater than or equal to min.");
            }
            Int64 range = max - min;
            Int64 ran = (Int64)(random.NextDouble() * range);
            return ran + min;
        }
    }
}
