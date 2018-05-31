using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; }
	  //  public ICalendarService CalendarService { get; set; }

		public InterviewDetailView(Guid? interviewGuid = null)
		{
		    ViewModel = new InterviewDetailViewModel(interviewGuid);
		    ViewModel.Loaded += OnInterviewLoaded;
			InitializeComponent();
            BindingContext = ViewModel;

            /*	    CalendarService = DependencyService.Get<ICalendarService>();
                    CalendarService.StoreCalendarEvent(new Interview{Date = DateTime.Now, Id = Guid.NewGuid(), Round = 1});*/
        }

	    private void OnInterviewLoaded(object sender, EventArgs e)
	    {
	        //throw new NotImplementedException();
	    }

	    private void Save_Action(object sender, EventArgs e)
		{
     //       StoreToCalendar();
	//		throw new NotImplementedException();
		}

	    private void StoreToCalendar()
	    {
	        
	    }

        private void Button_Clicked(object sender, EventArgs e)
        {
            ViewModel.SaveToCalendar();
        }
    }
}