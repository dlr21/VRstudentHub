using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSearch : MonoBehaviour
{
    private bool focus;
    private GameObject child;
    public Vector3 previousForm;


    void Start()
    {
        child = gameObject.transform.GetChild(transform.childCount - 1).gameObject;
    }

    void Update()
    {

        //Control de la barra verde de seleccion
        if (focus)
        {
            child.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            child.transform.localScale = new Vector3(0f, 0f, 1f);
        }

    }

    public void OnGazeEnter()
    {
        focus = true;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + 0.2f, gameObject.transform.localScale.y + 0.2f, gameObject.transform.localScale.z + 0.2f);
        Debug.Log("Gaze entered");
    }


    public void OnGazeLeave()
    {
        focus = false;
        gameObject.transform.localScale = previousForm;
        Debug.Log("Gaze left");
    }


}