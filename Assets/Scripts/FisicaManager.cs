using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FisicaManager : MonoBehaviour
{

    public int resultadoFinal;
    private int aComparar = 0;
    private GameObject left;//correcto
    private GameObject right;
    private GameObject res;
    private bool resuelto;

    private void Awake()
    {
        left = GameObject.Find("10");
        right = GameObject.Find("2");
        res = GameObject.Find("Respuesta"); 

    }

    void Update()
    {


        if (left.GetComponent<Seleccionable>().getSelected())
        {
            ChangeRes(left.name);
        }

        if (right.GetComponent<Seleccionable>().getSelected())
        {
            ChangeRes(right.name);
        }

        resolver();


    }

    public void ChangeRes(string a)
    {
        res.GetComponent<Text>().text = a;
        aComparar = int.Parse(a);
    }

    public void resolver()
    {

        if (aComparar == resultadoFinal)
        {
            Debug.Log("CORRECTO");
            resuelto = true;
        }
        else
        {
            right.transform.localScale = right.GetComponent<Seleccionable>().previousForm;
            Debug.Log("FALSO");
        }

    }

}
