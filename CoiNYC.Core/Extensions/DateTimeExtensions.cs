using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CoiNYC.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? ToBeginOfDay(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToBeginOfDay();
            }
            else { return dateTime; }
        }

        public static DateTime? ToEndOfDay(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
            {
                return dateTime.Value.ToEndOfDay();
            }
            else { return dateTime; }
        }

        public static DateTime ToBeginOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               0, 0, 0, 0);
        }

        public static DateTime ToEndOfDay(this DateTime dateTime)
        {
            return new DateTime(
               dateTime.Year,
               dateTime.Month,
               dateTime.Day,
               23, 59, 59, 999);
        }

        public static string ToFullString(this DateTime dateTime)
        {

            return dateTime.ToString(DateTimeFormatInfo.CurrentInfo.UniversalSortableDateTimePattern);
        }

        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm");
        }

        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString(DateTimeFormatInfo.CurrentInfo.ShortDatePattern);
        }
        public static string ToStandardDateString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToStandardDateString();

            return String.Empty;
        }
        public static string ToStandardDateTimeString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToStandardDateTimeString();

            return String.Empty;
        }

        public static string ToStandardDateString(this DateTime dateTime)
        {
            return dateTime.ToString("d");
        }
        public static string ToStandardDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("d")+" "+dateTime.ToString("HH:mm");
        }


        public static string ToSortableDateString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToStandardDateString();

            return String.Empty;
        }
        public static string ToSortableDateTimeString(this DateTime? dateTime)
        {
            if (dateTime.HasValue)
                return dateTime.Value.ToStandardDateTimeString();

            return String.Empty;
        }

        public static string ToSortableDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static string ToSortableDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
