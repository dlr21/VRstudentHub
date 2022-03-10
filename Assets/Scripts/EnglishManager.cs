using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnglishManager : MonoBehaviour
{

    private string[] preguntas ={"You near a woman recommending a campsite. Why does she recommend it?",
        "You hear two friends talking about global warming. How does the woman feel about it?",
        "You hear a young couple talking about moving to the country. The man objects to the idea because",
        "You hear a part of a radio programme about food. Why should listeners call the programme?",
        "You hear the beginning of a programme about college canteens. What point is being made about them?"
    };

    private string[] respuestas1 = { "It’s close to tourist attractions. ",
        "pessimistic about the future.",
        "he wouldn’t be able to work there. ",
        "to take part in a recipe competition.",
        "The choice of food has improved."
    };
    private string[] respuestas2 = { "It’s in an area of natural beauty. ",
        "surprised at the effects it’s having.",
        "he’d miss the facilities of the city.",
        "to find out about a cookery course.",
        "Students like the food on offer tnere."
    };
    private string[] respuestas3 = { "It has a wide range of facilities.",
        "unconvinced that there’s a problem",
        "he wouldn’t be near to his friends.",
        "to ask questions about cooking.",
        "Teachers complain about the quality of the food."
    };

    private int[] correcta = { 2, 2, 2, 3, 1};

    private GameObject pregunta;
    private GameObject respuesta;
    private GameObject opcionA;
    private GameObject opcionB;
    private GameObject opcionC;

    public int npregunta = 0;


    private void Awake()
    {
        opcionA = GameObject.Find("Opcion1");
        opcionB = GameObject.Find("Opcion2");
        opcionC = GameObject.Find("Opcion3");

        pregunta = GameObject.Find("Pregunta");
        respuesta = GameObject.Find("Respuesta");

    }


    // Start is called before the first frame update
    void Start()
    {
        pregunta.GetComponent<Text>().text = preguntas[npregunta];

        opcionA.GetComponent<TMPro.TextMeshPro>().text = respuestas1[npregunta];
        opcionB.GetComponent<TMPro.TextMeshPro>().text = respuestas2[npregunta];
        opcionC.GetComponent<TMPro.TextMeshPro>().text = respuestas3[npregunta];

        respuesta.GetComponent<Text>().text = "Elige la respuesta correcta.";
    }

    // Update is called once per frame
    void Update()
    {
    }

    //prueba de que funciona
    private void netPregunta() {
        if (Input.GetKeyDown(KeyCode.Space)) {

            Debug.Log("espacioooo");
            preguntaCorrecta();
        }
    }

    public void comprobarCorrecta(int a) {
        GameObject.Find("Cube").GetComponent<AudioEngl>().music.Stop();
        if (correcta[npregunta] == a)
        {
            preguntaCorrecta();
        }
        if (npregunta > correcta.Length) {
            acabado();
        }
    }

    private void acabado()
    {
        opcionA.GetComponent<Seleccionable>().type = 0;
        opcionB.GetComponent<Seleccionable>().type = 0;
        opcionC.GetComponent<Seleccionable>().type = 0;

        respuesta.GetComponent<Text>().text = "Error";
    }

    private void preguntaCorrecta()
    {
        npregunta++;
        if (npregunta < correcta.Length) { 
            pregunta.GetComponent<Text>().text = preguntas[npregunta];

            opcionA.GetComponent<TMPro.TextMeshPro>().text = respuestas1[npregunta];
            opcionB.GetComponent<TMPro.TextMeshPro>().text = respuestas2[npregunta];
            opcionC.GetComponent<TMPro.TextMeshPro>().text = respuestas3[npregunta];

            respuesta.GetComponent<Text>().text = "Question "+(npregunta+1);
        }
    }

    public void audioPregunta()
    {
        if (npregunta > correcta.Length)
        {
            Debug.Log("No mas preguntas");
        }else {
            Debug.Log("Audio" + npregunta);
            GameObject.Find("Cube").GetComponent<AudioEngl>().PlayQuestion(npregunta);
        }
    }


}