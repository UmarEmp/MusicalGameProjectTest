using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System.Linq;

public class audioSett : MonoBehaviour
{
    public Transform sphereObject;
    AudioSource audioSource;
    AudioClip audioClip;
    // Start is called before the first frame update
    

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = audioSource.clip;
        Debug.Log("Audio clip length : " + audioSource.clip.length);
        MidiFile midiFile = MidiFile.Read("Qwerty.mid");
        IEnumerable<Note> notes = midiFile.GetNotes();
        IEnumerable<Chord> chordes = midiFile.GetChords();
        IEnumerable<TrackChunk> trackChunks = midiFile.GetTrackChunks();
        TempoMap tempoMap = midiFile.GetTempoMap();
        var midiFileDuration = midiFile.GetTimedEvents()
                              .LastOrDefault(e => e.Event is NoteOffEvent)
                             ?.TimeAs<MetricTimeSpan>(tempoMap)
                             ?? new MetricTimeSpan();

        Debug.Log(midiFileDuration);
        float[] arrayTimeForSecond = new float[notes.ToArray().Length];
        float TrackMidiLengths = (midiFileDuration.Milliseconds / 1000 + midiFileDuration.Seconds + midiFileDuration.Minutes * 60) / audioSource.clip.length;
        Debug.Log(TrackMidiLengths);
        for (int i = 0; i < notes.ToArray().Length; i++)
        {
            MetricTimeSpan metricTime = notes.ToArray()[i].TimeAs<MetricTimeSpan>(tempoMap);
            
            arrayTimeForSecond[i] = (metricTime.Milliseconds / 1000 + metricTime.Seconds + metricTime.Minutes * 60) / TrackMidiLengths;
            Debug.Log(arrayTimeForSecond[i]);

        }
        int[] MusicElement = new  int[arrayTimeForSecond.Length]; 

        for (int i = 0; i < arrayTimeForSecond.Length - 1; i++)
        {
            float k = arrayTimeForSecond[i]; int ii = i + 1; ; bool prk = true;
            while (prk)
            {
                if (k == arrayTimeForSecond[ii] && ii < arrayTimeForSecond.Length - 1)
                {
                    ii++;
                }
                else prk = false;
            }
            if (ii > i + 1)
            {
                float pogr = 0.2f;
                for (int j = i + 1; j < ii; j++)
                {
                    arrayTimeForSecond[j] += pogr; pogr += 0.2f;
                }
            }
            Debug.Log(arrayTimeForSecond[i]);
            
        }

        Debug.Log(notes.ToArray().Length);

        for (int i = 0; i < arrayTimeForSecond.Length; i++)
        {
            var newObj = Instantiate(sphereObject, Vector3.forward * arrayTimeForSecond[i] * 2, Quaternion.Euler(0, 0, 0), transform);
        }

    }
}