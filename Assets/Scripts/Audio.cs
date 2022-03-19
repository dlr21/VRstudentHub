using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Audio : MonoBehaviour
{

    public AudioSource music;
    private AudioClip[] audioClips=new AudioClip[4];

    //audio para musica, acierto, error
    void Awake()
    {
        audioClips[0] = Resources.Load<AudioClip>("Audio/Cositas/Error"); //error
        audioClips[1] = Resources.Load<AudioClip>("Audio/Cositas/Correct");//correct
        audioClips[2] = Resources.Load<AudioClip>("Audio/Cositas/Pop");//pop
        audioClips[3] = Resources.Load<AudioClip>("Audio/Cositas/Fin");//fin
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
        music.PlayOneShot(audioClips[0], 1);
    }

    public void playCorrect()
    {
        music.PlayOneShot(audioClips[1], 1);
    }

    public void playPop()
    {
        music.PlayOneShot(audioClips[2], 1);
    }
    public void playFin()
    {
        music.PlayOneShot(audioClips[3], 1);
    }
}
