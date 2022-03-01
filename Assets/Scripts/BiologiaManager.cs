using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiologiaManager : MonoBehaviour
{

    public string activado;
    private bool cambio;
    private GameObject[] cuadros=new GameObject[10];
    private GameObject res;
    // Start is called before the first frame update
    void Start()
    {
        activado = "";
        cambio = false;

        string s = "";
        for (int i = 0; i < 10; i++)
        {
            if (i == 0)
            {
                s = "Animal1";
            }
            else if (i == 1)
            {
                s = "Animal2";
            }
            else if (i == 2)
            {
                s = "Vegetal1";
            }
            else if (i == 3)
            {
                s = "Vegetal2";
            }
            else if (i == 4)
            {
                s = "Monera1";
            }
            else if (i == 5)
            {
                s = "Monera2";
            }
            else if (i == 6)
            {
                s = "Protista1";
            }
            else if (i == 7)
            {
                s = "Protista2";
            }
            else if (i == 8)
            {
                s = "Fungi1";
            }
            else if (i == 9)
            {
                s = "Fungi2";
            }
            Debug.Log(s+" "+i);
            cuadros[i] = GameObject.Find(s);

        }

        res = GameObject.Find("Respuesta");
    }

    // Update is called once per frame
    void Update()
    {
        if (cambio)
        {
            if (activado == "Animal")
            {
                Debug.Log("CAMBAIR A Animal");
                cambio = false;
            }
            else if (activado == "Vegetal")
            {
                Debug.Log("CAMBAIR A Vegetal");
                cambio = false;
            }
            else if (activado == "Monera")
            {
                Debug.Log("CAMBAIR A Monera");
                cambio = false;
            }
            else if (activado == "Protista")
            {
                Debug.Log("CAMBAIR A Protista");
                cambio = false;
            }
            else if (activado == "Fungi")
            {
                Debug.Log("CAMBAIR A Fungi");
                cambio = false;
            }
        }

        comprobarColocados();
    }

    public void comprobarColocados()
    {
        int colocados = 0;
        for (int i = 0; i < cuadros.Length; i++)
        {
            if (cuadros[i].GetComponent<BioCuadro>().colocado)
            {
                colocados++;
            }
        }
        if (colocados == 10) {
            res.GetComponent<Text>().text = "Has superado el ejercicio con éxito";
        }
    }

    public void cambiarReino(string a)
    {

        activado = a;
        cambio = true;

    }

}
