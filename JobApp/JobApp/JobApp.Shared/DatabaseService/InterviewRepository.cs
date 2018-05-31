﻿using System;
using System.Collections.Generic;
using SQLite;
using System.Threading.Tasks;
using JobApp.Shared.Models;

namespace JobApp.Shared.DatabaseServices
{
    public class InterviewRepository
    {
        private SQLiteAsyncConnection _database;

        public InterviewRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<Interview> TryGetInterviewByIdAsync(Guid id)
        {
            try
            {
                return await _database
                    .Table<Interview>()
                    .Where(interview => interview.Id == id)
                    .FirstAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<Interview>> TryGetAllInterviewsAsync()
        {
            try
            {
                return await _database
                    .Table<Interview>()
                    .ToListAsync();
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> TryAddInterviewAsync(Interview interview)
        {
            try
            {
                await _database.InsertAsync(interview);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryDeleteInterviewAsync(Interview interview)
        {
            try
            {
                await _database.DeleteAsync(interview);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TryUpdateInterviewAsync(Interview interview)
        {
            try
            {
                await _database.UpdateAsync(interview);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
