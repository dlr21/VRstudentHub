using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngl : MonoBehaviour
{

    public AudioSource englSource;
    public AudioClip[] englClips;
    public float volume;

    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayQuestion(int a)
    {
        if (englSource.isPlaying) {
            englSource.Stop();
        }
        englSource.PlayOneShot(englClips[a],volume);
    }


        

}
