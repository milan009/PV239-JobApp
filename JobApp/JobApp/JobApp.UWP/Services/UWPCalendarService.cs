using System;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;
using JobApp.Shared.Interfaces.Models;
using JobApp.Shared.Interfaces.Services;
using JobApp.UWP.Services;
using JobApp.Shared.Models;

[assembly: Xamarin.Forms.Dependency(typeof(UWPCalendarService))]

namespace JobApp.UWP.Services
{
    class UWPCalendarService : ICalendarService
    {
        public async void StoreCalendarEvent(Interview interviewToStore)
        {
          /* There were some issues in getting this to work
           var appointment = new Appointment
            {
                StartTime = interviewToStore.Date,
                Duration = TimeSpan.FromHours(1),
                Subject = interviewToStore.JobOffer.Position,
                Details = interviewToStore.JobOffer.Note
            };

            await AppointmentManager.ShowAddAppointmentAsync(
                appointment, new Rect(0, 0, 100, 100), Windows.UI.Popups.Placement.Default);*/
        }
    }
}