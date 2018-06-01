using System;
using System.Collections.Generic;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewListView : ContentPage
	{
        public InterviewListViewModel ViewModel { get; set; }

	    public event EventHandler<List<Interview>> InterviewListViewClosing;

		public InterviewListView(Guid? jobOfferId = null)
		{
		    ViewModel = new InterviewListViewModel(jobOfferId);

			InitializeComponent();
            BindingContext = ViewModel;
		}

	    private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new InterviewDetailView(ViewModel.JobInterviewId), true);
        }

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        Navigation.PushAsync(new InterviewDetailView(ViewModel.JobInterviewId, ((Interview)e.SelectedItem).Id), true);
        }

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await ViewModel.Sycnhronize();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            InterviewListViewClosing?.Invoke(this, new List<Interview>(ViewModel.Interviews));
        }
    }
}