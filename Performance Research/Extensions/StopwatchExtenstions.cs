using System;
using System.Diagnostics;

namespace StopwatchExtensions
{
    public static class StopwatchExtensions
    {
        /// <summary>
        /// Measures the time to invoke and execute <paramref name="func"/>.
        /// </summary>
        /// <param name="stopwatch">This Stopwatch.</param>
        /// <param name="func">A System.Func<T>.</param>
        /// <returns>Total milliseconds elapsed by this instance.</returns>
        static public TimeSpan Time<T>(this Stopwatch stopwatch, Func<T> func, out T funcOut)
        {
            stopwatch.Restart();
            funcOut = func();
            return stopwatch.Elapsed;
        }

        /// <summary>
        /// Measures the time to invoke and execute <paramref name="action"/>.
        /// </summary>
        /// <param name="stopwatch">This Stopwatch</param>
        /// <param name="action">A System.Action</param>
        /// <returns>Total milliseconds elapsed by this instance.</returns>
        static public TimeSpan Time(this Stopwatch stopwatch, System.Action action)
        {
            stopwatch.Restart();
            action();
            return stopwatch.Elapsed;
        }
    }
}
