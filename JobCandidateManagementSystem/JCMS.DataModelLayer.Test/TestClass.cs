using JCMS.DataModelLayer;
using JCMS.DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.Tests.DataModelLayer.Test
{
    class TestClass
    {
        static void Main(string[] args)
        {
            try
            {
                AddNewCandidate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            }

        public static void AddNewCandidate()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new JCMSDatabaseModel());
            Candidate candidate = new Candidate()
            {
                id = 3,
                address = "Baker Street",
                age = 22,
                city = "London",
                email = "Sherlock.Holmes@gmail.com",
                firstName = "Sherlock",
                lastName = "Holmes",
                yearsOfExperience = 15,
                positionAppliedTo = "Senior .NET Developer",
                preferredProgrammingLanguage = "C#",
                resumeText = "DummyText",
                status = Enums.CandidateStatus.UnderReview
            };
            unitOfWork.candidateRepo.AddNew(candidate);
            unitOfWork.SaveChanges();
        }
    }
}
