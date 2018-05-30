using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp.Shared.Views
{
	public partial class JobOfferListView : ContentPage
	{
        public JobOfferListViewModel ViewModel { get; set; } = new JobOfferListViewModel();

        public JobOfferListView ()
		{
			InitializeComponent();
            ViewModel.JobOffersLoaded += OnJobOffersLoaded;
		    BindingContext = ViewModel;
		}

        private void OnJobOffersLoaded(object sender, EventArgs e)
        {
            var o = 5;
            //    throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.Sycnhronize();
        }


        //TODO: toto by malo byt iba docasne, nahradit nativnym tlacitkom
        private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new JobOfferDetailView(), true);
        }
	}
}