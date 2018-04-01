# Geetar Tabs

The aim of this project is to create a tool to create tabs with consistant format.
This is going to be possible due to a simple file format and a parser which feeds information to the core of the program (a GUI that has a tab viewer).

----

Here is what the file format will be

`[(string,fret),(string,fret)][(string,fret),(string,fret)]`

 + The square brackets (`[` and `]`) indicate chords
 + The round brackets (`(` and `)`) indicate a finger position (referred to in the code as `Tab Items`)
 + Whitespace will be ignored (so feel free to pad the hell out of your tab definition files)
