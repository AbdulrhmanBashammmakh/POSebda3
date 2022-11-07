namespace POSebda3.Services
{
    public static class NumberHelper
    {
        public static int ClosestNumberInSequence(this int number, int interval)
        {
            var remainder = number % interval;

            if (remainder == 0)
                return number;

            var start = number - remainder;
            var next = start + interval;

            return next;
        }


    }
}
