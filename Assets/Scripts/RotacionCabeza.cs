using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCabeza : MonoBehaviour
{
    // Start is called before the first frame update


    void Start()
    {
        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {



        //Obtiene datos del giroscopio
        Quaternion att = Input.gyro.attitude;
        //Reoriente los datos del giroscoopio para la pantalla
        att = Quaternion.Euler(90f, 0f, 0f) * new Quaternion(att.x, att.y, -att.z, -att.w);
        //Asigna la nueva rotacion a la camara
        transform.rotation = att;
    }
}
