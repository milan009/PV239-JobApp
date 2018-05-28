using System;
using JobApp.Models;
using JobApp.Services;
using JobApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; } = new InterviewDetailViewModel();
	    public ICalendarService CalendarService { get; set; }

		public InterviewDetailView ()
		{
			InitializeComponent();
		    CalendarService = DependencyService.Get<ICalendarService>();
            CalendarService.StoreCalendarEvent(new Interview{Date = DateTime.Now, Id = Guid.NewGuid(), Round = 1});
		}

		private void Save_Action(object sender, EventArgs e)
		{
            StoreToCalendar();
			throw new NotImplementedException();
		}

	    private void StoreToCalendar()
	    {
	        
	    }
	}
}