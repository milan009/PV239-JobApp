﻿using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JobOfferDetailView : ContentPage
	{
        public JobOfferDetailViewModel ViewModel { get; set; } = new JobOfferDetailViewModel();

		public JobOfferDetailView ()
		{
			InitializeComponent ();
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