using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.Services;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class JobOfferListViewModel : ViewModelBase
    {
        private readonly Repository<JobOffer> _repository = new Repository<JobOffer>(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        private ObservableCollection<JobOffer> _jobOffers;
        private JobOffer _selectedJobOffer;

        private Command<JobOffer> _deleteJobOfferCommand;

        public ObservableCollection<JobOffer> JobOffers
        {
            get => _jobOffers;
            set
            {
                _jobOffers = value;
                OnPropertyChanged(nameof(JobOffers));
            }
        }
        public JobOffer SelectedJobOffer
        {
            get => _selectedJobOffer;
            set
            {
                _selectedJobOffer = value;
                OnPropertyChanged(nameof(SelectedJobOffer));
            }
        }

        public Command<JobOffer> DeleteJobOfferCommand =>
            _deleteJobOfferCommand ?? (_deleteJobOfferCommand = 
                new Command<JobOffer>(async jobOffer => await DeleteJobOffer(jobOffer)));

        public event EventHandler JobOffersLoaded;

        public JobOfferListViewModel()
        {
            _repository.TryGetAllAsync().ContinueWith(task =>
            {
                JobOffers = new ObservableCollection<JobOffer>(task.Result);
                JobOffersLoaded?.Invoke(this, null);
            });
        }

        public async Task Sycnhronize()
        {
            JobOffers = new ObservableCollection<JobOffer>(await _repository.TryGetAllAsync());
            JobOffersLoaded?.Invoke(this, null);
        }

        private async Task<bool> DeleteJobOffer(JobOffer jobOffer)
        {
            JobOffers.Remove(jobOffer);
            return await _repository.TryDeleteEntityAsync(jobOffer);
        }
    }
}
