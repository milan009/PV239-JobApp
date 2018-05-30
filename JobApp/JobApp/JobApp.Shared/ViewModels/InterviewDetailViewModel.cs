using JobApp.Shared.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class InterviewDetailViewModel : ViewModelBase
    {
        private Interview _interview = new Interview();

        public Interview Interview
        {
            get => _interview;
            set
            {
                _interview = value;
                OnPropertyChanged(nameof(Interview));
            }
        }
    }
}
