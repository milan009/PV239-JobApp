using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLite;
using System.Threading.Tasks;
using JobApp.Shared.Models;

namespace JobApp.Shared.DatabaseServices
{
    public class JobOfferRepository
    {
        private SQLiteAsyncConnection _database;

        public JobOfferRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<JobOffer> TryGetJobOfferByIdAsync(Guid id)
        {
            try
            {
                return await _database
                    .Table<JobOffer>()
                    .Where(jobOffer => jobOffer.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<JobOffer>> TryGetAllJobOffers()
        {
            try
            {
                return await _database
                    .Table<JobOffer>()
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryAddJobOfferAsync(JobOffer jobOffer)
        {
            try
            {
                await _database.InsertAsync(jobOffer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteJobOfferAsync(JobOffer jobOffer)
        {
            try
            {
                await _database.DeleteAsync(jobOffer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateJobOfferAsync(JobOffer jobOffer)
        {
            try
            {
                await _database.UpdateAsync(jobOffer);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
