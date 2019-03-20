using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIButton : MonoBehaviour
{
    private Image Button;
    public Color HoverColor;
    public Color DefaultColor;
    public Color ClickColor;
    public void Awake()
    {
        Button = gameObject.GetComponent<Image>();
    }

    public void Hover()
    {
        Button.color = HoverColor;
    }

    public void HoverExit()
    {
        Button.color = DefaultColor;
    }

    public virtual void Click()
    {
        Button.color = ClickColor;
    }
}
