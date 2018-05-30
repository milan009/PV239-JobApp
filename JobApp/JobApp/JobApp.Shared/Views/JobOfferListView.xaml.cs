using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;

namespace JobApp.Shared.Views
{
	public partial class JobOfferListView : ContentPage
	{
        public JobOfferListViewModel ViewModel { get; set; } = new JobOfferListViewModel();

		public JobOfferListView ()
		{
			InitializeComponent ();
		    BindingContext = ViewModel;
		}

        //TODO: toto by malo byt iba docasne, nahradit nativnym tlacitkom
	    private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new JobOfferDetailView(MockData.JobOfferGuids[0]), true);
	    }
	}
}