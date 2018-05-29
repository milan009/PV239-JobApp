using System.Collections.ObjectModel;
using JobApp.Shared.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.Shared.ViewModels
{
    public class InterviewListViewModel : ViewModelBase
    {
        public ObservableCollection<Interview> Interviews { get; private set; }
    }
}
