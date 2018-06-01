using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JobApp.Shared.Models;
using JobApp.Shared.Services;

namespace JobApp.Shared.ViewModels
{
    public class InterviewDetailViewModel : ViewModelBaseGeneric<Interview>
    {
	    private readonly GuidService _guidService = new GuidService();
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

	    public async Task<bool> Save()
	    {
		    if (DataModel.Id == default(Guid))
		    {
			    DataModel.Id = _guidService.GenerateNewGuid();
			    return await _repository.TryAddEntityAsync(DataModel);
		    }

		    return await _repository.TryUpdateEntityAsync(DataModel);
	    }
	}
}
