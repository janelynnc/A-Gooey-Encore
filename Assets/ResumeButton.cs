using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : UIButton
{
    public Pause pause;
    public override void Click()
    {
        base.Click();
        pause.Toggle();
    }
}
