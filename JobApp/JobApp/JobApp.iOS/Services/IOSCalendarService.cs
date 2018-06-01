using JobApp.iOS.Services;
using JobApp.Shared.Interfaces.Services;
using JobApp.Shared.Models;

[assembly: Xamarin.Forms.Dependency(typeof(IOSCalendarService))]

namespace JobApp.iOS.Services
{
    class IOSCalendarService : ICalendarService
    {
        public void StoreCalendarEvent(Interview interviewToStore)
        {
            // TODO: Get Mac to make testing this platform-specific function possible
            // TODO: Implement
        }
    }
}