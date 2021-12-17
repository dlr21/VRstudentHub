using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HistoriaManager : MonoBehaviour
{


    private GameObject pregunta;
    private GameObject cuantos;
    private GameObject res;
    /*primario Agricultura.Ganadería.Pesca.Explotación de los recursos forestales.Minería.
    secundario textiles industria fabricas
    terciario Comercio Medicos Profesores
    */

    private string[] preguntas = { "Indica las actividades pertenecientes al sector primario.",
        "Indica las actividades pertenecientes al sector secundario.",
        "Indica las actividades pertenecientes al sector terciario." };


    public int npregunta = 0;

    private int[] correcta = { 1, 2, 3 };//primario, secundario, terciario
    private int[] totalCorrectas = { 2, 2, 2 };
    private int resueltos=0;


    private void Awake()
    {
        res = GameObject.Find("Respuesta");
        cuantos= GameObject.Find("Cuantos");
        pregunta = GameObject.Find("Pregunta");
    }

    private void Start()
    {
        pregunta.GetComponent<Text>().text = preguntas[npregunta];
        cuantos.GetComponent<Text>().text = resueltos+"/"+totalCorrectas[npregunta];
        res.GetComponent<Text>().text = "";
    }


    public bool resolver(int i)
    {
        if (i == correcta[npregunta])
        {
            resueltos++;
            cuantos.GetComponent<Text>().text = resueltos + "/" + totalCorrectas[npregunta];
            res.GetComponent<Text>().text = "ACIERTO";

            Debug.Log("CORRECTO");//INSERTAR SONIDO ACIERTO
            if (resueltos == totalCorrectas[npregunta]) {
                SiguientePregunta();
            }
            return true;
        } else if (i==0) {
            Debug.Log("YA ELEGIDA");//INSERTAR SONIDO ACIERTO
            return false;
        } else
        {
            res.GetComponent<Text>().text = "ERROR";
            Debug.Log("FALSO");//INSERTAR SONIDO FALLO
            return false;
        }

    }

    public void SiguientePregunta()
    {
        npregunta++;
        if (npregunta < preguntas.Length)
        {

            resueltos = 0;
            cuantos.GetComponent<Text>().text = resueltos + "/" + totalCorrectas[npregunta];
            pregunta.GetComponent<Text>().text = preguntas[npregunta];
            res.GetComponent<Text>().text = "";
            
            Debug.Log("siguiente pregunta");
        }
        else
        {
            res.GetComponent<Text>().text = "FIN";
            Debug.Log("no mas preguntas");
        }


    }

}
