using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : UIButton
{
    public SlideList Slides;
    public override void Click()
    {
        base.Click();
        Slides.NextSlide();
    }
}
