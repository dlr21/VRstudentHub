using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeografiaManager : MonoBehaviour
{

    GameObject _madrid;
    GameObject _posMadrid;

    GameObject[] _comunidad= new GameObject[19];
    GameObject[] _posComunidad= new GameObject[19];

    private string [] _lugares= {"Madrid", "Catalunya", "cValenciana","Andalucia",
        "Aragon","Asturias","Islas Baleares","Islas Canarias",
        "Cantabria","cLaMancha","cYleon","Ceuta","Extremadura","Galicia",
        "LaRioja","Melilla","Murcia", "Navarra","PaisVasco"};

    private string[] _posiciones ={"posMadrid", "posCatalunya", "poscValenciana","posAndalucia",
        "posAragon","posAsturias","posBaleares","posCanarias",
        "posCantabria","poscLaMancha","poscYleon","posCeuta","posExtremadura","posGalicia",
        "posLaRioja","posMelilla","posMurcia", "posNavarra","posPaisVasco"};

    Vector3 posAux=new Vector3(0,-1.2f,0);
    Vector3 sizeAux = new Vector3(0.5f, 0.25f, 0.5f);

    // Start is called before the first frame update



    void Start()
    {
        

         for (int i = 0; i < _lugares.Length; i++) {
             if(GameObject.Find(_lugares[i]) != null)
                 _comunidad[i] = GameObject.Find(_lugares[i]);
         }

        for (int j = 0; j < _posiciones.Length; j++)
        {
            if (GameObject.Find(_posiciones[j]) != null)
                _posComunidad[j] = GameObject.Find(_posiciones[j]);
        }

     /* _madrid = GameObject.Find("Madrid");
       _posMadrid = GameObject.Find("posMadrid");*/

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < _lugares.Length; i++) {

            GameObject a = GameObject.Find(_lugares[i]);
            if (a != null) {
                if (a.GetComponent<Seleccionable>().getSelected() )
                {
                    a.transform.position = sumaAux();
                    for (int j = 0; j < _posiciones.Length; j++)
                    {
                    
                        GameObject b = GameObject.Find(_posiciones[j]);
                        if (b == null) break;

                        if (b.GetComponent<Seleccionable>().getSelected() )
                        {

                            Debug.Log("SEgundo seleccionado");
                            intercambio(a, b);

                        }
                    }
                }
            }
        }
    }


    public Vector3 sumaAux() {

        Vector3 aux;
        aux= Camera.main.transform.position + (Camera.main.transform.forward.normalized * 4);
        aux = aux + posAux;
        return aux;

    }

    //provisional
    public void intercambio(GameObject a, GameObject b) {
        Debug.Log(a.name +" "+ b.name);
        if ("pos" + a.name == b.name)
        {
            a.transform.position = b.transform.position;
            a.transform.position += new Vector3(0, 0, -0.2f);
            a.GetComponent<Seleccionable>().type = 0;
            a.GetComponent<Seleccionable>().ChangeSelect(false);
            Destroy(a.transform.GetChild(0).gameObject);
            Destroy(b);
        }
        else {
            Debug.Log("FALSO");//INSERTAR SONIDO FALLO
        }

    }
}


