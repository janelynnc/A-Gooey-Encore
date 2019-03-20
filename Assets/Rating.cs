using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rating : MonoBehaviour
{
    private Image Stars;
    public Stats Stat;
    public float Rate;
    // Start is called before the first frame update
    void Start()
    {
        Stat = GameObject.FindGameObjectWithTag("Stats").GetComponent<Stats>();
        Stars = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Stars.fillAmount < Stat.Rep)
        {
            Stars.fillAmount += Rate * Time.deltaTime;
        }
    }

    

}
