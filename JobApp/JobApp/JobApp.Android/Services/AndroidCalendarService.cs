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
using Android.Util;
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

          /*  ContentValues eventValues = new ContentValues();

            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId,
                2);
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                "Another event");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                "This is an event created from Xamarin.Android");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                "UTC");
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                GetDateTimeMS(2018, 05, 29, 3, 45));
            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                GetDateTimeMS(2018, 05, 29, 4, 0));

            var uri = context.ContentResolver.Insert(CalendarContract.Events.ContentUri,
                eventValues); 
                */
            try
            {

                // List Calendars
                var calendarsUri = CalendarContract.Calendars.ContentUri;

                string[] calendarsProjection = {
                        CalendarContract.Calendars.InterfaceConsts.Id,
                        CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
                        CalendarContract.Calendars.InterfaceConsts.AccountName
                    };

                var cursor = context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);
                if (calendarsProjection.Length > 0)
                {
                    for (var j = 0; j < calendarsProjection.Length; j++)
                    {
                        Log.Error("Showcase", calendarsProjection[j]);
                    }

                    cursor.MoveToPosition(1);
                    int calId = cursor.GetInt(cursor.GetColumnIndex(calendarsProjection[0]));

                    var eventValues = new ContentValues();

                    eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, calId);
                    eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                        "Event Title");
                    eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                        "Event Description");
                    eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                        GetDateTimeMS(2018, 4, 29, 2, 0));
                    eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                        GetDateTimeMS(2018, 4, 29, 4, 0));

                    eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                        "EST");
                    eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                        "EST");

                    context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
                }
                else
                {
                    Toast.MakeText(context, "No calendar found", ToastLength.Long).Show();
                }

            }
            catch (Exception ex)
            {
                Log.Error("Showcase", "exception create calendar event");
            }


            /*    var intent = new Intent(context, typeof(CalendarService));
                context.StartActivity(intent);*/

            /*   Intent calIntent = new Intent(Intent.ActionInsert);
               calIntent.SetData(CalendarContract.Events.ContentUri);
               calIntent.SetType("vnd.android.cursor.item/event");
               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, "Test Event from M4A");
               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, "This is an event created from Xamarin.Android");

               long lDtStart = GetDateTimeMS(2018, 5, 29, 2, 0);
               long lDtEnd = GetDateTimeMS(2018, 5, 29, 4, 0);

               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, lDtStart);
               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, lDtEnd);

               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
               calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

               context.StartActivity(calIntent);*/
            /*
                 ContentValues eventValues = new ContentValues();

                 eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId,
                     2);
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
                     eventValues);*/
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

            c.Set(Java.Util.CalendarField.DayOfMonth, day);
            c.Set(Java.Util.CalendarField.HourOfDay, hr);
            c.Set(Java.Util.CalendarField.Minute, min);
            c.Set(Java.Util.CalendarField.Month, month);
            c.Set(Java.Util.CalendarField.Year, yr);

            return c.TimeInMillis;
        }
    }
}