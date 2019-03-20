using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : UIButton
{
    public override void Click()
    {
        base.Click();
        Application.Quit();
    }
}
