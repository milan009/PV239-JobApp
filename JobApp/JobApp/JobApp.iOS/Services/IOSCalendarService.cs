using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EventKit;
using Foundation;
using JobApp.iOS.Services;
using JobApp.Models;
using JobApp.Services;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(IOSCalendarService))]

namespace JobApp.iOS.Services
{
    class CalendarHelper
    {
        public static CalendarHelper Current
        {
            get { return current; }
        }
        private static CalendarHelper current;

        public EKEventStore EventStore
        {
            get { return eventStore; }
        }
        protected EKEventStore eventStore;

        static CalendarHelper()
        {
            current = new CalendarHelper();
        }
        protected CalendarHelper()
        {
            eventStore = new EKEventStore();
        }

    }

    class IOSCalendarService : ICalendarService
    {
        public void StoreCalendarEvent(IInterview interviewToStore)
        {
            CalendarHelper.Current.EventStore.RequestAccess(EKEntityType.Event,
                (bool granted, NSError e) =>
                {
                    if (granted)
                    {

                    }
                    else
                    {
                        new UIAlertView("Access Denied", "user Denied Access to Calendar Data", null, "ok", null).Show();
                    }
                });


            EKEvent newEvent = EKEvent.FromStore(CalendarHelper.Current.EventStore);
            newEvent.StartDate = NSDate.FromTimeIntervalSinceNow(1000);
            DateTime StartTime = DateTime.MinValue;
            var Duration =  90;
            newEvent.EndDate = NSDate.FromTimeIntervalSinceNow(2000);
            newEvent.Title = "Yaaa";
            newEvent.Notes = "OOOOO";
            newEvent.Calendar = CalendarHelper.Current.EventStore.DefaultCalendarForNewEvents;

            NSError a;
            try
            {   // Save Note to Calendar to get UUID 
                CalendarHelper.Current.EventStore.SaveEvent(newEvent, EKSpan.ThisEvent, true, out a);
                if (a != null)
                {
                    new UIAlertView("Err Saving Event", a.ToString(), null, "ok", null).Show();
                    return;
                }
                else
                {   // Test: Show UUID 
                    new UIAlertView(newEvent.UUID, "wurden zum Kalendar hinzugefügt", null, "ok", null).Show();
                }

            }
            catch
            {
                new UIAlertView("Fehler", "Kalendareinträge wurden nicht erstellt", null, "ok", null).Show();
            }

            finally
            {
            }
        }

        public List<IInterview> GetEventsByDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public List<IInterview> GetInterviewsById(Guid jobGuid)
        {
            throw new NotImplementedException();
        }


    }
}