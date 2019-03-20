using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DelayStart : MonoBehaviour
{
    public int StartDelay;
    public float MusicDelay;
    public float PlayTime;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine("Delay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Delay()
    {
        for(int i = StartDelay; i >= 0; i--)
        {
            GetComponent<Text>().text = i.ToString();
            yield return new WaitForSecondsRealtime(1f);
        };
        Time.timeScale = PlayTime;
        audio.pitch = PlayTime;
        audio.PlayDelayed(MusicDelay);
        gameObject.SetActive(false);
    }
}
