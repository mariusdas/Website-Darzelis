using Darzelis.Models.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Darzelis.Data
{
    public class RequestDbContext :DbContext
    {
       
       public RequestDbContext() : base(nameOrConnectionString: "DarzelisProd") { }

        public DbSet<Request> Requests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pre_Schools> Schools { get; set; }
        public DbSet<PreRequestSchool> PreRequestSchool { get; set; }
        public DbSet<RequestInfo> RequestInfo { get; set; }

        //static RequestDbContext()
        //{
        //    Database.SetInitializer(new RequestDatabaseInitializer());
        //}
        //setting EF Convetions
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

    }
}
