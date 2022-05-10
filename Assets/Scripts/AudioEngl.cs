using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngl : MonoBehaviour
{

    public AudioSource englSource;
    public AudioClip[] englClips;
    public float volume;



    public void PlayQuestion(int a)
    {
        if (englSource.isPlaying) {
            englSource.Stop();
        }
        englSource.PlayOneShot(englClips[a],volume);
    }


        

}
