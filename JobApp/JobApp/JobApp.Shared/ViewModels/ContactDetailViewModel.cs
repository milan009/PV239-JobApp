using System;
using System.Linq;
using System.Threading.Tasks;
using JobApp.Shared.Models;
using JobApp.Shared.Services;

namespace JobApp.Shared.ViewModels
{
    public class ContactDetailViewModel : ViewModelBaseGeneric<Contact>
    {
        private GuidService _guidService = new GuidService();

        public override Contact DataModel { 
        get => _dataModel;
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FirstName
        {
            get => DataModel?.Name?.Split(' ').First() ?? "";
            set => SetFirstName(value);
        }

        public string LastName
        {
            get => DataModel?.Name?.Split(' ').Last() ?? "";
            set => SetLastName(value);
        }

        public ContactDetailViewModel(Guid? id) : base(id) { }


        public async Task<bool> Save()
        {
            if (DataModel.Id == default(Guid))
            {
                DataModel.Id = _guidService.GenerateNewGuid();
                return await _repository.TryAddEntityAsync(DataModel);
            }

            return await _repository.TryUpdateEntityAsync(DataModel);
        }

        private void SetFirstName(string value)
        {
            CheckDataModel();
            DataModel.Name = $"{value} {LastName}";
        }

        private void SetLastName(string value)
        {
            CheckDataModel();
            DataModel.Name = $"{FirstName} {value}";
        }

        private void CheckDataModel()
        {
            if (DataModel == null)
            {
                DataModel = new Contact();
            }
        }

    } 
}
