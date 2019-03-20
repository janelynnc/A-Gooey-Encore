using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControlsButton : UIButton
{
    public GameObject Options;
    public GameObject Controls;
    public bool Show;

    public override void Click()
    {
        base.Click();

        if (Show)
        {
            Controls.SetActive(Show);
            Options.SetActive(!Show);
        }
        else
        {
            Options.SetActive(!Show);
            Controls.SetActive(Show);
        }
        
    }
}
