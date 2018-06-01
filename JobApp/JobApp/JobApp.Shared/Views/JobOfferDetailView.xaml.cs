using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
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
            ViewModel.Loaded += OnOfferLoaded;

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
            var contactPage = new ContactDetailView(ViewModel.DataModel.ContactId);
            contactPage.AddContactToJobOffer += OnContactAdded;
            Navigation.PushAsync(contactPage, true);
	    }

	    private void Interview_OnPressed(object sender, EventArgs e)
	    {
            var interviewListPage = new InterviewListView(ViewModel.DataModel?.Id);
            interviewListPage.InterviewListViewClosing += InterviewListPage_InterviewListViewClosing;

            Navigation.PushAsync(interviewListPage, true); 
	    }

        private void InterviewListPage_InterviewListViewClosing(object sender, System.Collections.Generic.List<Models.Interview> e)
        {
            ViewModel.SetInterviews(e);
        }

        private async void Save_Action(object sender, EventArgs e)
	    {
	        await ViewModel.Save();
            await Navigation.PopAsync();
	    }
    }
}