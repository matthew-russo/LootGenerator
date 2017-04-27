using System.Collections;
using System.Collections.Generic;
using LootGenerator;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public Text Name;
    public Text Attack;
    public Text Defense;
    public Text Intelligence;
    public Text Speed;
    public Text Weight;
    public Text Value;

    public Item currentItem;
    public Piece currentPiece;

    private void Update()
    {
        if (currentItem != null)
        {
            Name.text = "Name : " + currentItem.name;
            Attack.text = "Attack : " + currentItem.attack;
            Defense.text = "Defense : " + currentItem.defense;
            Intelligence.text = "Intelligence : " + currentItem.intelligence;
            Speed.text = "Speed : " + currentItem.speed;
            Weight.text = "Weight : " + currentItem.weight;
            Value.text = "Value : " + currentItem.value;
        }
        if (currentPiece != null)
        {
            Name.text = "Name : " + currentPiece.name;
            Attack.text = "Attack : " + currentPiece.attack;
            Defense.text = "Defense : " + currentPiece.defense;
            Intelligence.text = "Intelligence : " + currentPiece.intelligence;
            Speed.text = "Speed : " + currentPiece.speed;
            Weight.text = "Weight : " + currentPiece.weight;
            Value.text = "Value : " + currentPiece.value;
        }
    }
}
