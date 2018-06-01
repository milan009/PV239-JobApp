using System;
using System.Linq;
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
    public class JobOfferDetailViewModel : ViewModelBaseGeneric<JobOffer>
    {
        private readonly GuidService _guidService = new GuidService();

        public override JobOffer DataModel
        {
            get => _dataModel;
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
                OnPropertyChanged(nameof(SalaryValue));
                OnPropertyChanged(nameof(SalaryVisible));
                OnPropertyChanged(nameof(DateValue));
                OnPropertyChanged(nameof(ContactName));
                OnPropertyChanged(nameof(NearestInterviewDate));
            }
        }

        public string SalaryValue
        {
            get => $"{DataModel.OfferedPay.GetValueOrDefault()} Kč";
            set => SetSalary(value);
        }

        private void SetSalary(string value)
        {
            try
            {
                _dataModel.OfferedPay = int.Parse(value.Split(' ').First());
            }
            catch
            {
                _dataModel.OfferedPay = 0;
            }
        }

        public DateTime DateValue
        {
            get => DataModel.CommencementDate.GetValueOrDefault();
            set => _dataModel.CommencementDate = value;
        }

        public string ContactName => DataModel.Contact?.Name ?? "<Žádný kontakt>";

        public void SetContact(Contact contact)
        {
            _dataModel.Contact = contact;
            _dataModel.ContactId = contact.Id;
            OnPropertyChanged(nameof(ContactName));
        }

        public string NearestInterviewDate
        {
            get
            {
                var upcomingInterviews = DataModel
                        .Interviews?
                        .Where(interview => interview.Date > DateTime.Now);

                return (upcomingInterviews == null || !upcomingInterviews.Any()) ? 
                    "<Žádný pohovor>" : upcomingInterviews.Min(interview => interview.Date).ToString("dd. MM. yyyy");
            }
        }

        public bool SalaryVisible => DataModel.OfferedPay.HasValue;
        public bool DateVisible => DataModel.CommencementDate.HasValue;

        public JobOfferDetailViewModel(Guid? offerGuid = null) : base(offerGuid) { }

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
