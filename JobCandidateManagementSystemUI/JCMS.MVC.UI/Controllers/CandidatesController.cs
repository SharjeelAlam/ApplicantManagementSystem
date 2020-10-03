using JCMS.Web.MVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections;
using System.Web.Helpers;

namespace JCMS.Web.MVC.Controllers
{
    public class CandidatesController : Controller
    {
        // GET: Candidates

        public ActionResult Index()
        {
            return View();
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Candidates/Create
        public ActionResult NewCandidate()
        {
            return View();
        }

        // POST: Candidates/NewCandidate
        [HttpPost]
        public ActionResult NewCandidate(Candidate candidate)
        {
            string RestApiURL = ConfigurationManager.AppSettings["RestApiURL"].ToString();
            var client = new RestClient(RestApiURL);
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            string jsonCandidate = JsonConvert.SerializeObject(candidate);
            request.AddParameter("application/json",jsonCandidate, ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                TempData["UserMessage"] = "New candidate created successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidates/EditCandidate
        public ActionResult EditCandidate(int candidateId)
        {
            string RestApiURL = ConfigurationManager.AppSettings["RestApiURL"].ToString();
            var client = new RestClient(RestApiURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("id",candidateId);
            try
            {
                IRestResponse response = client.Execute(request);
                Candidate candidate = JsonConvert.DeserializeObject<Candidate>(response.Content);
                ViewData["candidate"] = candidate;
            }
            catch (Exception ex)
            { }
           
            return View();
        }

        // POST: Candidates/UpdateCandidate
        [HttpPost]
        public ActionResult EditCandidate(Candidate candidate)
        {
            string RestApiURL = ConfigurationManager.AppSettings["RestApiURL"].ToString();
            var client = new RestClient(RestApiURL);
            var request = new RestRequest(Method.PUT);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            string jsonCandidate = JsonConvert.SerializeObject(candidate);
            request.AddParameter("application/json", jsonCandidate, ParameterType.RequestBody);
            try
            {
                IRestResponse response = client.Execute(request);
                TempData["UserMessage"] = "Candidate updated successfully";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Candidates/Delete/5
        public ActionResult DeleteCandidate(int candidateId)
        {
            string RestApiURL = ConfigurationManager.AppSettings["RestApiURL"].ToString();
            var client = new RestClient(RestApiURL);
            var request = new RestRequest(Method.DELETE);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("id", candidateId);
            try
            {
                IRestResponse response = client.Execute(request);
                TempData["UserMessage"] = "Candidate deleted successfully";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["UserMessage"] = "Candidate could not be deleted";
                return RedirectToAction("Index");
            }
        }

        public ActionResult ViewAllCandidates(string searchBox = null)
        {
            string RestApiURL = ConfigurationManager.AppSettings["RestApiURL"].ToString();
            var client = new RestClient(RestApiURL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("content-type", "application/json");
            try
            {
                IRestResponse response = client.Execute(request);
                Candidate[] candidate = JsonConvert.DeserializeObject<Candidate[]>(response.Content);
                if (searchBox == null || searchBox == string.Empty)
                {
                    ViewData["candidateList"] = candidate.ToList<Candidate>();
                }
                else
                {
                    List<Candidate> candidateList = candidate.ToList<Candidate>().Where(c => ((c.firstName != null) && c.firstName.Contains(searchBox, StringComparison.OrdinalIgnoreCase)) || ((c.lastName != null) && (c.lastName.Contains(searchBox, StringComparison.OrdinalIgnoreCase)))).ToList();
                    ViewData["candidateList"] = candidateList;
                }
                string[] columnNames = typeof(Candidate).GetProperties().Select(property => property.Name).ToArray();
                //----Code to get fields of Candidate object and creating a WebGridColumns list for automatic column population-----
                //List<WebGridColumn> gridColumns = new List<WebGridColumn>();
                //for (int i = 0; i < columnNames.Length; i++)
                //{
                  //  gridColumns.Add(new WebGridColumn() { ColumnName = columnNames[i], Header = columnNames[i] });
                //}
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }

    public static class stringcomparison
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }
    }
}
