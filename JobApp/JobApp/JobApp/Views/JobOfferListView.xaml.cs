using System;
using JobApp.ViewModels;
using Xamarin.Forms;

namespace JobApp.Views
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
	        Navigation.PushAsync(new JobOfferDetailView(), true);
	    }
	}
}