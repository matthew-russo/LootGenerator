using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : EventTrigger
{
    private Vector3 _screenPoint;
    private Vector3 _originPosition;
    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public override void OnBeginDrag(PointerEventData data)
    {
        _originPosition = _rectTransform.transform.position;
        InventoryManager.Instance.Dragging = true;
    }

    public override void OnDrag(PointerEventData data)
    {
        _screenPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector3.Distance(transform.position, _screenPoint) > .5f)
        {
            _rectTransform.position = Vector3.Lerp(_rectTransform.position, new Vector3(_screenPoint.x, _screenPoint.y, _rectTransform.position.z), .6f);
        }
    }

    public override void OnPointerUp(PointerEventData data)
    {
        InventoryManager.Instance.Dragging = false;

        InventoryPieceContainer invPieceScript = GetComponent<InventoryPieceContainer>();
        switch (invPieceScript.subType)
        {

            case "Material":
                if (InventoryManager.Instance.MaterialSlot.GetComponent<InventoryPieceContainer>() != null)
                {
                    StartCoroutine(LerpToPosition(transform.parent.gameObject, false));
                    break;
                }
                StartCoroutine(
                    Vector3.Distance(_rectTransform.position, InventoryManager.Instance.MaterialSlot.transform.position) < 1f
                        ? LerpToPosition(InventoryManager.Instance.MaterialSlot, true)
                        : LerpToPosition(transform.parent.gameObject, false));
                break;

            case "Ornament":
                if (InventoryManager.Instance.OrnamentSlot.GetComponent<InventoryPieceContainer>() != null)
                {
                    StartCoroutine(LerpToPosition(transform.parent.gameObject, false));
                    break;
                }
                StartCoroutine(
                    Vector3.Distance(_rectTransform.position, InventoryManager.Instance.OrnamentSlot.transform.position) < 1f
                        ? LerpToPosition(InventoryManager.Instance.OrnamentSlot, true)
                        : LerpToPosition(transform.parent.gameObject, false));
                break;

            case "Title":
                if (InventoryManager.Instance.TitleSlot.GetComponent<InventoryPieceContainer>() != null)
                {
                    StartCoroutine(LerpToPosition(transform.parent.gameObject, false));
                    break;
                }
                StartCoroutine(Vector3.Distance(_rectTransform.position, InventoryManager.Instance.TitleSlot.transform.position) < 1f
                        ? LerpToPosition(InventoryManager.Instance.TitleSlot, true)
                        : LerpToPosition(transform.parent.gameObject, false));
                break;

            default:
                if (InventoryManager.Instance.EquipmentSlot.GetComponent<InventoryPieceContainer>() != null)
                {
                    StartCoroutine(LerpToPosition(transform.parent.gameObject, false));
                    break;
                }
                StartCoroutine(
                    Vector3.Distance(_rectTransform.position, InventoryManager.Instance.EquipmentSlot.transform.position) < 1f
                        ? LerpToPosition(InventoryManager.Instance.EquipmentSlot, true)
                        : LerpToPosition(transform.parent.gameObject, false));
                break;
        }

        // ELSE SNAP TO ORIGINAL POSITION
        //StartCoroutine(LerpToPosition(_originPosition));
    }

    private IEnumerator LerpToPosition(GameObject newParent, bool transfer)
    {
        Vector3 startPos = _rectTransform.position;

        //transform.SetParent(newParent.transform);

        while (Vector3.Distance(_rectTransform.position, newParent.transform.position) > .01f)
        {
            _rectTransform.position = Vector3.Lerp(_rectTransform.position, newParent.transform.position, .1f);
            yield return new WaitForEndOfFrame();
        }

        if (transfer)
        {
            InventoryPieceContainer invPiece = newParent.AddComponent<InventoryPieceContainer>();
            invPiece.CopyItemStats(GetComponent<InventoryPieceContainer>());
            Image image = newParent.AddComponent<Image>();
            image.preserveAspect = true;
            image.sprite = GetComponent<Image>().sprite;

            Destroy(GetComponent<InventoryPieceContainer>());
            InventoryManager.Instance.currentInventory.Remove(GetComponent<InventoryPieceContainer>());
            GetComponent<Image>().enabled = false;
        }
        
        _rectTransform.localPosition = new Vector3(0,0,0);
    }
}
