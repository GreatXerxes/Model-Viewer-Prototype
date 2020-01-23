using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// required interface when using the OnPointerEnter method. 
{

    public bool overUI;

    public GameObject manager;

    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        overUI = true;
        manager.GetComponent<Manager>().overUI = true;
    }

    //Do this when the cursor exits the rect area of this selectable UI object.
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("The cursor exited the selectable UI element.");
        overUI = false;
        manager.GetComponent<Manager>().overUI = false;
    }
}
