﻿using System;
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
    public class SongController : Controller
    {
        private static readonly HttpClient client;

        private JavaScriptSerializer jss = new JavaScriptSerializer();

        static SongController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44300/api/songdata/");
        }
        // GET: Song/List
        public ActionResult List()
        {
            //Use song data to retrieve a list of songs
            string url = "songdata/list";
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
            string url = "songdata/findsong/"+id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            Debug.WriteLine("the response code is ");
            Debug.WriteLine(response.StatusCode);

            SongDto selectedsong = response.Content.ReadAsAsync<SongDto>().Result;
            //Show the total number of songs in the console.
            Debug.WriteLine("Song received:");
            Debug.WriteLine(selectedsong.SongName);
           
            return View(selectedsong);
        }

        // GET: Song/New
        public ActionResult New()
        {

            return View();
        }

        // POST: Song/Create
        [HttpPost]
        public ActionResult Create(Song song)
        {
            Debug.WriteLine("the json payload is: ");
            Debug.WriteLine(song.SongName);
            
            string url = "songdata/addsong";

            string jsonpayload = jss.Serialize(song);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            
            client.PostAsync(url, content);

            return RedirectToAction("List");
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
        public ActionResult DeleteConfirm(int id)
        {
            string url = "songdata/findsong/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Song selectedsong = response.Content.ReadAsAsync<Song>().Result;
            return View(selectedsong);
        }

        // POST: Song/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "deletesong/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            return RedirectToAction("List");
        }
    }
}
