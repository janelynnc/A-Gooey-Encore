using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlob : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
