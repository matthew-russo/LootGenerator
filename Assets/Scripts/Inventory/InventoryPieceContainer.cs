using System;
using System.Collections;
using System.Collections.Generic;
using LootGenerator;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPieceContainer : MonoBehaviour
{
    // Stats
    public string name;
    public double rarity;
    public int attack;
    public int defense;
    public int intelligence;
    public int speed;
    public int weight;
    public int value;
    public string effect;
    public string subType;
    public string pieceType;
    public string pathToImage;

    public bool showImage = false;
    public Image image;
    public int index;

    public void ConvertToContainer(InventoryItemBaseClass itemToConvert)
    {
        name = itemToConvert.name;
        rarity = itemToConvert.rarity;
        attack = itemToConvert.attack;
        defense = itemToConvert.defense;
        intelligence = itemToConvert.intelligence;
        speed = itemToConvert.speed;
        weight = itemToConvert.weight;
        value = itemToConvert.value;
        effect = itemToConvert.effect;
        subType = itemToConvert.subType;
        pieceType = itemToConvert.pieceType;
        pathToImage = itemToConvert.pathToImage;

        image = GetComponent<Image>();
    }

    public void CopyItemStats(InventoryPieceContainer itemToCopy)
    {
        name = itemToCopy.name;
        rarity = itemToCopy.rarity;
        attack = itemToCopy.attack;
        defense = itemToCopy.defense;
        intelligence = itemToCopy.intelligence;
        speed = itemToCopy.speed;
        weight = itemToCopy.weight;
        value = itemToCopy.value;
        effect = itemToCopy.effect;
        subType = itemToCopy.subType;
        pieceType = itemToCopy.pieceType;
        pathToImage = itemToCopy.pathToImage;

        image = GetComponent<Image>();
    }

    public void Update()
    {
        if (showImage)
        {
            image.enabled = true;
            Sprite sprite = new Sprite();
            sprite = Resources.Load(pathToImage, typeof(Sprite)) as Sprite;
            image.sprite = sprite;
            image.preserveAspect = true;
            image.color = new Color(255,255,255,255);
            showImage = false;
        }
    }
}
