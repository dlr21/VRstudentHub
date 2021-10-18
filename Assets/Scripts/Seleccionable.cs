using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Seleccionable : MonoBehaviour
{

    private bool focus;
    private float selectTime = 3.0f;
    private float time = 0f;
    private GameObject child;
    public int type;//1 nextScene //2 drag //3 selection
    public string next;

    private void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (focus)
        {
            time += Time.deltaTime;
            float aux = time / selectTime;
            child.transform.localScale = new Vector3(aux, 0.2f, 1f);
            if (time >= selectTime)
            {

                time = 0;
                Select();
            }
        }else {
            child.transform.localScale = new Vector3(0f, 0.2f, 1f);
        }

    }
    // This event is going to be fired when we look at the sphere
    public void OnGazeEnter()
    {
        focus = true;
        gameObject.transform.localScale = new Vector3(2.5f, 2.5f, 1f);
        Debug.Log("Gaze entered");
    }

    // This event is going to be fired when we stop looking at the sphere
    public void OnGazeLeave()
    {
        focus = false;
        time = 0;
        gameObject.transform.localScale = new Vector3(2f, 2f, 1f);
        Debug.Log("Gaze left");
    }

    public void Select() {
        if (type == 1) {
            SceneManager.LoadScene(next);
        }
    }

}
