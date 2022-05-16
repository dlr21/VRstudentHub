using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeologiaManager : MonoBehaviour
{

    private string[] opcionCorrecta = { "CamaraMagmatica", "Chimenea", "Cono","Corteza", "Manto" };
    private string[] descripciones = { "Es la zona donde se almacena el magma (roca fundida) proveniente del manto," +
            " el cual posteriormente es expulsado a la superficie en forma de erupción volcánica.",
        "Es el conducto por donde asciende el magma hasta llegar al cráter." +
            " Durante su ascenso el magma puede arrancar rocas de las paredes, para luego ser expulsados a la superficie.",
        "La formación de origen volcánica situada en la boca del volcán desde donde emana el magma y entra en contacto con la hidrosfera o la atmósfera. ",
        "Es una capa rígida de poco espesor cuya parte superior, la litosfera, se encuentra dividida en placas tectónicas. " +
            "En las zonas de contacto de estas placas ocurren las erupciones volcánicas, terremotos y otros fenómenos geológicos.",
        "Es una capa interna de los planetas terrestres, " +
            "como la que se encuentran entre el núcleo, la capa más interna, y la corteza, la más externa." };

    private GameObject descripcion;
    private GameObject nombre;

    public int npregunta = 0;

    // Start is called before the first frame update

    private void Awake()
    {
        descripcion = GameObject.Find("Ejercicio");
        nombre = GameObject.Find("Pregunta");
    }

    void Start()
    {
        descripcion.GetComponent<Text>().text = descripciones[npregunta];
        nombre.GetComponent<Text>().text = "";
    }



    void siguientePregunta()
    {
        Debug.Log("correcta");
        npregunta++;

        descripcion.GetComponent<Text>().text = descripciones[npregunta];
    }

    public bool comprobarOpcion(string s) {
        if (s == opcionCorrecta[npregunta]) {

            siguientePregunta();

            if (npregunta > opcionCorrecta.Length)
            {
                fin();
            }
            GameObject.Find("Cube").GetComponent<Audio>().playCorrect();

            return true;
        }
        GameObject.Find("Cube").GetComponent<Audio>().playError();
        return false;
    }

    void fin() {
        descripcion.GetComponent<Text>().text = "Acabaste con el ejercicio";
        nombre.GetComponent<Text>().text = "Bien hecho";

        GameObject.Find("Cube").GetComponent<Audio>().playFin();
    }
}
