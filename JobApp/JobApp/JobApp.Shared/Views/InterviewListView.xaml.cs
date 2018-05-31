using System;
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

		public InterviewListView(Guid[] interviewGuids = null)
		{
		    ViewModel = new InterviewListViewModel(interviewGuids);

			InitializeComponent();
            BindingContext = ViewModel;
		}

	    private void Button_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new InterviewDetailView(), true);
        }

	    private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        Navigation.PushAsync(new InterviewDetailView(((Interview)e.SelectedItem).Id), true);
        }
	}
}