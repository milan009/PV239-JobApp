﻿using JobApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; } = new InterviewDetailViewModel();

		public InterviewDetailView ()
		{
			InitializeComponent ();
		}
	}
}