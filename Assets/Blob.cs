using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blob : MonoBehaviour
{
    public GameObject Splat;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Blob")
            Splat.SetActive(true);
    }
}
