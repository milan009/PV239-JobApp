using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Views
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
	        Navigation.PushAsync(new ContactDetailView(), true);
	    }

	    private void Interview_OnPressed(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new InterviewListView(), true);
	    }
    }
}