using System.Linq;
using JobApp.Shared.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class ContactDetailViewModel : ViewModelBase
    {
        private Contact _contact = new Contact();
        public Contact Contact {
            get => _contact;
            set
            {
                _contact = value;
                OnPropertyChanged(nameof(Contact));
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LastName));
            }
        }

        public string FirstName
        {
            get => Contact?.Name?.Split(' ').First() ?? "";
            set => Contact.Name = $"{value} {LastName}";
        }

        public string LastName
        {
            get => Contact?.Name?.Split(' ').Last() ?? "";
            set => Contact.Name = $"{FirstName} {value}";
        }
    } 
}
