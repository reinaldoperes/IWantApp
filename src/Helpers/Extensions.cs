public static class Extensions
{
	static TimeZoneInfo StandartTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

	public static DateTime ToBrazilianTime(this DateTime source)
	  => TimeZoneInfo.ConvertTimeFromUtc(source, StandartTimeZone);
}
