using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PassionProject.Models
{
    public class SongChord
    {
        [Key]
        public int ChordGroupID { get; set; }
        public int ChordOne { get; set; }
        public int ChordTwo { get; set; }
        public int ChordThree { get; set; }
        public int ChordFour { get; set; }

        public ICollection<Chord> Chords { get; set; }
    }
}