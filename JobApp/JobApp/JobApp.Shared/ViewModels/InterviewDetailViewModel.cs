using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JobApp.Shared.Interfaces.Services;
using JobApp.Shared.Models;
using Xamarin.Forms;

namespace JobApp.Shared.ViewModels
{
    public class InterviewDetailViewModel : ViewModelBaseGeneric<Interview>
    {
        public override Interview DataModel
        {
            get => _dataModel;
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(Time));
            }
        }

        public DateTime Date
        {
            get => _dataModel.Date;
            set => _dataModel.Date = value + Time;
        }

        public TimeSpan Time
        {
            get => _dataModel.Date.TimeOfDay;
            set => _dataModel.Date = Date + value;
        }

        private ICalendarService _calendarService = DependencyService.Get<ICalendarService>();

        public void SaveToCalendar()
        {
            var r = DataModel.JobOffer;
            var q = _repository.LoadChildrenOfEntityAsync(DataModel);
            q.Wait();

            var o = DataModel.JobOffer;
            var p = q.Result;
            _calendarService.StoreCalendarEvent(DataModel);
            
        }

        public InterviewDetailViewModel(Guid? id) : base(id) {} 
    }
}
