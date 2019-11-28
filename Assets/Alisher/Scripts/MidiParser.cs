using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MidiParser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

      
        MidiFile midiFile = MidiFile.Read("Simpsons.mid");
        TempoMap tempoMap = midiFile.GetTempoMap();
        Note note = midiFile.GetNotes().First();
        //Или вы можете найти все ноты MIDI-файла, которые начинаются со времени 10 тактов и 4 тактов:
        IEnumerable<Note> notes = midiFile.GetNotes()
                                          .AtTime(new BarBeatTimeSpan(10, 4), tempoMap);


        //Если вы хотите, например, узнать длину MIDI-файла в минутах и ​​секундах, вы можете использовать этот код
        var midiFileDuration = midiFile.GetTimedEvents()
                               .LastOrDefault(e => e.Event is NoteOffEvent)
                              ?.TimeAs<MetricTimeSpan>(tempoMap)
                              ?? new MetricTimeSpan();

        Debug.Log(midiFileDuration);
       //int number  = (from t  in notes select t)
        
       // var musicalLength = note.LengthAs<MusicalTimeSpan>(tempoMap);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
