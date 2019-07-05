using Darzelis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darzelis.Data.Contracts
{
    public interface IRequestRepository
    {
        IQueryable<Request> GetAll();
        Request GetById(int id);
        void Add(Request entity);
        void Update(Request entity);
        void Delete(Request entity);
        void Delete(int id);
        IList<Request> GetAllIncludeRequest();
    }
}
