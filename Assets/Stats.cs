using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public static Stats instance;
    public float Rep;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
