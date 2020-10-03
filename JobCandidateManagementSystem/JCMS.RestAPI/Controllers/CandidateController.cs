using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JCMS.DataModelLayer;
using JCMS.DataModelLayer.Models;

namespace JCMS.RestAPI.Controllers
{
    public class CandidateController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Candidate> Get()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            List<Candidate> candidateList = unitOfWork.candidateRepo.GetAllCandidates();
            return candidateList;
        }

        // GET api/<controller>/5
        public Candidate Get(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            Candidate candidate = unitOfWork.candidateRepo.GetOnId(id);
            return candidate;
        }

        // POST api/<controller>/CandidateObject
        public void Post(Candidate candidate)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            unitOfWork.candidateRepo.AddNew(candidate);
            unitOfWork.SaveChanges();
        }

        // PUT api/<controller>/CandidateObjectWithExistingID
        public void Put(Candidate candidate)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            unitOfWork.candidateRepo.Update(candidate);
            unitOfWork.SaveChanges();
        }

        // DELETE api/<controller>/CandidateObject
        public void Delete(Candidate candidate)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            unitOfWork.candidateRepo.Delete(candidate);
            unitOfWork.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            unitOfWork.candidateRepo.Delete(id);
            unitOfWork.SaveChanges();
        }
    }
}