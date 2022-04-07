using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject instance;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


}
