using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using PassionProject.Models;
using System.Web.Script.Serialization;
namespace PassionProject.Controllers
{
    public class ChordController : Controller
    {

        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static ChordController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44300/api/chorddata/");
        }

        // GET: Chord/List
        public ActionResult List()
        {
            //Fetch a list of chords
            //curl https://localhost:44300/api/chorddata/listchords
            string url = "listchords";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<Chord> chords = response.Content.ReadAsAsync<IEnumerable<Chord>>().Result;
            Debug.WriteLine("Number of chords in list: ");
            Debug.WriteLine(chords.Count());
            
            return View(chords);
        }

        // GET: Chord/Details/5
        public ActionResult Details(int id)
        {
            //Fetch information for one chord
            //curl https://localhost:44300/api/chorddata/findchord/{id}
            string url = "findchord/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            Chord selectedchord = response.Content.ReadAsAsync<Chord>().Result;
            Debug.WriteLine("Chord received: ");
            Debug.WriteLine(selectedchord.ChordName);
            return View(selectedchord);
        }

        // GET: Chord/New
        public ActionResult New()
        {
            return View();
        }

        // POST: Chord/Create
        [HttpPost]
        public ActionResult Create(Chord chord)
        {
            Debug.WriteLine("the json payload is: ");
            Debug.WriteLine(chord.ChordName);

            string url = "addchord";

            string jsonpayload = jss.Serialize(chord);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            client.PostAsync(url, content);

            return RedirectToAction("List");
        }

        // GET: Chord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chord/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chord/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "findchord/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Chord selectedchord = response.Content.ReadAsAsync<Chord>().Result;
            return View(selectedchord);
        }

        // POST: Chord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "deletechord/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }
    }
}
