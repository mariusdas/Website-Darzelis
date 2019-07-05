
using Darzelis.Data.Contracts;
using Darzelis.Models.Entities;

namespace Darzelis.Data.Contracts
{
    /// <summary>
    /// Interface for UOW Movie Review
    /// </summary>
    public interface IRequestUow
    {
        void Commit();
        IRequestRepository Requests { get; }
        IRepository<Pre_Schools> Schools { get; }
        IRepository<User> Users { get; }
        IRepository<PreRequestSchool> PreRequestSchool { get; }
        IRepository<RequestInfo> RequestInfo { get; }

    }
}
