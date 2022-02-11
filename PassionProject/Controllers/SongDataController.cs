using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProject.Models;
using System.Diagnostics;

namespace PassionProject.Controllers
{
    public class SongDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        // GET: api/SongData/ListSongs
        public IEnumerable<SongDto> ListSongs()
        {
            List<Song> Songs = db.Songs.ToList();
            List<SongDto> SongDtos = new List<SongDto>();

            Songs.ForEach(s => SongDtos.Add(new SongDto(){
                SongID = s.SongID,
                SongName = s.SongName,
                SongArtist = s.SongArtist,
                SongDifficulty = s.SongDifficulty,
                SongChords = s.SongChords
            }));

            return SongDtos;
        }

        // GET: api/SongData/FindSong/5
        [ResponseType(typeof(Song))]
        [HttpGet]
        public IHttpActionResult FindSong(int id)
        {
            Song Song = db.Songs.Find(id);
            SongDto SongDto = new SongDto()
            {
                SongID = Song.SongID,
                SongName = Song.SongName,
                SongArtist = Song.SongArtist,
                SongDifficulty = Song.SongDifficulty,
                SongChords = Song.SongChords
            };
            if (Song == null)
            {
                return NotFound();
            }

            return Ok(SongDto);
        }

        // POST: api/SongData/UpdateSong/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateSong(int id, Song song)
        {
            Debug.WriteLine("Update Song Method Entered");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model State invalid");
                return BadRequest(ModelState);
            }

            if (id != song.SongID)
            {
                //checking to see if this part of the function is used
                Debug.WriteLine("Invalid ID");
                Debug.WriteLine("GET Parameter: " + id);
                Debug.WriteLine("POST parameter: " + song.SongID);
                return BadRequest();
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    Debug.WriteLine("Song not found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Debug.WriteLine("None of the conditions triggered");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SongData/AddSong
        [ResponseType(typeof(Song))]
        [HttpPost]
        public IHttpActionResult AddSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Songs.Add(song);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = song.SongID }, song);
        }

        // POST: api/SongData/DeleteSong/5
        [ResponseType(typeof(Song))]
        [HttpPost]
        public IHttpActionResult DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.SongID == id) > 0;
        }
    }
}