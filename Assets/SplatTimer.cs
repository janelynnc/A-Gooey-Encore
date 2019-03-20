using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplatTimer : MonoBehaviour
{
    public float Timer;
    public void OnEnable()
    {
        StartCoroutine(Dissappear());
    }

    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(Timer);
        gameObject.SetActive(false);
    }
}
