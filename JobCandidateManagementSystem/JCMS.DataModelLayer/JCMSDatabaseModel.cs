using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using JCMS.DataModelLayer.Models;
using System.Data.Entity;

namespace JCMS.DataModelLayer
{
   public class JCMSDatabaseModel : DbContext
    {
        public JCMSDatabaseModel() : base("JCMSDatabaseModel")
        { }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
