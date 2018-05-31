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

        private readonly Repository<Interview> _repository = new Repository<Interview>(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        public event EventHandler InterviewsLoaded;

        // TODO: Only load those nescessary
        public InterviewListViewModel(Guid[] guids = null)
        {
            _repository.TryGetMatchingAsync(interview => guids.Contains(interview.Id))
                .ContinueWith(task =>
            {
                Interviews = new ObservableCollection<Interview>(task.Result);
                InterviewsLoaded?.Invoke(this, null);
            });
        }

        public async Task Sycnhronize()
        {
            Interviews = new ObservableCollection<Interview>(await _repository.TryGetAllAsync());
            InterviewsLoaded?.Invoke(this, null);
        }

        private async Task<bool> DeleteJobOffer(Interview interview)
        {
            Interviews.Remove(interview);
            return await _repository.TryDeleteEntityAsync(interview);
        }
    }
}
