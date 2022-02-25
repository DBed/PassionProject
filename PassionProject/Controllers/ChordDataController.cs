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
    public class ChordDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        // GET: api/ChordData/ListChords
        public IQueryable<Chord> ListChords()
        {
            return db.Chords;
        }

        // GET: api/ChordData/FindChord/5
        [ResponseType(typeof(Chord))]
        [HttpGet]
        public IHttpActionResult FindChord(int id)
        {
            Chord chord = db.Chords.Find(id);
            if (chord == null)
            {
                return NotFound();
            }

            return Ok(chord);
        }

        // POST: api/ChordData/UpdateChord/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateChord(int id, Chord chord)
        {
            Debug.WriteLine("Update Chord method entered");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model state is Invalid");
                return BadRequest(ModelState);
            }

            if (id != chord.ChordID)
            {
                Debug.WriteLine("ID mismatch");
                Debug.WriteLine("GET parameter: " + id);
                Debug.WriteLine("POST parameter: " + chord.ChordID);
                return BadRequest();
            }

            db.Entry(chord).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChordExists(id))
                {
                    Debug.WriteLine("Chord not found");
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

        // POST: api/ChordData/AddChord
        [ResponseType(typeof(Chord))]
        [HttpPost]
        public IHttpActionResult AddChord(Chord chord)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chords.Add(chord);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chord.ChordID }, chord);
        }

        // POST: api/ChordData/DeleteChord/5
        [ResponseType(typeof(Chord))]
        [HttpPost]
        public IHttpActionResult DeleteChord(int id)
        {
            Chord chord = db.Chords.Find(id);
            if (chord == null)
            {
                return NotFound();
            }

            db.Chords.Remove(chord);
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

        private bool ChordExists(int id)
        {
            return db.Chords.Count(e => e.ChordID == id) > 0;
        }
    }
}