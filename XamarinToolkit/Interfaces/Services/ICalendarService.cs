using System;
using System.Collections.Generic;

namespace XamarinToolkit.Interfaces.Services
{
    public interface ICalendarService
    {
        void StoreCalendarEvent(IInterview interviewToStore);
        List<IInterview> GetEventsByDay(DateTime day);
        List<IInterview> GetInterviewsById(Guid jobGuid);
    }
}
\