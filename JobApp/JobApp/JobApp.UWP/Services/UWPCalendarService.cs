using System;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;
using Windows.System;
using JobApp.UWP.Services;
using XamarinToolkit.Interfaces.Models;
using XamarinToolkit.Interfaces.Services;

[assembly: Xamarin.Forms.Dependency(typeof(UWPCalendarService))]

namespace JobApp.UWP.Services
{
    class UWPCalendarService : ICalendarService
    {
        public async void StoreCalendarEvent(IInterview interviewToStore)
        {
            var appointment = new Appointment
            {
                StartTime = DateTimeOffset.Now + TimeSpan.FromHours(1),
                Duration = TimeSpan.FromHours(1),
                Subject = "Test Appointment",
                Location = "Weherever",
                Details = "Some more details"
            };

            var id = await AppointmentManager.ShowAddAppointmentAsync(
                appointment, new Rect(0, 0, 100, 100), Windows.UI.Popups.Placement.Default);
        }

      /*  private long PrepareTime(DateTime time)
        {
            Calendar c = Calendar.GetInstance(Java.Util.TimeZone.Default);

            c.Set(Java.Util.CalendarField.DayOfMonth, time.Day);
            c.Set(Java.Util.CalendarField.HourOfDay, time.Hour);
            c.Set(Java.Util.CalendarField.Minute, time.Minute);
            c.Set(Java.Util.CalendarField.Month, time.Month);
            c.Set(Java.Util.CalendarField.Year, time.Year);

            return c.TimeInMillis;
        }*/
    }
}