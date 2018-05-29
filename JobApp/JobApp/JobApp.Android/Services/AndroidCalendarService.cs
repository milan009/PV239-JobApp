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
        }

        /*
         * This method handles saving to events by using Intents - calendar app is
         * opened and user has the ability to manually edit the event before saving it.
         * It is somewhat more flexible and robust, but requires more interaction from the user.
         */
        private void SaveEventIntent(
            MainActivity context,
            string eventTitle,
            string eventDescription,
            DateTime starTime,
            DateTime endTime)
        {
            Intent calIntent = new Intent(Intent.ActionInsert);
            calIntent.SetData(CalendarContract.Events.ContentUri);
            calIntent.SetType("vnd.android.cursor.item/event");

            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Title, eventTitle);
            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Description, eventDescription);

            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtstart, PrepareTime(starTime));
            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.Dtend, PrepareTime(endTime));

            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "UTC");
            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "UTC");

            context.StartActivity(calIntent);
        }

        private void SaveEventIntent(
            MainActivity context,
            string eventTitle,
            string eventDescription,
            DateTime starTime)
        {
            SaveEventIntent(context, eventTitle, eventDescription, starTime,starTime + TimeSpan.FromHours(1));
        }

        /*
         * This method saves events just by using ContentResolver API. Is more prone to errors
         * and for some reasons always makes the event start and end one month after desired date.
         * On the other hand, it could be easier to automate - currently, only selecting which
         * calendar to use is nescessary.
         */
        private void SaveEventDialog(
            MainActivity context,
            string eventTitle,
            string eventDescription,
            DateTime starTime,
            DateTime endTime)
        {
            try
            {
                var calendarsUri = CalendarContract.Calendars.ContentUri;

                string[] calendarsProjection =
                {
                    CalendarContract.Calendars.InterfaceConsts.Id,
                    CalendarContract.Calendars.InterfaceConsts.CalendarDisplayName,
                    CalendarContract.Calendars.InterfaceConsts.AccountName
                };

                var cursor = context.ContentResolver.Query(calendarsUri, calendarsProjection, null, null, null);
                if (cursor.Count > 0)
                {
                    var dbuilder = new AlertDialog.Builder(context);
                    dbuilder
                        .SetTitle("Zvolte kalendář");

                    var items = new List<string>();

                    while (cursor.MoveToNext())
                    {
                        var displayName = cursor.GetString(cursor.GetColumnIndex(calendarsProjection[1]));
                        items.Add(displayName);
                    }

                    dbuilder.SetItems(items.ToArray(),
                        (sender, args) =>
                        {
                            var eventValues = new ContentValues();

                            eventValues.Put(CalendarContract.Events.InterfaceConsts.CalendarId, args.Which + 1);
                            eventValues.Put(CalendarContract.Events.InterfaceConsts.Title,
                                eventTitle);
                            eventValues.Put(CalendarContract.Events.InterfaceConsts.Description,
                                eventDescription);
                            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtstart,
                                PrepareTime(starTime));
                            eventValues.Put(CalendarContract.Events.InterfaceConsts.Dtend,
                                PrepareTime(endTime));

                            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventTimezone,
                                "UTC");
                            eventValues.Put(CalendarContract.Events.InterfaceConsts.EventEndTimezone,
                                "UTC");

                            context.ContentResolver.Insert(CalendarContract.Events.ContentUri, eventValues);
                        });

                    dbuilder.Show();
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
        }

        List<IInterview> ICalendarService.GetEventsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        List<IInterview> ICalendarService.GetInterviewsById(Guid jobGuid)
        {
            throw new NotImplementedException();
        }

        private long PrepareTime(DateTime time)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Java.Util.CalendarField.DayOfMonth, time.Day);
            c.Set(Java.Util.CalendarField.HourOfDay, time.Hour);
            c.Set(Java.Util.CalendarField.Minute, time.Minute);
            c.Set(Java.Util.CalendarField.Month, time.Month);
            c.Set(Java.Util.CalendarField.Year, time.Year);

            return c.TimeInMillis;
        }
    }
}