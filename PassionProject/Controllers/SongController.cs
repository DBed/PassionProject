using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Diagnostics;
using PassionProject.Models;

namespace PassionProject.Controllers
{
    public class SongController : Controller
    {
        // GET: Song/List
        public ActionResult List()
        {
            //Use song data to retrieve a list of songs

            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44300/api/songdata/listsongs";
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the response code is ");
            Debug.WriteLine(response.StatusCode);

            IEnumerable<SongDto> songs = response.Content.ReadAsAsync<IEnumerable<SongDto>>().Result;
            //Show the total number of songs in the console.
            Debug.WriteLine("Number of songs received:");
            Debug.WriteLine(songs.Count());


            return View(songs);
        }

        // GET: Song/Details/5
        public ActionResult Details(int id)
        {
            HttpClient client = new HttpClient() { };
            string url = "https://localhost:44300/api/songdata/findsong/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the response code is ");
            Debug.WriteLine(response.StatusCode);

            SongDto selectedsong = response.Content.ReadAsAsync<SongDto>().Result;
            //Show the total number of songs in the console.
            Debug.WriteLine("Song received:");
            Debug.WriteLine(selectedsong.SongName);
           
            return View(selectedsong);
        }

        // GET: Song/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Song/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Song/Edit/5
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

        // GET: Song/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
