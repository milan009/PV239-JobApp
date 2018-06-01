using System;
using JobApp.Shared.DatabaseServices;
using JobApp.Shared.Interfaces.Storage;
using JobApp.Shared.Models;
using SQLite;
using Xamarin.Forms;

namespace JobApp.Shared.ViewModels
{
    public abstract class ViewModelBaseGeneric<TDataModelType> : ViewModelBase where TDataModelType : BasicObject, new()
    {
        protected TDataModelType _dataModel = new TDataModelType();
        protected Repository<TDataModelType> _repository = new Repository<TDataModelType>(
            new SQLiteAsyncConnection(
                DependencyService.Get<ISQLiteConnectionStringFactory>().Create(App.DatabaseName)));

        public event EventHandler Loaded;

        protected ViewModelBaseGeneric(Guid? id, bool getWithChildren = false)
        {
            if (!id.HasValue)
                return;

            if (getWithChildren)
            {
                _repository.TryGetByIdWithChildrenAsync(id.Value).ContinueWith(task =>
                {
                    DataModel = task.Result;
                    Loaded?.Invoke(this, null);
                });
            }
            else
            {
                _repository.TryGetByIdAsync(id.Value).ContinueWith(task =>
                {
                    DataModel = task.Result;
                    Loaded?.Invoke(this, null);
                });
            }
        }

        public virtual TDataModelType DataModel
        {
            get => _dataModel;
            set => _dataModel = value;
        }
    }
}