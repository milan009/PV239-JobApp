using System;
using JobApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class InterviewListView : ContentPage
	{
        public InterviewListViewModel ViewModel { get; set; } = new InterviewListViewModel();

		public InterviewListView ()
		{
			InitializeComponent ();
		}

	    private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new InterviewDetailView(), true);
        }
	}
}