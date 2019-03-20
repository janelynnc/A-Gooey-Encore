using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public AudioSource Music;
    private bool Paused = false;
    public GameObject PauseMenu;
    public GameObject Options;
    public GameObject Controls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle()
    {
        Paused = !Paused;
        PauseMenu.SetActive(Paused);
        if (Paused)
        {
            Time.timeScale = 0;
            Options.SetActive(true);
            Controls.SetActive(false);
            Music.Pause();
        }
        else
        {
            Time.timeScale = 1;
            Options.SetActive(true);
            Controls.SetActive(false);
            Music.UnPause();
        }
    }
}
