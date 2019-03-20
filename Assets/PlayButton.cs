using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayButton : UIButton
{
    public string SceneToLoad;
    public override void Click()
    {
        base.Click();
        SceneManager.LoadScene(SceneToLoad);
    }
}
