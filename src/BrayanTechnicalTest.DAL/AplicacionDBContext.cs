using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BrayanTechnicalTest.DAL
{
    public class AplicacionDBContext : DbContext
    {
        public AplicacionDBContext()
        : base("name=DBContext")
        {
            Database.SetInitializer<AplicacionDBContext>(new CreateDatabaseIfNotExists<AplicacionDBContext>());
            //Database.SetInitializer<DBContext>(new DropCreateDatabaseIfModelChanges<DBContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }


    }
}
