<Query Kind="Program" />

/*
 * Calculate tools based on the following
 * Weekday, Rush Hour, Inbound : $2.00
 * Weekday, Rush Hour, Outbound: $1.75
 * Weekday, Daytime:             $1.00
 * Weekday, Night Time:          $0.75
 * Weekends:                     $0.50
 * If in doubt:                  $1.00
 */

void Main()
{
	var input = (true, TollDirection.Inbound, TollTime.Night);
	decimal value = TollCalculator.CalculateTollValue(input.Item1, input.Item2, input.Item3);
	value.Dump(input.ToString());

	var input2 = (true, TollDirection.Outbound, TollTime.RushHour);
	decimal value2 = TollCalculator.CalculateTollValue(input2.Item1, input2.Item2, input2.Item3);
	value2.Dump(input2.ToString());
}

public static class TollCalculator
{
	private static Dictionary<Func<bool, TollTime, TollDirection, bool>, decimal> _tolls = new Dictionary<Func<bool, TollTime, TollDirection, bool>, decimal>()
	{
		{(isWeekday, time, direction) => isWeekday && time == TollTime.RushHour && direction == TollDirection.Inbound, 2M},
		{(isWeekday, time, direction) => isWeekday && time == TollTime.RushHour && direction == TollDirection.Outbound, 1.75M},
		{(isWeekday, time, direction) => isWeekday && time == TollTime.Daytime, 1M},
		{(isWeekday, time, direction) => isWeekday && time == TollTime.Night, .75M},
		{(isWeekday, time, direction) => isWeekday == false, .50M},
		{(isWeekday, time, direction) => true, 1M},
	};

	public static decimal CalculateTollValue(bool isWeekend, TollDirection direction, TollTime time)
	{
		decimal result = decimal.Zero;

		foreach (var kvp in _tolls)
		{
			var eval = kvp.Key;
			bool useThisToll = eval(isWeekend, time, direction);
			if (useThisToll)
			{
				result = kvp.Value;
				break;
			}
		}

		return result;
	}
}

public enum TollDirection
{
	Inbound, Outbound
}

public enum TollTime
{
	RushHour, Daytime, Night
}

// Define other methods and classes here
