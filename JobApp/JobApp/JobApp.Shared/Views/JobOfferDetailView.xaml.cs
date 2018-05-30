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
	public partial class JobOfferDetailView : ContentPage
	{
        public JobOfferDetailViewModel ViewModel { get; set; }

        public JobOfferDetailView (Guid? offerGuid = null)
		{
		    ViewModel = new JobOfferDetailViewModel(offerGuid);
            ViewModel.JobOfferLoaded += OnContactLoaded;

		    InitializeComponent();
		    BindingContext = ViewModel;
        }

        private void OnContactLoaded(object sender, EventArgs e)
        {
            
        }

	    private void Contact_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new ContactDetailView(MockData.ContactGuids[0]), true);
	    }

	    private void Interview_OnPressed(object sender, EventArgs e)
	    {
	        Guid[] g = {MockData.InterviewGuids[0], MockData.InterviewGuids[1]};

            Navigation.PushAsync(new InterviewListView(g), true);
	    }

	    private void Save_Action(object sender, EventArgs e)
	    {
	        ViewModel.Save();
	    }
	}
}