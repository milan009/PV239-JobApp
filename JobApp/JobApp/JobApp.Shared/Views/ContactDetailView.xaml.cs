using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.ViewModels;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp.Shared.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactDetailView : ContentPage
	{
	    public ContactDetailViewModel ViewModel { get; set; }

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

	    private void Save_Action(object sender, EventArgs e)
	    {
	       // Repository.TryUpdateContactAsync(ViewModel.DataModel);
	        //throw new NotImplementedException();
		}
	}
}