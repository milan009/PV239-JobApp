using System.IO;
using JobApp.Interfaces;
using JobApp.UWP.DatabaseService;
using Windows.Storage;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteConnectionStringFactory))]

namespace JobApp.UWP.DatabaseService
{
    public class SQLiteConnectionStringFactory : ISQLiteConnectionStringFactory
    {
        public string Create(string name) 
            => Path.Combine(ApplicationData.Current.LocalFolder.Path, name);
    }
}