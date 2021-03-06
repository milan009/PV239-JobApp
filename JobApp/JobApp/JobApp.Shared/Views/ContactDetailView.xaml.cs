﻿using System;
using JobApp.Shared.Events;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailView : ContentPage
	{
	    public ContactDetailViewModel ViewModel { get; set; }
        public delegate void SetContactOfJobOfferEventHandler(object source, AddContactEventArgs args);
        public event SetContactOfJobOfferEventHandler AddContactToJobOffer;

        public ContactDetailView(Guid? contactGuid = null)
		{
		    ViewModel = new ContactDetailViewModel(contactGuid);
		    ViewModel.Loaded += OnContactLoaded;

            InitializeComponent();
		    BindingContext = ViewModel;
        }

	    private void OnContactLoaded(object sender, EventArgs e)
	    {
	        //throw new NotImplementedException();
	    }

	    private async void Save_Action(object sender, EventArgs e)
	    {
            await ViewModel.Save();
            AddContactToJobOffer?.Invoke(this, new AddContactEventArgs(ViewModel.DataModel));
            await Navigation.PopAsync();
        }
	}
}