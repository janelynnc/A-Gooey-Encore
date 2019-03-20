using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRaycast : MonoBehaviour
{
    public LayerMask layers;
    private GameObject CurrentSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        if(Physics.Raycast(transform.position,transform.forward,out Hit,Mathf.Infinity,layers))
        {
            if(CurrentSelected != null)
            {
                CurrentSelected.SendMessage("HoverExit");
            }
            CurrentSelected = Hit.collider.gameObject;
        }
        else
        {
            if (CurrentSelected != null)
            {
                CurrentSelected.SendMessage("HoverExit");
            }
            CurrentSelected = null;
        }

        if(CurrentSelected != null)
        {
            CurrentSelected.SendMessage("Hover");
        }
    }

    public void Click()
    {
        if(CurrentSelected != null)
            CurrentSelected.SendMessage("Click");
    }
}
