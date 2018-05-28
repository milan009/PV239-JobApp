using System;
using System.Collections.Generic;
using System.Text;
using JobApp.Models;

namespace JobApp.Services
{
    public interface ICalendarService
    {
        void StoreCalendarEvent(IInterview interviewToStore);
        List<IInterview> GetEventsByDay(DateTime day);
        List<IInterview> GetInterviewsById(Guid jobGuid);
    }
}
