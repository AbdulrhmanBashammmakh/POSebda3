using System;

namespace POSebda3.Services
{
    public static class Generator
    {
        public static int gen()
        {
            DateTime centuryBegin = new DateTime(2020, 1, 1);
            DateTime currentDate = DateTime.Now;
            long elapsedTicks = currentDate.Ticks - centuryBegin.Ticks;
            TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
            return (int)Math.Round(elapsedSpan.TotalSeconds);
        }


    }
}
