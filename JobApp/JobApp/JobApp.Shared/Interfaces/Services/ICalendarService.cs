using System;
using System.Collections.Generic;
using JobApp.Shared.Models;

namespace JobApp.Shared.Interfaces.Services
{
    public interface ICalendarService
    {
        void StoreCalendarEvent(Interview interviewToStore);
    }
}
