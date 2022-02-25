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
    public class SongChordController : Controller
    {

        private static readonly HttpClient client;

        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static SongChordController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44300/api/songchorddata/");
        }
        // GET: SongChord/List
        public ActionResult List()
        {
            //fetch a list of SongChord IDs
            //curl https://localhost:44300/api/songchorddata/listsongchords
            string url = "listsongchords";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<SongChord> songchords = response.Content.ReadAsAsync<IEnumerable<SongChord>>().Result;
            Debug.WriteLine("Number of Song Chord IDs in list: ");
            Debug.WriteLine(songchords.Count());
            
            return View(songchords);
        }

        // GET: SongChord/Details/5
        public ActionResult Details(int id)
        {
            //fetch one song chord set
            //curl https://localhost:44300/api/songchorddata/findsongchord/{id}
            string url = "findsongchord/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode);

            SongChord selectedsongchord = response.Content.ReadAsAsync<SongChord>().Result;
            Debug.WriteLine("Song Chord Set received: ");
            Debug.WriteLine(selectedsongchord.ChordGroupID);

            return View(selectedsongchord);
        }

        // GET: SongChord/New
        public ActionResult New()
        {
            return View();
        }

        // POST: SongChord/Create
        [HttpPost]
        public ActionResult Create(SongChord songchord)
        {
            Debug.WriteLine("the json payload is: ");
            Debug.WriteLine(songchord.ChordGroupID);

            string url = "addsongchord";

            string jsonpayload = jss.Serialize(songchord);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            client.PostAsync(url, content);

            return RedirectToAction("List");
        }

        // GET: SongChord/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SongChord/Edit/5
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

        // GET: SongChord/Delete/5
        public ActionResult DeleteConfirm(int id)
        {
            string url = "findsongchord/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            SongChord selectedsongchord = response.Content.ReadAsAsync<SongChord>().Result;
            return View(selectedsongchord);
        }

        // POST: SongChord/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            string url = "deletesongchord/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }
    }
}
