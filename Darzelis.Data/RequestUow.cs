using Darzelis.Data;
using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using System;

namespace Darzelis.Data
{
    public class RequestUow : IRequestUow, IDisposable
    {


        public RequestUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRequestRepository Requests { get { return new RequestRepository(); } }
        public IRepository<User> Users { get { return GetStandardRepo<User>(); }  }
        public IRepository<Pre_Schools> Schools { get { return GetStandardRepo<Pre_Schools>(); } }
        public IRepository<PreRequestSchool> PreRequestSchool { get { return GetStandardRepo<PreRequestSchool>(); } }
        public IRepository<RequestInfo> RequestInfo { get { return GetStandardRepo<RequestInfo>(); } }


        public void Commit()
        {
            DbContext.SaveChanges();
        }
        protected void CreateDbContext()
        {
            DbContext = new RequestDbContext();

            //Do Not enable proxy entities
            DbContext.Configuration.ProxyCreationEnabled = false;

            //Load navigation property explicitly
            DbContext.Configuration.LazyLoadingEnabled = false;

            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }


        protected IRepositoryProvider RepositoryProvider { get; set; }


        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }
        private RequestDbContext DbContext { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}
