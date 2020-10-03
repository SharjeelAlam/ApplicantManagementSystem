using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JCMS.DataModelLayer.Models;

namespace JCMS.DataModelLayer.Repositories
{
   public class CandidateRepository
    {
        private JCMSDatabaseModel _databaseContext;

        public CandidateRepository(JCMSDatabaseModel databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddNew(Candidate candidate)
        {
            _databaseContext.Candidates.Add(candidate);
        }

        public void Delete(Candidate candidate)
        {
            if (_databaseContext.Candidates.Any(c => c.id == candidate.id))
            {
                _databaseContext.Entry(candidate).State=System.Data.Entity.EntityState.Deleted;
            }
        }
        public void Delete(int id)
        {
            if (_databaseContext.Candidates.Any(c => c.id == id))
            {
                Candidate tempCandidate = _databaseContext.Candidates.Where(c => c.id==id).FirstOrDefault();
                _databaseContext.Candidates.Remove(tempCandidate);
            }
        }
        public Candidate GetOnId(int id)
        {
            return _databaseContext.Candidates.Where(C => C.id == id).FirstOrDefault();
        }
        public Candidate GetOnFirstName(string firstName)
        {
            return _databaseContext.Candidates.Where(C => C.firstName == firstName).FirstOrDefault();
        }

        public Candidate GetOnLastName(string lastName)
        {
            return _databaseContext.Candidates.Where(C => C.lastName == lastName).FirstOrDefault();
        }

        public Candidate GetOnEmail(string email)
        {
            return _databaseContext.Candidates.Where(C => C.email == email).FirstOrDefault();
        }

        public List<Candidate> GetAllCandidates()
        {
            return _databaseContext.Candidates.ToList();
        }

        public void Update(Candidate candidate)
        {
            if (_databaseContext.Candidates.Any(c => c.id == candidate.id))
            {
                _databaseContext.Entry(candidate).State = System.Data.Entity.EntityState.Modified;
            }
        }
    }
}
