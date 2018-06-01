using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Provider;
using Android.Util;
using Android.Widget;
using Java.Util;
using JobApp.Droid.Services;
using JobApp.Shared.Interfaces;
using JobApp.Shared.Interfaces.Services;
using JobApp.Shared.Models;
using XamarinToolkit.Interfaces.Models;


[assembly: Xamarin.Forms.Dependency(typeof(AndroidCalendarService))]

namespace JobApp.Droid.Services
{
    class AndroidCalendarService : ICalendarService
    {
        public void StoreCalendarEvent(Interview interviewToStore)
        {
            var context = MainActivity.Instance;
            SaveEventIntent(context, interviewToStore.JobOffer.Position, interviewToStore.JobOffer.Note, interviewToStore.Date);
           // SaveEventDialog(context, interviewToStore.JobOffer.Position, interviewToStore.JobOffer.Note, interviewToStore.Date, interviewToStore.Date + TimeSpan.FromHours(1));       
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

            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventTimezone, "GMT+2");
            calIntent.PutExtra(CalendarContract.Events.InterfaceConsts.EventEndTimezone, "GMT+2");
            
            context.StartActivityForResult(calIntent, 7);


        }

        private void SaveEventIntent(
            MainActivity context,
            string eventTitle,
            string eventDescription,
            DateTime starTime)
                => SaveEventIntent(context, eventTitle, eventDescription, starTime,starTime + TimeSpan.FromHours(1));
        
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
            catch
            {
                Log.Error("Showcase", "exception create calendar event");
            }
        }

        private long PrepareTime(DateTime time)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(CalendarField.DayOfMonth, time.Day);
            c.Set(CalendarField.HourOfDay, time.Hour);
            c.Set(CalendarField.Minute, time.Minute);
            c.Set(CalendarField.Month, time.Month);
            c.Set(CalendarField.Year, time.Year);

            return c.TimeInMillis;
        }
    }
}