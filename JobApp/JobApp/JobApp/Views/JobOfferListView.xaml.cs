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
	}
}