using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewDetailView : ContentPage
	{
        public InterviewDetailViewModel ViewModel { get; set; }

		public InterviewDetailView(Guid? jobOfferGuid, Guid? interviewGuid = null)
		{
		    ViewModel = new InterviewDetailViewModel(jobOfferGuid ?? default(Guid), interviewGuid);
		    ViewModel.Loaded += OnInterviewLoaded;
			InitializeComponent();
		    BindingContext = ViewModel;
		}

	    private void OnInterviewLoaded(object sender, EventArgs e)
	    {

	    }

	    private async void Save_Action(object sender, EventArgs e)
		{
			await ViewModel.Save();
			await Navigation.PopAsync();
		}

	}
}