using System.Collections;
using System.Collections.Generic;
using Generator;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverPopUp : EventTrigger
{
    public const int HOVERPOPUP_WIDTH = 320;
    public const int HOVERPOPUP_HEIGHT = 220;
    public const int INVPIECE_SIZE = 60;

    public GameObject HoverPopUpUIObject;
    public RectTransform rectTransform;
    public FadeInFadeOut fadeScript;

    public Text Name;
    public Text Attack;
    public Text Defense;
    public Text Intelligence;
    public Text Speed;
    public Text Weight;
    public Text Value;
    public Text Effect;
    public Text Type;

    void Start()
    {
        HoverPopUpUIObject = InventoryManager.Instance.HoverPopUpUIObject;

        Name = HoverPopUpUIObject.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Attack = HoverPopUpUIObject.transform.GetChild(0).GetChild(1).GetComponent<Text>();
        Defense = HoverPopUpUIObject.transform.GetChild(0).GetChild(2).GetComponent<Text>();
        Intelligence = HoverPopUpUIObject.transform.GetChild(0).GetChild(3).GetComponent<Text>();
        Effect = HoverPopUpUIObject.transform.GetChild(0).GetChild(4).GetComponent<Text>();
        Speed = HoverPopUpUIObject.transform.GetChild(0).GetChild(5).GetComponent<Text>();
        Weight = HoverPopUpUIObject.transform.GetChild(0).GetChild(6).GetComponent<Text>();
        Value = HoverPopUpUIObject.transform.GetChild(0).GetChild(7).GetComponent<Text>();
        Type = HoverPopUpUIObject.transform.GetChild(0).GetChild(8).GetComponent<Text>();

        rectTransform = HoverPopUpUIObject.GetComponent<RectTransform>();
        fadeScript = HoverPopUpUIObject.GetComponent<FadeInFadeOut>();

    }

    public override void OnPointerEnter(PointerEventData data)
    {
        InventoryPieceContainer invPiece = GetComponent<InventoryPieceContainer>();
        if (invPiece != null && !InventoryManager.Instance.Dragging)
        {
            fadeScript.timeToFadeIn = true;
            fadeScript.timeToFadeOut = false;
            HoverPopUpUIObject.SetActive(true);
            PositionHoverPopUp();
            GiveDataToHoverPopUp(GetComponent<InventoryPieceContainer>());
            StartCoroutine(fadeScript.PopUpFadeIn());
        }
    }

    public override void OnPointerExit(PointerEventData data)
    {
        InventoryPieceContainer invPiece = GetComponent<InventoryPieceContainer>();
        if (invPiece != null && !InventoryManager.Instance.Dragging)
        {
            fadeScript.timeToFadeIn = false;
            fadeScript.timeToFadeOut = true;
            StartCoroutine(fadeScript.PopUpFadeOut());
        }
    }

    public void GiveDataToHoverPopUp(InventoryPieceContainer Item)
    {
        Name.text = "Name: " + Item.name;
        Attack.text = "Attack: " + Item.attack;
        Defense.text = "Defense: " + Item.defense;
        Intelligence.text = "Intelligence: " + Item.intelligence;
        Weight.text = "Weight: " + Item.weight;
        Speed.text = "Speed: " + Item.speed;
        Value.text = "Value: " + Item.value;
        Effect.text = "Effect: " + Item.effect.Replace("Effect","").Replace("null","None");
        Type.text = "Type: " + Item.subType;
    }

    public void PositionHoverPopUp()
    {
        HoverPopUpUIObject.transform.SetParent(transform);
        rectTransform.anchoredPosition = new Vector2(0f, 165f);
    }
}
