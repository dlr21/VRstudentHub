using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio : MonoBehaviour
{

    public AudioSource music;
    private AudioClip[] audioClips;
    public float volume;

    //audio para musica, acierto, error
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
}
