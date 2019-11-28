using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Smf;
using Melanchall.DryWetMidi.Smf.Interaction;
using System.Linq;




public class NewBehaviourScript : MonoBehaviour
{
    public Transform sphereObject;
    public Material red, green, blue;
    AudioSource audioSource;
    AudioClip audioClip;


    // Start is called before the first frame update
    void Awake()
    {
        
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Audio clip length : " + audioSource.clip.length);
        MidiFile midiFile = MidiFile.Read("HouseDemo.mid");
     
      //  midiFile.ReplaceTempoMap(TempoMap.Create(Tempo.FromBeatsPerMinute(727)));
        TempoMap tempoMap = midiFile.GetTempoMap();
        var midiFileDuration = midiFile.GetTimedEvents()
                              .LastOrDefault (e => e.Event is NoteOffEvent)
                             ?.TimeAs<MetricTimeSpan>(tempoMap)
                             ?? new MetricTimeSpan();
        
        
        Debug.Log(midiFileDuration);
 
        float TrackMidiLengths = (midiFileDuration.TotalMicroseconds) / (audioSource.clip.length*1000000f);
        //midiFile.ProcessTimedEvents(e => e.Time /= Mathf.FloatToHalf(TrackMidiLengths));
        IEnumerable<Note> notes = midiFile.GetNotes();
        float[] arrayTimeForSecond = new float[notes.ToArray().Length];

        Debug.Log(TrackMidiLengths);
        for (int i = 0; i < notes.ToArray().Length; i++)
        {

            if (i==0) {
                MetricTimeSpan metric = notes.ToArray()[i].TimeAs<MetricTimeSpan>(tempoMap); float a = metric.TotalMicroseconds / 1000000f;
                Debug.Log("a=="+a);
                MetricTimeSpan metricl = notes.ToArray()[i].LengthAs<MetricTimeSpan>(tempoMap); float al = metricl.TotalMicroseconds / 1000000f;
                Debug.Log("a==" + al);

            }
            MetricTimeSpan metricLength = notes.ToArray()[i].LengthAs<MetricTimeSpan>(tempoMap);
            MetricTimeSpan metricTime = notes.ToArray()[i].TimeAs<MetricTimeSpan>(tempoMap);
        
            arrayTimeForSecond[i] = metricTime.TotalMicroseconds/1000000f / TrackMidiLengths/1.039f+metricLength.TotalMicroseconds/2000000f;
           // Debug.Log(arrayTimeForSecond[i]);


        }


        for (int i=0; i < arrayTimeForSecond.Length; i++)
        {
           // float r1 = Random.Range(-0.5f, 0.5f);
           // float r2 = Random.Range(-0.5f, 0.5f);
            var newObj = Instantiate(sphereObject, new Vector3(0,0, arrayTimeForSecond[i] * 2f), Quaternion.Euler(0, 0, 0), transform);
            if(i % 3 == 0) newObj.transform.GetComponent<Renderer>().sharedMaterial = red;
            else if(i % 3 == 1) newObj.transform.GetComponent<Renderer>().sharedMaterial = green;
            else newObj.transform.GetComponent<Renderer>().sharedMaterial = blue;

           // Debug.Log(arrayTimeForSecond[i]);
        }

        // Debug.Log(tempoMap.Tempo.ToString());
    }

    void oylesine()
    {
        /* for (int i = 0; i < arrayTimeForSecond.Length-1; i++)
 {
     float k = arrayTimeForSecond[i]; int ii = i+1; ;  bool prk = true;
     while (prk)
     {
         if (k == arrayTimeForSecond[ii] && ii< arrayTimeForSecond.Length-1)
         {
             ii++;
         }
         else prk = false;
     }
     if (ii > i + 1  )
     {
         float pogr = 0.05f;
         for(int j=i+1; j < ii; j++)
         {
             arrayTimeForSecond[j] += pogr; pogr += 0.05f;
         }
         i = ii + 1;
     }
     //Debug.Log(arrayTimeForSecond[i]);

 }*/

        //   Debug.Log(notes.ToArray().Length);
    }
}
