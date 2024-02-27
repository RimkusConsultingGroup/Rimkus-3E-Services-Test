using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Extension
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date">Initial Date</param>
        /// <param name="days">Buisness Days to add</param>
        /// <returns></returns>
        public static DateTime AddBusinessDays(this DateTime date, int days)
        {
            if (days < 0)
            {
                throw new ArgumentException("days cannot be negative", "days");
            }

            if (days == 0) return date;

            if (date.DayOfWeek == DayOfWeek.Saturday)
            {
                date = date.AddDays(2);
                days -= 1;
            }
            else if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                date = date.AddDays(1);
                days -= 1;
            }

            date = date.AddDays(days / 5 * 7);
            int extraDays = days % 5;

            if ((int)date.DayOfWeek + extraDays > 5)
            {
                extraDays += 2;
            }

            return date.AddDays(extraDays);

        }

        public static int GetQuarter(this DateTime date)
        {
            return (int)Math.Ceiling(date.Month / 3.0);
        }

        public static DateTime GetQuarterStartingDate(this DateTime date)
        {
            return new DateTime(date.Year, (3 * date.GetQuarter()) - 2, 1);
        }

        public static string ToSQLFormat(this DateTime? dateTime)
        {
            if (!dateTime.HasValue)
                return string.Empty;
            return dateTime?.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        public static string ToSQLFormat(this DateTime dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
