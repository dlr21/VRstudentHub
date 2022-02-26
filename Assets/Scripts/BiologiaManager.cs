using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiologiaManager : MonoBehaviour
{

    public string activado;
    private bool cambio;
    // Start is called before the first frame update
    void Start()
    {
        activado = "";
        cambio = false;
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
    }

    public void cambiarReino(string a)
    {

        activado = a;
        cambio = true;

    }

}
