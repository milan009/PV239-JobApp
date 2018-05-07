using System.Threading.Tasks;
using JobApp.Interfaces;
using JobApp.Models;
using SQLite;

namespace JobApp.DatabaseService
{
    class DatabaseSetUp
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseSetUp(string name, ISQLiteConnectionStringFactory connectionFactory)
        {
            _database = new SQLiteAsyncConnection(connectionFactory.Create(name));
        }

        public async Task<SQLiteAsyncConnection> InitDatabase()
        {
            await _database.CreateTableAsync<Address>();
            await _database.CreateTableAsync<Company>();
            await _database.CreateTableAsync<Contact>();
            await _database.CreateTableAsync<Interview>();
            await _database.CreateTableAsync<JobOffer>();

            return _database;
        }

        public SQLiteAsyncConnection GetDatabase()
            => _database;
    }
}
