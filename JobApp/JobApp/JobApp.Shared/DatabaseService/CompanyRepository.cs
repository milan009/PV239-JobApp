using JobApp.Shared.Models;
using SQLite;
using System;
using System.Threading.Tasks;

namespace JobApp.Shared.DatabaseService
{
    public class CompanyRepository
    {
        private SQLiteAsyncConnection _database;

        public CompanyRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Company> TryGetCompanyByIdAsync(Guid id)
        {
            try
            {
                return await _database
                    .Table<Company>()
                    .Where(company => company.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryAddCompanyAsync(Company company)
        {
            try
            {
                await _database.InsertAsync(company);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteCompanyAsync(Company company)
        {
            try
            {
                await _database.DeleteAsync(company);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateCompanyAsync(Company company)
        {
            try
            {
                await _database.UpdateAsync(company);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
