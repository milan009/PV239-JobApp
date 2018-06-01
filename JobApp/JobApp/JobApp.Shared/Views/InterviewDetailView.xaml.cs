﻿using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; }
	  //  public ICalendarService CalendarService { get; set; }

		public InterviewDetailView(Guid? jobOfferGuid, Guid? interviewGuid = null)
		{
		    ViewModel = new InterviewDetailViewModel(jobOfferGuid ?? default(Guid), interviewGuid);
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

	    private async void Save_Action(object sender, EventArgs e)
		{
			await ViewModel.Save();
			await Navigation.PopAsync();
		}

	}
}