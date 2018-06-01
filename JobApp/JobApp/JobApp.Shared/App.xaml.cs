using System.Threading.Tasks;
using JobApp.Shared.Interfaces.Storage;
using JobApp.Shared.Models;
using JobApp.Shared.Views;
using SQLite;
using Xamarin.Forms;

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
		    InitDb();
		}

	    private static void PopulateMockDb()
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

	    private static void InitDb()
	    {
	        var db = new SQLiteAsyncConnection(
	            DependencyService.Get<ISQLiteConnectionStringFactory>().Create(DatabaseName));

	        db.CreateTablesAsync<Contact, JobOffer, Address, Company, Interview>().Wait();
	    }
	}
}
