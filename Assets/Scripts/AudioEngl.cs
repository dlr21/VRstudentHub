using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEngl : Audio
{

    public AudioClip[] englClips;

    void Awake()
    {
        music = gameObject.AddComponent<AudioSource>();
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
        if (music.isPlaying) {
            music.Stop();
        }
        music.PlayOneShot(englClips[a],volume);
    }
}
