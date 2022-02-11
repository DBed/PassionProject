using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject.Models
{
    public class Song
    {
        [Key]
        public int SongID { get; set; }
        public string SongName { get; set; }
        public string SongArtist { get; set; }
        
        //A song can only have one SongChordID (The chords used to play the song)
        //EG: A SongChordID could match up with multiple songs (two different songs each use the chords A, E, D)
        public string SongDifficulty { get; set; }
        [ForeignKey("SongChord")]
        public int SongChords { get; set; }
        public virtual SongChord SongChord { get; set; }
    }

    //Simplified version of the song class for use in the web API environment
    //Excludes foreign keys and other connections
    public class SongDto
    { 
        public int SongID { get; set; }
        public string SongName { get; set; }
        public string SongArtist { get; set; }
        public string SongDifficulty { get; set; }

        public int SongChords { get; set; }
    }
}