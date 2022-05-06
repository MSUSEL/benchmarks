using System;

namespace MediaBrowser.Controller.Library
{
    /// <summary>
    /// Class TVUtils
    /// </summary>
    public static class TVUtils
    {
        /// <summary>
        /// Gets the air days.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns>List{DayOfWeek}.</returns>
        public static DayOfWeek[] GetAirDays(string day)
        {
            if (!string.IsNullOrEmpty(day))
            {
                if (string.Equals(day, "Daily", StringComparison.OrdinalIgnoreCase))
                {
                    return new[]
                    {
                        DayOfWeek.Sunday,
                        DayOfWeek.Monday,
                        DayOfWeek.Tuesday,
                        DayOfWeek.Wednesday,
                        DayOfWeek.Thursday,
                        DayOfWeek.Friday,
                        DayOfWeek.Saturday
                    };
                }

                if (Enum.TryParse(day, true, out DayOfWeek value))
                {
                    return new[]
                    {
                        value
                    };
                }

                return new DayOfWeek[] { };
            }
            return null;
        }
    }
}
