using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeografiaManager : MonoBehaviour
{

    private GameObject pregunta;
    private GameObject cuantos;
    private GameObject res;

    GameObject[] _comunidad= new GameObject[19];
    GameObject[] _posComunidad= new GameObject[19];

    private int correctos = 0;
    private int acolocar = 17; //19 con ceuta y melilla a hacer 

    private string [] _lugares= {"Madrid", "Catalunya", "cValenciana","Andalucia",
        "Aragon","Asturias","IslasBaleares","IslasCanarias",
        "Cantabria","cLaMancha","cYleon","Ceuta","Extremadura","Galicia",
        "LaRioja","Melilla","Murcia", "Navarra","PaisVasco"};

    private string[] _posiciones ={"posMadrid", "posCatalunya", "poscValenciana","posAndalucia",
        "posAragon","posAsturias","posIslasBaleares","posIslasCanarias",
        "posCantabria","poscLaMancha","poscYleon","posCeuta","posExtremadura","posGalicia",
        "posLaRioja","posMelilla","posMurcia", "posNavarra","posPaisVasco"};

    Vector3 posAux=new Vector3(0,-1.5f,0);
    Vector3 sizeAux = new Vector3(0.5f, 0.25f, 0.5f);

    // Start is called before the first frame update

    private void Awake()
    {
        res = GameObject.Find("Respuesta");
        cuantos = GameObject.Find("Cuantos");
        pregunta = GameObject.Find("Pregunta");
        
    }

    void Start()
    {

        cuantos.GetComponent<Text>().text = correctos + "/" + acolocar;

        for (int i = 0; i < _lugares.Length; i++) {
             if(GameObject.Find(_lugares[i]) != null)
                 _comunidad[i] = GameObject.Find(_lugares[i]);
         }

        for (int j = 0; j < _posiciones.Length; j++)
        {
            if (GameObject.Find(_posiciones[j]) != null)
                _posComunidad[j] = GameObject.Find(_posiciones[j]);
        }

        changePosicionSelect(false);


    }

    // Update is called once per frame
    void Update()
    {

        comprobarCorrectos();

        for (int i = 0; i < _lugares.Length; i++) {

            GameObject a = GameObject.Find(_lugares[i]);
            if (a != null) {
                if (a.GetComponent<Seleccionable>().getSelected() )
                {
                    a.transform.position = sumaAux();
                    for (int j = 0; j < _posiciones.Length; j++)
                    {
                    
                        GameObject b = GameObject.Find(_posiciones[j]);
                        if (b != null)
                        {

                            if (b.GetComponent<Seleccionable>().getSelected())
                            {

                                Debug.Log("SEgundo seleccionado");
                                intercambio(a, b);


                            }
                        }
                    }
                }
            }
        }
        Debug.Log(correctos);
        changePosicionSelect(false);
    }

    public void comprobarCorrectos() {

        if (correctos == acolocar)
        {
            Debug.Log("FIN ");//INSERTAR SONIDO FINAL
            //sonido bien y cambiar texto
            res.GetComponent<Text>().text = "Has superado el ejercicio con éxito";

        }
    }

    public void changePosicionSelect(bool a) {
        for (int j = 0; j < _posiciones.Length; j++)
        {
            GameObject b = GameObject.Find(_posiciones[j]);
            if (b != null) {
                b.GetComponent<Seleccionable>().ChangeSelect(a);
            }
            
        }
    }

    public void changeNombreSelect(bool a)
    {
        for (int j = 0; j < _lugares.Length; j++)
        {
            GameObject b = GameObject.Find(_lugares[j]);
            if (b != null)
            {
                if (b.GetComponent<Seleccionable>().getSelected() == true) {
                    b.transform.position = b.GetComponent<Seleccionable>().startPosition;
                }
                b.GetComponent<Seleccionable>().ChangeSelect(a);
            }
        }
    }

    public Vector3 sumaAux() {

        Vector3 aux;
        aux= Camera.main.transform.position + (Camera.main.transform.forward.normalized * 4);
        aux = aux + posAux;
        return aux;

    }

    public void intercambioCorrecto() {
 
        correctos++;
        Debug.Log("Correcto " + correctos);//INSERTAR SONIDO FALLO
        cuantos.GetComponent<Text>().text = correctos + "/" + acolocar;
        res.GetComponent<Text>().text = "Posición correcta";
    }

    //provisional
    public void intercambio(GameObject a, GameObject b) {
        Debug.Log(a.name +" "+ b.name);
        if ("pos" + a.name == b.name)
        {
            if (a.name == "IslasCanarias")
            {
                a.transform.localPosition = new Vector3(-0.5f, -2.7f, -0.7f);
            }
            else if(a.name == "IslasBaleares")
            {
                a.transform.position = new Vector3(8.5f, -1.5f, -0.7f);
            }
            else
            {
                a.transform.position = new Vector3(b.transform.position.x, b.transform.position.y, 14);
            }
            
            a.GetComponent<Seleccionable>().type = 0;
            a.GetComponent<Seleccionable>().ChangeSelect(false);
            Destroy(a.transform.GetChild(0).gameObject);
            Destroy(b.transform.GetChild(0).gameObject);
            Debug.Log("Antes intercambio");
            intercambioCorrecto();
            Debug.Log("Tras intercambio");

        }
        else {
            Debug.Log("FALSO");//INSERTAR SONIDO FALLO
            res.GetComponent<Text>().text = "Posición incorrecta";

        }

    }
}


