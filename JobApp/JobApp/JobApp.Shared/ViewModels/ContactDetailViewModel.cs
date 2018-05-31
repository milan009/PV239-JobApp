using System;
using System.Linq;
using JobApp.Shared.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class ContactDetailViewModel : ViewModelBaseGeneric<Contact>
    {
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
            set => DataModel.Name = $"{value} {LastName}";
        }

        public string LastName
        {
            get => DataModel?.Name?.Split(' ').Last() ?? "";
            set => DataModel.Name = $"{FirstName} {value}";
        }

        public ContactDetailViewModel(Guid? id) : base(id) { }
    } 
}
