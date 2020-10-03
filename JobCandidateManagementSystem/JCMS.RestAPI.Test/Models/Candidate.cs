using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCMS.RestAPI.Test.Models
{
    public class Candidate
    {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public int age { get; set; }
            public string email { get; set; }
            public string city { get; set; }
            public string address { get; set; }
            public int yearsOfExperience { get; set; }
            public string positionAppliedTo { get; set; }
            public string preferredProgrammingLanguage { get; set; }
            public string resumeText { get; set; }
            public CandidateStatus status { get; set; }
    }
    public enum CandidateStatus
    {
        UnderReview,
        Rejected,
        OfferExtended,
        OfferAccepted,
        OfferRejected
    }
}
