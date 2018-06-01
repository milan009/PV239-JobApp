using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;
using XamarinToolkit.Mvvm;
using System.Linq;

namespace JobApp.Shared.ViewModels
{
    public class InterviewListViewModel : ViewModelBase
    {
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

        private readonly Repository<Interview> _repository = new Repository<Interview>(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        public event EventHandler InterviewsLoaded;

        // TODO: Only load those nescessary
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
