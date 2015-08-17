using System.ComponentModel;
using System.Globalization;
using System.Threading;

namespace System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
#if INTERNAL
    internal
#else
    public 
#endif
        static class DateExtensionMethods
    {


        public static  bool DateBetweenWithExtremes(this DateTime date, DateTime min, DateTime max)
        {
            return date >= min && date < max.AddDays(+1);
        }

        public static bool DateBetweenWithExtremes(this DateTime date, DateTime? min, DateTime? max)
        {
            if (min.HasValue && max.HasValue)
                return date >= min.Value && date < max.Value.AddDays(+1);

            if (min.HasValue)
                return date >= min.Value;

            if (max.HasValue)
                return date < max.Value.AddDays(+1);

            return true;
        }

        public static bool DateBetweenWithoutExtremes(this DateTime date, DateTime min, DateTime max)
        {
            return date > min && date < max;
        }
        
        public static TimeSpan ElapsedTime(this DateTime fecha)
        {
            return DateTime.Now - fecha;
        }

        public static int ElapsedMilliseconds(this DateTime fecha)
        {
            return (int) (DateTime.Now - fecha).TotalMilliseconds;
        }

        public static string SqlDate(this DateTime fecha)
        {
            if (fecha == DateTime.MinValue)
                return "NULL";
            else
                return "'" + fecha.ToString("yyyyMMdd") + "'";
        }

        public static string SqlDateTime(this DateTime fecha)
        {
            if (fecha == DateTime.MinValue)
                return "NULL";
            else if (fecha.TimeOfDay.TotalMilliseconds == 0)
                return "'" + fecha.ToString("yyyyMMdd") + "'";
            else
                return "'" + fecha.ToString("yyyyMMdd HH:mm:ss.fff") + "'";
        }

        public static string SqlDate(this DateTime? fecha)
        {
            if (!fecha.HasValue || fecha == DateTime.MinValue)
                return "NULL";
            else
                return "'" + fecha.Value.ToString("yyyyMMdd") + "'";
        }

        public static string SqlDateTime(this DateTime? fecha)
        {
            if (!fecha.HasValue || fecha == DateTime.MinValue)
                return "NULL";
            else if (fecha.Value.TimeOfDay.TotalMilliseconds == 0)
                return "'" + fecha.Value.ToString("yyyyMMdd") + "'";
            else
                return "'" + fecha.Value.ToString("yyyyMMdd HH:mm:ss.fff") + "'";
        }

        public static string AbbreviatedDayName(this DateTime Fecha, CultureInfo culture = null)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture;

            string dia = culture.DateTimeFormat.GetAbbreviatedDayName(Fecha.DayOfWeek).ToUpper();
            dia = dia.Replace("É", "E").Replace("Á", "A");
            return dia;
        }

        /// <summary>
        /// Returns the original DateTime with Hour, Minute and Second parts changed to supplied hour, minute and second parameters
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetTime(this DateTime originalDate, int hour, int minute, int second)
        {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, minute, second, originalDate.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Hour part
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        public static DateTime SetHour(this DateTime originalDate, int hour)
        {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, hour, originalDate.Minute, originalDate.Second, originalDate.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Minute part
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static DateTime SetMinute(this DateTime originalDate, int minute)
        {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, minute, originalDate.Second, originalDate.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Second part
        /// </summary>
        /// <param name="originalDate"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static DateTime SetSecond(this DateTime originalDate, int second)
        {
            return new DateTime(originalDate.Year, originalDate.Month, originalDate.Day, originalDate.Hour, originalDate.Minute, second, originalDate.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Year, Month and Day part
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDate(this DateTime value, int year, int month, int day)
        {
            return new DateTime(year, month, day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        public static DateTime FirstDayOfThisMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1);
        }
        
        public static DateTime LastTimeOfDay(this DateTime value)
        {
            return value.Date.AddDays(1).AddMilliseconds(-1);
        }

        public static DateTime FirstDayOfThisWeek(this DateTime value)
        {
            return value.AddDays(-(int) value.DayOfWeek);
        }
        public static DateTime FirstWorkingDayOfThisMonth(this DateTime value)
        {
            var res = new DateTime(value.Year, value.Month, 1);
            while (!res.IsWorkingDay())
                res = res.AddDays(1);

            return res;
        }

        public static bool IsFirstDayOfYear(this DateTime value)
        {
            return value.Day == 1 && value.Month == 1;
        }

        public static bool IsFirstDayOfYear(this DateTime? value)
        {
            return value.HasValue && value.Value.Day == 1 && value.Value.Month == 1;
        }

        public static DateTime LastDayOfThisMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, DateTime.DaysInMonth(value.Year, value.Month));
        }

        public static DateTime LastDayOfPreviousMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, 1).AddDays(-1);
        }


        public static DateTime FirstDayOfPreviousMonth(this DateTime value)
        {
            value = value.AddMonths(-1);
            return new DateTime(value.Year, value.Month, 1);
        }

        /// <summary>
        /// Returns DateTime with changed Year part
        /// </summary>
        /// <param name="value"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static DateTime SetYear(this DateTime value, int year)
        {
            return new DateTime(year, value.Month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Month part
        /// </summary>
        /// <param name="value"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static DateTime SetMonth(this DateTime value, int month)
        {
            return new DateTime(value.Year, month, value.Day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Returns DateTime with changed Day part
        /// </summary>
        /// <param name="value"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static DateTime SetDay(this DateTime value, int day)
        {
            return new DateTime(value.Year, value.Month, day, value.Hour, value.Minute, value.Second, value.Millisecond);
        }

        /// <summary>
        /// Retorna la fecha con formato yyyyMMdd
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToYearMonthDay(this DateTime value)
        {
            return value.ToString("yyyyMMdd");
        }


    
        public static int WorkingDaysToToday(this DateTime value)
        {
            value = value.Date;
            if (value <= DateTime.Today)
            {
                var dias = 0;
                
                while(value < DateTime.Today)
                {
                    if (value.IsWorkingDay())
                        dias++;

                    value = value.AddDays(1);
                }
                return dias;
            }

            throw new InvalidOperationException("La fecha es en el futuro");
        }

        public static int DaysToToday(this DateTime value)
        {
            value = value.Date;
            if (value <= DateTime.Today)
            {
                return (int) (DateTime.Today - value).TotalDays;
            }

            throw new InvalidOperationException("La fecha es en el futuro");
        }

        public static int WorkingHoursToNow(this DateTime value)
        {
            var now = DateTime.Now;
            if (value <= now)
            {
                var horas = 0;

                while (value < now)
                {
                    if (value.IsWorkingDay())
                        horas++;

                    value = value.AddHours(1);
                }

                return horas;
            }

            throw new InvalidOperationException("La fecha es en el futuro");
        }


        public static int HoursToNow(this DateTime value)
        {
            return (int) (DateTime.Now - value).TotalHours;
        }

        public static TimeSpan TimeSpanToNow(this DateTime value)
        {
            return DateTime.Now - value;
        }

        /// <summary>
        /// Retorna la fecha actual en formato Unix Time (los segundos que pasaron desde la medianoche del 01/01/1970)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToUnixTimestamp(this DateTime value)
        {
            var t = (value - new DateTime(1970, 1, 1));
            return (int) t.TotalSeconds;
        }


        /// <summary>
        /// Retorna la fecha actual en formato Unix Time (los segundos que pasaron desde la medianoche del 01/01/1970)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToJavaScriptTimestamp(this DateTime value)
        {
            return (long) value.ToUniversalTime()
                .Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc))
                .TotalMilliseconds;
        }

        ///// <summary>
        ///// Retorna la fecha convertida a Unix Time
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public static int DateToSpan(this DateTime value, DateTime date)
        //{
        //    TimeSpan t = (date.ToUniversalTime() - new DateTime(1970, 1, 1));
        //    int timestamp = (int)t.TotalSeconds;
        //    return timestamp;
        //}

        /// <summary>
        /// Returns the original DateTime with Hour, Minute and Second parts changed to 12:00:00 am
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Date1200AM(this DateTime date)
        {
            return date.Date;
        }

        /// <summary>
        ///  Create a copy of the DateTime as UTC without changing nothing
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime CreateAsUtc(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, DateTimeKind.Utc);
        }

        /// <summary>
        /// Returns the original DateTime with Hour, Minute and Second parts changed to 23:59:59 pm
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static DateTime Date2359PM(this DateTime date)
        {
            return date.Date.AddMilliseconds(-1);
        }


        public static string AsReadableFull(this TimeSpan ts)
        {
            if (ts.TotalDays >= 1)
                return ts.Days + "d " +
                    //(ts.Days == 1 ? " " : "s ") 
                    + ts.Hours + "h " 
                    + (ts.Minutes == 0 && ts.Seconds == 0 ? string.Empty : ts.Minutes + "m ")
                    + (ts.Seconds == 0 ? string.Empty : ts.Seconds + "s");
            
            if (ts.TotalHours >= 1)
                return ts.Hours + "h "
                       + (ts.Minutes == 0 && ts.Seconds == 0 ? string.Empty : ts.Minutes + "m ")
                       + (ts.Seconds == 0 ? string.Empty : ts.Seconds + "s");
            
            return ts.Minutes + "m"
                   + (ts.Seconds == 0 ? string.Empty : ts.Seconds + " s");
        }


        public static string ToPrintable(this DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return "Domingo";
                case DayOfWeek.Monday:
                    return "Lunes";
                case DayOfWeek.Tuesday:
                    return "Martes";
                case DayOfWeek.Wednesday:
                    return "Miercoles";
                case DayOfWeek.Thursday:
                    return "Jueves";
                case DayOfWeek.Friday:
                    return "Viernes";
                case DayOfWeek.Saturday:
                    return "Sabado";
                default:
                    throw new ArgumentOutOfRangeException("day");
            }
        }


        public static DateTime NextDayOfWeek(this DateTime value, DayOfWeek day)
        {
            if (value.DayOfWeek == day)
                return value;

            int diff = day - value.DayOfWeek;

            if (diff > 0)
                return value.AddDays(diff);
            else
                return value.AddDays(7 + diff);
        }



        public static string AsSimplifiedTime(this DateTime value)
        {
            var diff = DateTime.Now - value;
            var today = DateTime.Today;

            if (diff.TotalSeconds < 60)
                return "hace " + diff.Seconds + "s";

            if (diff.TotalMinutes < 60)
                return "hace " + diff.Minutes + "m";

            return value.ToString("HH:mm");
        }

        public static string AsSimplifiedTimeToSeconds(this DateTime value)
        {
            var diff = DateTime.Now - value;
            var today = DateTime.Today;

            if (diff.TotalSeconds < 60)
                return "hace " + diff.Seconds + "s";

            if (diff.TotalMinutes < 60)
                return "hace " + diff.Minutes + "m";

            return value.ToString("HH:mm:ss");
        }

        
        public static bool IsValidSqlSmallDateTime(this DateTime date)
        {
            var minSmallDateTime = new DateTime(1900, 1, 1);
            var maxSmallDateTime = new DateTime(2079, 6, 6);
            return date >= minSmallDateTime
                   && date <= maxSmallDateTime;
        }

        public static bool IsValidSqlDateTime(this DateTime date)
        {
            var minDateTime = new DateTime(1753, 1, 1);
            var maxDateTime = new DateTime(9999, 12, 31);
            return date >= minDateTime
                   && date <= maxDateTime;
        }

        public static bool IsBetween(this DateTime date, DateTime from, DateTime to, bool includeExtrems = true)
        {
            if (includeExtrems)
                return date >= from && date <= to;
            else
                return date > from && date < to;
        }

        /// <summary>
        /// Retorna la fecha con formato dd/MM/yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPrintable(this DateTime date)
        {
            return date.ToPrintable('/');
        }

        /// <summary>
        /// Retorna la fecha con formato dd/MM/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToStringDayMonthYear(this DateTime date)
        {
            return ToStringDayMonthYear(date, '/');
        }

        /// <summary>
        /// Retorna la fecha con formato dd/MM/yyyy
        /// </summary>
        /// <param name="date"></param>
        /// <param name="separator">The separator of the dd{sep}MM{sep}yyyy. Default is /</param>
        /// <returns></returns>
        public static string ToStringDayMonthYear(this DateTime date, char separator)
        {
            return date.ToString("dd" + separator + "MM" + separator + "yyyy");
        }
        
        /// <summary>
        /// Retorna la fecha con formato dd[sep]MM[sep]yyyy
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPrintable(this DateTime date, char sep)
        {
            return date.ToString("dd" + sep + "MM" + sep + "yyyy");
        }

        /// <summary>
        /// Retorna la fecha con formato dd/MM/yyyy HH:ss
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPrintableWithTime(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm");
        }

        public static DateTime LastDayOfWeekFromThis(this DateTime date, DayOfWeek dayOfWeek)
        {
            var res = date.AddDays(-1);
            while (res.DayOfWeek != dayOfWeek)
                res = res.AddDays(-1);

            return res;
        }

        public static bool IsWorkingDay(this DateTime date)
        {
            return date.DayOfWeek != DayOfWeek.Saturday
                    && date.DayOfWeek != DayOfWeek.Sunday;
        }

        public static bool IsSameMonth(this DateTime date, DateTime other)
        {
            return date.Year == other.Year
                   && date.Month == other.Month;
        }
        
    }
}
