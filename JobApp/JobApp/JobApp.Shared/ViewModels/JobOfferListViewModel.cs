using System.Collections.ObjectModel;
using JobApp.Shared.Models;
using JobApp.Shared.Services;
using Xamarin.Forms;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class JobOfferListViewModel : ViewModelBase
    {
        private GuidService _guidService = new GuidService();
        private ObservableCollection<JobOffer> _jobOffers = new ObservableCollection<JobOffer>();

        public ObservableCollection<JobOffer> JobOffers
        {
            get => _jobOffers;
            set
            {
                _jobOffers = value;
                OnPropertyChanged();
            }
        }

        private JobOffer _selectedJobOffer;

        public JobOffer SelectedJobOffer
        {
            get => _selectedJobOffer;
            set
            {
                _selectedJobOffer = value;
                OnPropertyChanged();
            }
        }

        private Command<string> _addJobOfferCommand;

        public Command<string> AddJobOfferCommand =>
            _addJobOfferCommand ?? (_addJobOfferCommand = new Command<string>(AddJobOffer));

        private Command<JobOffer> _deleteJobOfferCommand;

        public Command<JobOffer> DeleteJobOfferCommand =>
            _deleteJobOfferCommand ?? (_deleteJobOfferCommand = new Command<JobOffer>(DeleteJobOffer));

        private void AddJobOffer(string companyName)
        {
            if (string.IsNullOrEmpty(companyName)) return;

            //TO DO: vytvorit novu ponuku
            var newJobOffer = new JobOffer()
            {
                Id = _guidService.GenerateNewGuid(),
                Position = companyName 
            };

            JobOffers.Add(newJobOffer);
        }

        private void DeleteJobOffer(JobOffer jobOffer)
        {
            JobOffers.Remove(jobOffer);
        }

    }
}
