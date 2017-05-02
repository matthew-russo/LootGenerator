using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private Vector3 _screenPoint;
    private Vector3 _offset;


    // If a player clicks on a food item, set proper positions to move item, switch a bool, and turn its collider to a trigger so it doesn't knock everything around
    //
    void OnMouseDown()
    {
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        _offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _screenPoint.z));
    }

    // Updates a held food item's position with the mouse position
    //
    void OnMouseDrag()
    {
        _screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (Vector3.Distance(transform.position, _screenPoint) > .5f)
        {
            transform.position = Vector3.Lerp(transform.position, _screenPoint, .6f);
        }
    }
}
