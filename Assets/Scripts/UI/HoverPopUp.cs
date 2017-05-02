using System.Collections;
using System.Collections.Generic;
using LootGenerator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverPopUp : MonoBehaviour
{
    public GameObject HoverPopUpUIObject;
    public GameObject selectedObject;

    public Text name;
    public Text attack;
    public Text defense;
    public Text intelligence;
    public Text speed;
    public Text weight;
    public Text value;
    public Text effect;
    public Text type;

    void Start()
    {
        HoverPopUpUIObject.SetActive(false);
    }

	void Update ()
	{
	    //EventSystem.current.IsPointerOverGameObject();

	    Ray cameraToGame = new Ray(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
	    RaycastHit rayHit;

	    if(Physics.Raycast(cameraToGame, out rayHit))
	    {
	        InventoryPieceContainer invPiece = GetComponent<InventoryPieceContainer>();
	        if (rayHit.transform.gameObject.GetComponent<InventoryPieceContainer>())
	        {
	            HoverPopUpUIObject.SetActive(true);
                
	        }
	    }
        else if (HoverPopUpUIObject.activeInHierarchy)
	    {
	        HoverPopUpUIObject.SetActive(false);
	    }

	    // 1. IS MOUSE OVER OBJECT?
	    // 1a. TURN POP UP ON
	    // 1b. MOVE POP UP TO OBJECTS LOCATION + Y OFFSET
	    // 1c. UPDATE UI TEXT WITH HOVERED OBJECTS STATS

	    // 2. ELSE TURN POP UP OFF
	}
}
