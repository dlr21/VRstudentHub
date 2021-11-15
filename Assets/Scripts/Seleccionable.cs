using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Seleccionable : MonoBehaviour
{

    private bool focus;
    private bool selected;

    public float selectTime = 3.0f;
    private float time = 0f;

    private GameObject child;
    public Vector3 previousForm;

    public int type;//1 nextScene //2 drag //3 selection //0 default
    public string next;

    void Start() 
    {
        child = gameObject.transform.GetChild(0).gameObject;
    }

    void Update()
    {

        //Control de la barra verde de seleccion
        if (focus && !selected)
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


    public void OnGazeEnter()
    {
        focus = true;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x+0.5f, gameObject.transform.localScale.y + 0.5f, 1f);
        Debug.Log("Gaze entered");
    }
    

    public void OnGazeLeave()
    {
        focus = false;
        time = 0;
        gameObject.transform.localScale = previousForm;
        Debug.Log("Gaze left");
    }

    public void Select() {

        if (type == 1) {
            Debug.Log("Select 1 " + next);
            SceneManager.LoadScene(next);
        }

        if (type == 3) {
            Debug.Log("Select 3");
            ChangeSelect(true); 
            previousForm = gameObject.transform.localScale;
        }

    }

    private void ChangeSelect(bool s)
    {
        selected = s;
    }

    public bool getSelected() { return selected; }
}
