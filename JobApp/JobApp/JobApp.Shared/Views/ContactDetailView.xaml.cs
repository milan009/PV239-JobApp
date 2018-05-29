using System;
using JobApp.Shared.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailView : ContentPage
	{
        public ContactDetailViewModel ViewModel { get; set; } = new ContactDetailViewModel();

		public ContactDetailView ()
		{
			InitializeComponent ();
		}

		private void Save_Action(object sender, EventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}