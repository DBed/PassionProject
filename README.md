# PassionProject - Chord Companion

Current state:
  - Tables are added with content
  - foreign keys are connected
  - Basic CRUD through curl requests seems to work
  - Simple views created for Songs table as List or individual entries based on SongID
  
  To-Do:

  - A LOT
  - I want to connect the Songs table to the SongChords table which is in turn connected to the Chords table
    - User selects a song, the database receives the user's selection, then uses the SongID to pull chord information from Songchords, then displays each of the relevant chords by referring to the actual Chords table (Will think of better table names in the future)
    - Not sure if this connection between tables is most efficient, feels like it could be simpler
  - -Individual songs should have the associated chords listed below them
    - Upon clicking a chord, redirect to a new view that shows which strings/frets to press with a simple graphic
  - Need to implement CRUD functions at the view level
    - User should evntually be able to edit song info
      - Song name, artist, difficulty for sure
      - would like the ability to add additional chords from a drop down menu which pulls chord data from existing entries on the chord table
    - User should be able to add their own chords by interacting with a "String one, select fret" style interface 
    - Would like to have SongChord table data list sets of chords visually for people to choose from if they want to add a new song
    -Would be  super cool to implement chord data to create dynamic chord diagrams using grid or some other tightly organized CSS tool, that's a ways off though
 
