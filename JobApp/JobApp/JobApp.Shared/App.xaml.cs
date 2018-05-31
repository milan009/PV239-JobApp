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

		protected override void OnStart ()
		{
            PopulateDb();
		}

	    private static void PopulateDb()
	    {
	        var db = new SQLiteAsyncConnection(
	            DependencyService.Get<ISQLiteConnectionStringFactory>().Create(DatabaseName));

	        Task<int>[] dropTasks =
	        {
	            db.DropTableAsync<Company>(),
	            db.DropTableAsync<Contact>(),
	            db.DropTableAsync<Address>(),
	            db.DropTableAsync<JobOffer>(),
	            db.DropTableAsync<Interview>()
	        };

	        Task.WaitAll(dropTasks);

	        db.CreateTablesAsync<Contact, JobOffer, Address, Company, Interview>().Wait();

	        Task<int>[] createTasks =
	        {
	            db.InsertAllAsync(MockData.Companies),
	            db.InsertAllAsync(MockData.Addresses),
	            db.InsertAllAsync(MockData.Contacts),
	            db.InsertAllAsync(MockData.JobOffers),
	            db.InsertAllAsync(MockData.Interviews)
	        };

	        Task.WaitAll(createTasks);
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
