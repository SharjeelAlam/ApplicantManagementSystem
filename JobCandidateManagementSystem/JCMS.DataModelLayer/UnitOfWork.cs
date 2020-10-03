using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCMS.DataModelLayer.Repositories;

namespace JCMS.DataModelLayer
{
   public class UnitOfWork
    {
        private JCMSDatabaseModel _databaseContext;
        private CandidateRepository _candidateRepo;

        public CandidateRepository candidateRepo
        {
            get
            {
                if (_candidateRepo == null)
                {
                    _candidateRepo = new CandidateRepository(_databaseContext);
                }
                return _candidateRepo;
            }
        }

        public UnitOfWork(JCMSDatabaseModel databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
