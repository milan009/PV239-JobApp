using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Interfaces.Storage;
using JobApp.Shared.Models;
using SQLite;
using Xamarin.Forms;

namespace JobApp.Shared.ViewModels
{
    public class InterviewListViewModel : ViewModelBase
    {
        private readonly Repository<Interview> _repository = new Repository<Interview>(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));
        private  ObservableCollection<Interview> _interviews;

        public ObservableCollection<Interview> Interviews
        {
            get => _interviews;
            set
            {
                _interviews = value;
                OnPropertyChanged(nameof(Interviews));
            }
        }

        public Guid? JobInterviewId { get; }

        public event EventHandler InterviewsLoaded;

        public InterviewListViewModel(Guid? jobOfferId = null)
        {
            JobInterviewId = jobOfferId;

            if (jobOfferId.HasValue)
            {
                _repository.TryGetMatchingAsync(interview => interview.JobOfferId == jobOfferId)
                    .ContinueWith(task =>
                    {
                        Interviews = new ObservableCollection<Interview>(task.Result);
                        InterviewsLoaded?.Invoke(this, null);
                    });
            }
            else
            {
                Interviews = new ObservableCollection<Interview>();
                InterviewsLoaded?.Invoke(this, null);
            }
        }

        public async Task Sycnhronize()
        {
            Interviews = new ObservableCollection<Interview>(await _repository.TryGetMatchingAsync(interview => interview.JobOfferId == JobInterviewId));
            InterviewsLoaded?.Invoke(this, null);
        }

        private async Task<bool> DeleteJobOffer(Interview interview)
        {
            Interviews.Remove(interview);
            return await _repository.TryDeleteEntityAsync(interview);
        }
    }
}
