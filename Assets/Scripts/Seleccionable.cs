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

    public Vector3 startPosition;
    public Vector3 previousForm;

    public int type;//1 nextScene //2 drag //3 selection //4 seleccionPermanente //5 //desseleccionar en geografia //6 activar reino//7 cuadro//8 audio ingles//

    public string next;

    void Start() 
    {
        child = gameObject.transform.GetChild(0).gameObject;
        startPosition = gameObject.transform.position;
        previousForm = gameObject.transform.localScale;
    }

    void Update()
    {

            //Control de la barra verde de seleccion
        if (focus && !selected && child!=null)
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
            if(child!=null)
                child.transform.localScale = new Vector3(0f, 0.2f, 1f);
        }

    }


    public void OnGazeEnter()
    {
        focus = true;
        gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x+0.5f, gameObject.transform.localScale.y + 0.5f, gameObject.transform.localScale.z+ 0.5f);
    }
    

    public void OnGazeLeave()
    {
        focus = false;
        time = 0;
        gameObject.transform.localScale = previousForm;
    }

    public void Select() {

        if (type == 1)
        {
            Debug.Log("Select 1 " + next);

            SceneManager.LoadScene(next);
        }
        else if (type == 2 || type == 3 )
        {
            Debug.Log("Select 2 ");
            ChangeSelect(true);
        }
        else if (type == 4)
        {
            Debug.Log("Select 4");
            if (GameObject.Find("Cube").GetComponent<HistoriaManager>().resolver(int.Parse(next)))
            {
                type = 0;
            }
        }
        else if (type == 5)
        {
            GameObject.Find("Cube").GetComponent<GeografiaManager>().changeNombreSelect(false);
        }
        else if (type == 6) {
            Debug.Log("Select 6");
            GameObject.Find("Cube").GetComponent<BiologiaManager>().cambiarReino(next);
        } else if (type == 7) {
            Debug.Log("Select 7");
            gameObject.GetComponent<BioCuadro>().reinoCorrecto(GameObject.Find("Cube").GetComponent<BiologiaManager>().activado);
        }else if (type == 8)
        {
            Debug.Log("Select 8");
            GameObject.Find("Cube").GetComponent<EnglishManager>().audioPregunta();
        }else if (type == 9)
        {
            Debug.Log("Select 9");
            GameObject.Find("Cube").GetComponent<EnglishManager>().comprobarCorrecta(int.Parse(next));
        }

    }

    public void ChangeSelect(bool s)
    {
        selected = s;
    }

    public bool getSelected() { return selected; }

    
}
