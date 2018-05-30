using System;
using System.Threading.Tasks;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Models;
using JobApp.Shared.Services;
using JobApp.Shared.Views;
using SQLite;
using Xamarin.Forms;
using XamarinToolkit.Interfaces.Storage;

namespace JobApp
{
	public partial class App : Application
	{
        public const string DatabaseName = "JobAppDb";

	    public App ()
		{
			InitializeComponent();

			base.MainPage = new NavigationPage(new JobOfferListView());
		}

		protected override async void OnStart ()
		{
		    await PopulateDb();
		}

	    private static async Task PopulateDb()
	    {
	        var db = new SQLiteAsyncConnection(
	            DependencyService.Get<ISQLiteConnectionStringFactory>().Create(DatabaseName));

	        await db.DropTableAsync<Company>();
	        await db.DropTableAsync<Contact>();
	        await db.DropTableAsync<Address>();
	        await db.DropTableAsync<JobOffer>();
	        await db.DropTableAsync<Interview>();

	        await db.CreateTablesAsync<Contact, JobOffer, Address, Company, Interview>();

	        await db.InsertAllAsync(MockData.Companies);
	        await db.InsertAllAsync(MockData.Addresses);
	        await db.InsertAllAsync(MockData.Contacts);
	        await db.InsertAllAsync(MockData.JobOffers);
	        await db.InsertAllAsync(MockData.Interviews);
	    }

	    protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
