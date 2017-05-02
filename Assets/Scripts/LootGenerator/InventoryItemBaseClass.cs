using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LootGenerator
{
    [Serializable]
    public class InventoryItemBaseClass
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
    }

    [Serializable]
    public class Item : InventoryItemBaseClass
    {
        public Piece material;
        public Piece ornament;
        public Piece title;
        public Piece equipmentPiece;

        public Item(Piece mat, Piece orn, Piece t, Piece equipPiece)
        {
            if (t != null)
            {
                title = t;
                name += title.name + " ";
                attack += title.attack;
                defense += title.defense;
                intelligence += title.intelligence;
                speed += title.speed;
                weight += title.weight;
                value += title.value;
            }
            if (mat != null)
            {
                material = mat;
                name += material.name + " ";
                attack += material.attack;
                defense += material.defense;
                intelligence += material.intelligence;
                speed += material.speed;
                weight += material.weight;
                value += material.value;
            }

            equipmentPiece = equipPiece;
            name += equipPiece.name + " ";
            attack += equipPiece.attack;
            defense += equipPiece.defense;
            intelligence += equipPiece.intelligence;
            speed += equipPiece.speed;
            weight += equipPiece.weight;
            value += equipPiece.value;

            if (orn != null)
            {
                ornament = orn;
                name += ornament.name;
                attack += ornament.attack;
                defense += ornament.defense;
                intelligence += ornament.intelligence;
                speed += ornament.speed;
                weight += ornament.weight;
                value += ornament.value;
                effect = ornament.effect;
            }
        }
    }

    [Serializable]
    public class Piece : InventoryItemBaseClass
    {
        public Piece(string n, double r, int a, int d, int i, int s, int w, int v, string e, string st, string pt)
        {
            name = n;
            rarity = r;
            attack = a;
            defense = d;
            intelligence = i;
            speed = s;
            weight = w;
            value = v;
            effect = e;
            subType = st;
            pieceType = pt;
        }

        public Piece(Piece otherPiece)
        {
            name = otherPiece.name;
            rarity = otherPiece.rarity;
            attack = otherPiece.attack;
            defense = otherPiece.defense;
            intelligence = otherPiece.intelligence;
            speed = otherPiece.speed;
            weight = otherPiece.weight;
            value = otherPiece.value;
            effect = otherPiece.effect;
            subType = otherPiece.subType;
            pieceType = otherPiece.pieceType;
        }
    }
}

