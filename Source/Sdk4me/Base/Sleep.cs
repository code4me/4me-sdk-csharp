using System;
using System.Threading;

namespace Sdk4me
{
    /// <summary>
    /// A class to force a 116 milliseconds sleep.
    /// </summary>
    internal static class Sleep
    {
        private const int minimumDurationPerRequestInMiliseconds = 116;
        private static int startTickCount = 0;

        /// <summary>
        /// Stores the current Environment.TickCount value. This value will be used by the <see cref="SleepRemainingTime"/> method.
        /// </summary>
        public static void RegisterStartTime()
        {
            startTickCount = Environment.TickCount;
        }

        /// <summary>
        /// Puts the current thread in sleep for 116 milliseconds minus the elapsed milliseconds between now an the value stored via the <see cref="RegisterStartTime"/> method.
        /// </summary>
        public static void SleepRemainingTime()
        {
            int endTickCount = Environment.TickCount;

            if (endTickCount <= startTickCount)
            {
                Thread.Sleep(minimumDurationPerRequestInMiliseconds);
            }
            else
            {
                int sleepTicks = minimumDurationPerRequestInMiliseconds - endTickCount - startTickCount;
                if (sleepTicks > 0)
                    Thread.Sleep(sleepTicks);
            }
        }
    }
}
