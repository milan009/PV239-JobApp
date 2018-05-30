using System;
using System.Linq;
using JobApp.Shared.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class JobOfferDetailViewModel : ViewModelBase
    {
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

    }
}
