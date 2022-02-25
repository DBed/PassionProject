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
    public class SongChordDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SongChordData/ListSongChords
        [HttpGet]
        public IQueryable<SongChord> ListSongChords()
        {
            return db.SongChords;
        }

        // GET: api/SongChordData/FindSongChord/5
        [ResponseType(typeof(SongChord))]
        [HttpGet]
        public IHttpActionResult FindSongChord(int id)
        {
            SongChord songChord = db.SongChords.Find(id);
            if (songChord == null)
            {
                return NotFound();
            }

            return Ok(songChord);
        }

        // POST: api/SongChordData/UpdateSongChord/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateSongChord(int id, SongChord songChord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != songChord.ChordGroupID)
            {
                return BadRequest();
            }

            db.Entry(songChord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongChordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SongChordData/AddSongChord
        [ResponseType(typeof(SongChord))]
        [HttpPost]
        public IHttpActionResult AddSongChord(SongChord songChord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SongChords.Add(songChord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = songChord.ChordGroupID }, songChord);
        }

        // POST: api/SongChordData/DeleteSongChord5
        [ResponseType(typeof(SongChord))]
        [HttpPost]
        public IHttpActionResult DeleteSongChord(int id)
        {
            SongChord songChord = db.SongChords.Find(id);
            if (songChord == null)
            {
                return NotFound();
            }

            db.SongChords.Remove(songChord);
            db.SaveChanges();

            return Ok(songChord);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongChordExists(int id)
        {
            return db.SongChords.Count(e => e.ChordGroupID == id) > 0;
        }
    }
}