using System;
using System.Linq;
using System.Threading.Tasks;
using Android.Text;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.Services;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class JobOfferDetailViewModel : ViewModelBase
    {
        private readonly GuidService _guidService = new GuidService();
        private readonly JobOfferRepository _repository = new JobOfferRepository(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        private JobOffer _jobOffer = new JobOffer();

        public JobOffer JobOffer
        {
            get => _jobOffer;
            set
            {
                _jobOffer = value;
                OnPropertyChanged(nameof(JobOffer));
                OnPropertyChanged(nameof(SalaryValue));
                OnPropertyChanged(nameof(SalaryVisible));
                OnPropertyChanged(nameof(DateValue));
            }
        }
        public string SalaryValue
        {
            get => $"{JobOffer.OfferedPay.GetValueOrDefault()} Kč";
            set => _jobOffer.OfferedPay = int.Parse(value.Split(' ').First());
        }
        public DateTime DateValue
        {
            get => JobOffer.CommencementDate.GetValueOrDefault();
            set => _jobOffer.CommencementDate = value;
        }

        public bool SalaryVisible => JobOffer.OfferedPay.HasValue;
        public bool DateVisible => JobOffer.CommencementDate.HasValue;

        public event EventHandler JobOfferLoaded;

        public JobOfferDetailViewModel(Guid? offerGuid = null)
        {
            if (offerGuid.HasValue)
            {
                _repository.TryGetJobOfferByIdAsync(offerGuid.Value)
                    .ContinueWith(task =>
                    {
                        JobOffer = task.Result;
                        JobOfferLoaded.Invoke(this, null);
                    });
            }
        }

        // todo: use command?
        public async Task<bool> Save()
        {
            if (JobOffer.Id == default(Guid))
            {
                JobOffer.Id = _guidService.GenerateNewGuid();
                return await _repository.TryAddJobOfferAsync(JobOffer);
            }

            return await _repository.TryUpdateJobOfferAsync(JobOffer);
        }
    }
}
