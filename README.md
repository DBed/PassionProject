# PassionProject - Chord Companion

Current state:
  - Basic Create and Delete functionality added
  - Views for each table built in basic HTML
  - links between pages work
  
  To-Do:

  - A LOT
  - I want to connect the Songs table to the SongChords table which is in turn connected to the Chords table
    - User selects a song, the database receives the user's selection, then uses the SongID to pull chord information from Songchords, then displays each of the relevant chords by referring to the actual Chords table (Will think of better table names in the future)
    - Upon clicking a chord, redirect to a new view that shows which strings/frets to press with a simple graphic
  - Need to implement Update functions at the view level
    - User should evntually be able to edit song info
      - Song name, artist, difficulty for sure
      - would like the ability to add additional chords from a drop down menu which pulls chord data from existing entries on the chord table 
    - Would like to have SongChord table data list sets of chords visually for people to choose from if they want to add a new song
    -Would be  super cool to implement chord data to create dynamic chord diagrams using grid or some other tightly organized CSS tool, that's a ways off though
 
