using System;

namespace DC.TupleDiscardSwitch.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            var year = DateTime.UtcNow.Year;
            var month = DateTime.UtcNow.Month;

            var lastDayOfMonth = new DateTime(year, DateTime.UtcNow.AddMonths(1).Month, 1).AddDays(-1).Day;
            for (int day = 1; day <= lastDayOfMonth; day++)
            {
                for (int hour = 0; hour < 24; hour++)
                {
                    var when = new DateTime(year: year, month: month, day: day, hour: hour, 0, 0);
                    Console.WriteLine($" {when.ToString("g") .PadRight(20)} ::  {TollCalculations.GetTollTime(when).ToString().PadLeft(9)} :::  InBound :: {TollCalculations.GetTollAmount(when, TollDirection.Inbound)} ::: OutBound :: {TollCalculations.GetTollAmount(when, TollDirection.Outbound)}");
                }

                Console.WriteLine(new string('-', 80));
            }
            Console.WriteLine(new string('*', 80));
        }
    }
}
