using System;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolkit.Interfaces.Services;

namespace JobApp.Shared.Views
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