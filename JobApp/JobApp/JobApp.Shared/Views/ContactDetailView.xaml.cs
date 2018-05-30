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
	    public ContactDetailViewModel ViewModel { get; set; } = new ContactDetailViewModel();

        public ContactRepository Repository { get; set; } = new ContactRepository(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName))); 

		public ContactDetailView(Guid? contactGuid = null)
		{
		    InitializeComponent();
		    BindingContext = ViewModel;

            if (contactGuid.HasValue)
		    {
		        Repository.TryGetContactByIdAsync(contactGuid.Value)
		            .ContinueWith(task => OnContactLoaded(task.Result));
		    }
        }

	    protected void OnContactLoaded(Contact contact)
	    {
            ViewModel.Contact = contact;
	    }

	    private void Save_Action(object sender, EventArgs e)
	    {
	        Repository.TryUpdateContactAsync(ViewModel.Contact);
	        //throw new NotImplementedException();
		}
	}
}