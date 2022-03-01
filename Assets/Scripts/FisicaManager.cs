using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisicaManager : MonoBehaviour
{

    public int resultadoFinal;
    private int aComparar = 0;

    private GameObject pregunta;
    private GameObject left;
    private GameObject leftText;
    private GameObject right;
    private GameObject rightText;
    private GameObject res;


    private string[] preguntas ={"¿Cuál es la resistencia total del circuito?",
        "¿Qué intensidad recorre este circuito?",
        "Si pudiesemos añadir otra resistencia en serie ¿De cuánto tiene que ser esa resistencia para que la intesidad alcance 1 A?" };

    private string[] respuestasL = { "5", "2", "10" };
    private string[] respuestasR = { "6", "5", "5" };
    private int[] correcta = { 5, 2, 5 };

    public int npregunta=0;


    private void Awake()
    {
        left = GameObject.Find("Opcion1");
        right = GameObject.Find("Opcion2");
        res = GameObject.Find("Respuesta");
        pregunta = GameObject.Find("Pregunta");

        leftText= GameObject.Find("Opcion1Text");
        rightText = GameObject.Find("Opcion2Text");


            

    }

    private void Start()
    {
        pregunta.GetComponent<Text>().text = preguntas[npregunta];
        left.name = respuestasL[npregunta];
        leftText.GetComponent<Text>().text = respuestasL[npregunta];
        right.name = respuestasR[npregunta];
        rightText.GetComponent<Text>().text = respuestasR[npregunta];
        resultadoFinal = correcta[npregunta];
        res.GetComponent<Text>().text = "";
    }

    void Update()
    {


        if (left.GetComponent<Seleccionable>().getSelected())
        {
            ChangeRes(left.name);
            resolver();
        }

        if (right.GetComponent<Seleccionable>().getSelected())
        {
            ChangeRes(right.name);
            resolver();
        }


    }

    public void ChangeRes(string a)
    {
        aComparar = int.Parse(a);
    }

    public void resolver()
    {

        if (aComparar == resultadoFinal)
        {
            Debug.Log("CORRECTO");//INSERTAR SONIDO ACIERTO
            SiguientePregunta();

        }
        else
        {
            right.transform.localScale = right.GetComponent<Seleccionable>().previousForm;
            left.transform.localScale = left.GetComponent<Seleccionable>().previousForm;

            left.GetComponent<Seleccionable>().ChangeSelect(false);
            right.GetComponent<Seleccionable>().ChangeSelect(false);

            Debug.Log("FALSO");//INSERTAR SONIDO FALLO
        }

    }

    public void SiguientePregunta() {
        npregunta++;
        if (npregunta < preguntas.Length)
        {
            
            right.transform.localScale = right.GetComponent<Seleccionable>().previousForm;
            left.transform.localScale = left.GetComponent<Seleccionable>().previousForm;

            pregunta.GetComponent<Text>().text = preguntas[npregunta];
            left.name = respuestasL[npregunta];
            right.name = respuestasR[npregunta];
            leftText.GetComponent<Text>().text = respuestasL[npregunta];
            rightText.GetComponent<Text>().text = respuestasR[npregunta];
            res.GetComponent<Text>().text = "";

            resultadoFinal = correcta[npregunta];

            left.GetComponent<Seleccionable>().ChangeSelect(false);
            right.GetComponent<Seleccionable>().ChangeSelect(false);
            Debug.Log("siguiente pregunta");
        }
        else
        {
            res.GetComponent<Text>().text = "Has superado el ejercicio con éxito";
            Debug.Log("no mas preguntas");
        }


    }

}
