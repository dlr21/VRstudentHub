using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio : MonoBehaviour
{

    public AudioSource music;
    private AudioClip[] audioClips=new AudioClip[4];
    public float volume;

    //audio para musica, acierto, error
    void Awake()
    {
        audioClips[0] = Resources.Load<AudioClip>("Audio/Cositas/button_002");
        audioClips[1] = Resources.Load<AudioClip>("Audio/Cositas/send");
        audioClips[2] = Resources.Load<AudioClip>("Audio/Cositas/alert");
        audioClips[3] = Resources.Load<AudioClip>("Audio/Cositas/alert");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log("espacioooo");
            playError();
        }
    }

    public void playError() {
        music.PlayOneShot(audioClips[0], volume);
    }

    public void playCorrect()
    {
        music.PlayOneShot(audioClips[1], volume);
    }

    public void playPop()
    {
        music.PlayOneShot(audioClips[2], volume);
    }
    public void playFin()
    {
        music.PlayOneShot(audioClips[3], volume);
    }
}
