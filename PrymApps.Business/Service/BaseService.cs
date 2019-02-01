using PrymApp.Data;
using PrymApp.Data.Repository;
using System;

namespace PrymApps.Business.Service
{
    public class BaseService<T>
        where T : BaseRepository
    {
        private T _repository;

        public T Repository => _repository;

        protected PrymAppContext DbContext => _repository.DbContext;

        public BaseService()
        {
            _repository = Activator.CreateInstance<T>();
        }
    }
}
