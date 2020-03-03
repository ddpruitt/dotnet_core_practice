using System;

namespace DC.TupleDiscardSwitch.Con
{
    public enum TollDirection
    {
        Inbound,
        Outbound
    }

    public enum TollTime
    {
        Daytime,
        Nighttime,
        RushHour
    }

    public static class TollCalculations
    {

        public static bool IsWeekday(DateTime when) =>
            when.DayOfWeek switch
            {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true
            };

        public static bool IsTimeBetween(TimeSpan start, TimeSpan end, DateTime value) =>
            start <= value.TimeOfDay && value.TimeOfDay <= end;

        public static TollTime GetTollTime(DateTime when)
        {
            if (IsTimeBetween(new TimeSpan(hours: 6, minutes: 0, seconds: 0), new TimeSpan(hours: 6, minutes: 0, seconds: 0), when)) return TollTime.RushHour;
            if (IsTimeBetween(new TimeSpan(hours: 17, minutes: 0, seconds: 0), new TimeSpan(hours: 20, minutes: 0, seconds: 0), when))  return TollTime.RushHour;

            if (IsTimeBetween(new TimeSpan(hours: 0, minutes: 0, seconds: 0), new TimeSpan(hours: 6, minutes: 0, seconds: 0), when)) return TollTime.Nighttime;
            if (IsTimeBetween(new TimeSpan(hours: 20, minutes: 0, seconds: 0), new TimeSpan(hours: 24, minutes: 0, seconds: 0), when)) return TollTime.Nighttime;

            return TollTime.Daytime;
        }

        /* Calculate Tolls based on following:
           Weekday, Rush Hour, Inbound:   $2.00
           Weekday, Rush Hour, Outbound:  $1.75
           Weekday, Daytime:              $1.00
           Weekday, Night Time:           $0.75
           Weekends:                      $0.50
           If in doubt:                   $1.00
        */
        public static decimal GetTollAmount(DateTime when, TollDirection direction) =>
            (IsWeekday(when), direction, GetTollTime(when)) switch
            {
                (true, TollDirection.Inbound, TollTime.RushHour) => 2.00M,
                (true, TollDirection.Outbound, TollTime.RushHour) => 1.75M,

                (true, _, TollTime.Daytime) => 1.00M,

                (true, _, TollTime.Nighttime) => 0.75M,

                (false, _, _) => 0.50M,
                
                _ => 1.00M
            };
    }


}