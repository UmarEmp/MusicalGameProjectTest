using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MyAudioSett : MonoBehaviour
{

    void Start()
    {
        MidiFile midiFile = MidiFile.Read("Qwerty.mid");

        TempoMap tempoMap = midiFile.GetTempoMap();

        using (var notesManager = midiFile.GetTrackChunks().First().ManageNotes())
        {
            var notesEndedAt20Seconds = notesManager.Notes
                                                    .EndAtTime(new MetricTimeSpan(0, 0, 20),
                                                               tempoMap);

            var firstNoteLength = notesEndedAt20Seconds.First()
                                                       .LengthAs<MetricTimeSpan>(tempoMap);


        }
    }
}
