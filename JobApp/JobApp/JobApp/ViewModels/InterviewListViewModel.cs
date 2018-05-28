using System.Collections.ObjectModel;
using JobApp.Models;
using XamarinToolkit.Mvvm;

namespace JobApp.ViewModels
{
    public class InterviewListViewModel : ViewModelBase
    {
        public ObservableCollection<Interview> Interviews { get; private set; }
    }
}
