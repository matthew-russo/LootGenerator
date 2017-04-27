using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverPopUp : MonoBehaviour
{
    public GameObject selectedObject;
	
	void Update () {
	    if (EventSystem.current.currentSelectedGameObject)
	    {
	        selectedObject = EventSystem.current.currentSelectedGameObject;
	    }
	    else
	    {
	        selectedObject = null;
	    }

        Debug.Log(selectedObject);
	}
}
