using System.Collections;
using System.Collections.Generic;
using LootGenerator;
using UnityEngine;

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
    }
}
