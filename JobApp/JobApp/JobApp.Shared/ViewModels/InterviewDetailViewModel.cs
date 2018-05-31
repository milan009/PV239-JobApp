using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JobApp.Shared.Models;

namespace JobApp.Shared.ViewModels
{
    public class InterviewDetailViewModel : ViewModelBaseGeneric<Interview>
    {
        public override Interview DataModel
        {
            get => _dataModel;
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
            }
        }

        public InterviewDetailViewModel(Guid? id) : base(id) {}
    }
}
