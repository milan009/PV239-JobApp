using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolkit.Interfaces.Storage;
using System.Linq;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JobOfferDetailView : ContentPage
	{
        public JobOfferDetailViewModel ViewModel { get; set; }

        public JobOfferDetailView (Guid? offerGuid = null)
		{
		    ViewModel = new JobOfferDetailViewModel(offerGuid);
            ViewModel.JobOfferLoaded += OnOfferLoaded;

		    InitializeComponent();
		    BindingContext = ViewModel;
        }

        private void OnOfferLoaded(object sender, EventArgs e)
        {
            
        }

	    private void Contact_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new ContactDetailView(ViewModel.JobOffer.ContactId), true);
	    }

	    private void Interview_OnPressed(object sender, EventArgs e)
	    {
	        var upcomingInterviews = ViewModel.JobOffer.Interviews.Select(interview => interview.Id).ToArray();
            Navigation.PushAsync(new InterviewListView(upcomingInterviews), true);
	    }

	    private void Save_Action(object sender, EventArgs e)
	    {
	        ViewModel.Save();
	    }
	}
}