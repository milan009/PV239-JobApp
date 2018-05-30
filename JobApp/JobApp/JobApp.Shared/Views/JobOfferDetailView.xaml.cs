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
        public JobOfferDetailViewModel ViewModel { get; set; } = new JobOfferDetailViewModel();

        public JobOfferRepository Repository { get; set; } = new JobOfferRepository(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        public JobOfferDetailView (Guid? offerGuid = null)
		{
			InitializeComponent();
		    BindingContext = ViewModel;

		    if (offerGuid.HasValue)
		    {
		        Repository.TryGetJobOfferByIdAsync(offerGuid.Value)
		            .ContinueWith(task => OnContactLoaded(task.Result));
		    }
        }

	    private void OnContactLoaded(JobOffer offer)
	    {
	        ViewModel.JobOffer = offer;
       //     throw new NotImplementedException();
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
	        throw new NotImplementedException();
	    }
	}
}