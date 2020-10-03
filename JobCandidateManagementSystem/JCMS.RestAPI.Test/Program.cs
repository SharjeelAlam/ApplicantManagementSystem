using JCMS.RestAPI.Test.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JCMS.RestAPI.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddCandidate();
            DeleteCandidate(6);
            GetCandidates();
        }

        public static void AddCandidate()
        {
            var client = new RestClient("http://localhost:64895/api/Candidate/");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "df7c70e6-cbf3-ca2f-e996-a9aaac49ca21");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                "{\"id\": 5,\"firstName\": \"James\",\"lastName\":\"Moriarty\",\"age\": 26,\"email\": \"James.Moriarty@gmail.com\",\"city\": \"London\",\"address\": \"\",\"yearsOfExperience\": 20,\"positionAppliedTo\": \"Senior .NET Tester\",\"preferredProgrammingLanguage\": \"C#\",\"resumeText\": \"DummyText\",\"status\": 2}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }

        public static void DeleteCandidate(int id)
        {
            var client = new RestClient("http://localhost:64895/api/Candidate/");
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("postman-token", "df7c70e6-cbf3-ca2f-e996-a9aaac49ca21");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json",
                "{\"id\":"+id+",\"firstName\": \"James\",\"lastName\":\"Moriarty\",\"age\": 26,\"email\": \"James.Moriarty@gmail.com\",\"city\": \"London\",\"address\": \"\",\"yearsOfExperience\": 20,\"positionAppliedTo\": \"Senior .NET Tester\",\"preferredProgrammingLanguage\": \"C#\",\"resumeText\": \"DummyText\",\"status\": 2}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
        }
        public static void GetCandidates()
        {
            var client = new RestClient("http://localhost:64895/api/Candidate/");
            var request = new RestRequest(Method.GET);
            request.AddHeader("postman-token", "df7c70e6-cbf3-ca2f-e996-a9aaac49ca21");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            IRestResponse response = client.Execute(request);
            Candidate[] candidate = JsonConvert.DeserializeObject<Candidate[]>(response.Content);
            //Console.WriteLine(response.Content);
            foreach (var c in candidate)
            {
                Console.WriteLine(c.id);
                Console.WriteLine(c.firstName);
                Console.WriteLine(c.lastName);
                Console.WriteLine(c.email);
                Console.WriteLine(c.city);
                Console.WriteLine(c.address);
                Console.WriteLine(c.age);
                Console.WriteLine(c.positionAppliedTo);
                Console.WriteLine(c.preferredProgrammingLanguage);
                Console.WriteLine(c.status);
                Console.WriteLine(c.yearsOfExperience);
                Console.WriteLine(c.resumeText);
                Console.WriteLine("------------");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
