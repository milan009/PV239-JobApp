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
            set => setFirstName(value);
        }

        private void setFirstName(string value)
        {
            checkDataModel();
            DataModel.Name = $"{value} {LastName}";
        }

        public string LastName
        {
            get => DataModel?.Name?.Split(' ').Last() ?? "";
            set => setLastName(value);
        }

        private void setLastName(string value)
        {
            checkDataModel();
            DataModel.Name = $"{FirstName} {value}";
        }

        private void checkDataModel()
        {
            if (DataModel == null)
            {
                DataModel = new Contact();
            }
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
    } 
}
