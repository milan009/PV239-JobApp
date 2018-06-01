using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using JobApp.Shared.Events;

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

        public void OnContactAdded(object source, AddContactEventArgs e)
            => ViewModel.SetContact(e.Contact);
        

	    private void Contact_OnPressed(object sender, EventArgs e)
	    {
            var contactPage = new ContactDetailView(ViewModel.JobOffer.ContactId);
            contactPage.AddContactToJobOffer += OnContactAdded;
            Navigation.PushAsync(contactPage, true);
	    }

	    private void Interview_OnPressed(object sender, EventArgs e)
	    {
	        //var upcomingInterviews = ViewModel.JobOffer?.Interviews?.Select(interview => interview.Id).ToArray();
            Navigation.PushAsync(new InterviewListView(ViewModel.JobOffer?.Id), true);
	    }

	    private async void Save_Action(object sender, EventArgs e)
	    {
	        await ViewModel.Save();
            await Navigation.PopAsync();
	    }
	}
}