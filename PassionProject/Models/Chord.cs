using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace PassionProject.Models
{
    public class Chord
    {
        [Key]
        public int ChordID { get; set; }
        public string ChordName { get; set; }
        public string StringOne { get; set; }
        public string StringTwo { get; set; }
        public string StringThree { get; set; }
        public string StringFour { get; set; }
        public string StringFive { get; set; }
        public string StringSix { get; set; }

        public ICollection<SongChord> SongChords { get; set; }
    }
}