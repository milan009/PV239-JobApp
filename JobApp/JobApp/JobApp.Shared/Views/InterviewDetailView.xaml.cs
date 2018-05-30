using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolkit.Interfaces.Services;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; } = new InterviewDetailViewModel();
	  //  public ICalendarService CalendarService { get; set; }

        public InterviewRepository Repository = new InterviewRepository(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));


		public InterviewDetailView(Guid? interviewGuid = null)
		{
			InitializeComponent();
            BindingContext = ViewModel;

		    if (interviewGuid.HasValue)
		    {
		        Repository.TryGetInterviewByIdAsync(interviewGuid.Value)
		            .ContinueWith(task => OnInterviewLoaded(task.Result));
		    }

            /*	    CalendarService = DependencyService.Get<ICalendarService>();
                    CalendarService.StoreCalendarEvent(new Interview{Date = DateTime.Now, Id = Guid.NewGuid(), Round = 1});*/
        }

	    private void OnInterviewLoaded(Interview result)
	    {
	        ViewModel.Interview = result;
	   //     throw new NotImplementedException();
	    }

	    private void Save_Action(object sender, EventArgs e)
		{
     //       StoreToCalendar();
	//		throw new NotImplementedException();
		}

	    private void StoreToCalendar()
	    {
	        
	    }
	}
}