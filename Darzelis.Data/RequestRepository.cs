using Darzelis.Data;
using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Data
{
    public class RequestRepository : IRequestRepository
    {
        RequestDbContext _Context;

        public RequestRepository()
        {
            _Context = new RequestDbContext();

        }
        public virtual Request GetById(int id)
        {
            return _Context.Requests.Find(id);
        }

        public virtual void Add(Request entity)
        {
            DbEntityEntry dbEntityEntry = _Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _Context.Requests.Add(entity);
            }
            //_Context.SaveChanges();

        }

        public virtual void Update(Request entity)
        {
           
            //var dbEntityEntry = _Context.Entry(entity);
            //if (dbEntityEntry.State != EntityState.Detached)
            //{
            //    _Context.Requests.Attach(entity);
            //}
            //dbEntityEntry.State = EntityState.Modified;

            using (var context = new RequestDbContext())
            {
                context.Set<Request>().Attach(entity);
                context.ChangeTracker.Entries<Request>().First(e => e.Entity == entity)
                                                      .State = EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Delete(Request entity)
        {
            DbEntityEntry dbEntityEntry = _Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                _Context.Requests.Attach(entity);
                _Context.Requests.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null) return;

            Delete(entity);
        }

        public IQueryable<Request> GetAll()
        {
            return _Context.Requests;
        }

        public IList<Request> GetAllIncludeRequest()
        {
            return _Context.Requests.Include(r => r.VaikoIDNF).Include(r => r.PreSchoolAccepted).ToList();
            //return _Context.Requests.Include(r => r.PreRequestSchool1).Include(r => r.PreRequestSchool2).Include(r => r.PreRequestSchool3).Include(r => r.PreRequestSchool4).Include(r => r.PreRequestSchool5).Include(r => r.PreSchool1).Include(r => r.PreSchool2).Include(r => r.PreSchool3).Include(r => r.PreSchool4).Include(r => r.PreSchool5).Include(r => r.VaikoIDNF).Include(r=>r.PreSchoolAccepted).ToList();
        }
    }
}
