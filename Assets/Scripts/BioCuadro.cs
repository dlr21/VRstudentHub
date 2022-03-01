using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BioCuadro : MonoBehaviour
{

    public Vector3 correctPosition;
    public Vector3 correctRotation;
    public string reino;
    public bool colocado;


    // Start is called before the first frame update
    void Start()
    {

        colocado = false;
        
    }

    // Update is called once per frame
    void Update()
    {


    }


    public bool reinoCorrecto(string s) {
        bool b = false;
        
        if (s == reino && !colocado) {
            b = true;
            colocado = true;
            if (colocado)
            {
                gameObject.transform.position = correctPosition;
                gameObject.transform.rotation = Quaternion.Euler(correctRotation);
                gameObject.GetComponent<Seleccionable>().type = 0;
                gameObject.GetComponent<Seleccionable>().ChangeSelect(false);
                Destroy(gameObject.transform.GetChild(0).gameObject);
            }
        }
        Debug.Log("comparando " + s + " con " + reino+" es "+b);
        return b;
    }



}
