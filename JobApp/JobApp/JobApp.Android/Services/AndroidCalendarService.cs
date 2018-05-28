using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;
using JobApp.Droid.Services;
using JobApp.Models;
using JobApp.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidCalendarService))]

namespace JobApp.Droid.Services
{
    class AndroidCalendarService : ICalendarService
    {
        public void StoreCalendarEvent(IInterview interviewToStore)
        {
            var context = MainActivity.Instance;
            /*    var intent = new Intent(context, typeof(CalendarService));
                context.StartActivity(intent);*/

            ContentValues eventValues = new ContentValues();

            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId,
                0);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                "Test Event from M4A");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                "This is an event created from Xamarin.Android");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                GetDateTimeMS(2018, 05, 28, 18, 45));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                GetDateTimeMS(2018, 05, 28, 19, 0));

            var uri = context.ContentResolver.Insert(CalendarContract.Events.ContentUri,
                eventValues);

        }

        List<IInterview> ICalendarService.GetEventsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        List<IInterview> ICalendarService.GetInterviewsById(Guid jobGuid)
        {
            throw new NotImplementedException();
        }

        long GetDateTimeMS(int yr, int month, int day, int hr, int min)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Java.Util.CalendarField.DayOfMonth, 15);
            c.Set(Java.Util.CalendarField.HourOfDay, hr);
            c.Set(Java.Util.CalendarField.Minute, min);
            c.Set(Java.Util.CalendarField.Month, Calendar.December);
            c.Set(Java.Util.CalendarField.Year, 2011);

            return c.TimeInMillis;
        }
    }
}