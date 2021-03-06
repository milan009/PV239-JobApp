﻿using System;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;

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

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await ViewModel.Sycnhronize();
        }

        private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new JobOfferDetailView(), true);
        }

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        Navigation.PushAsync(new JobOfferDetailView(((JobOffer)e.SelectedItem).Id), true);
        }
	}
}