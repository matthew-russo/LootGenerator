using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Generator
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
        public string pathToImage;

        public InventoryItemBaseClass()
        {
            
        }

        public InventoryItemBaseClass(InventoryPieceContainer fromPieceContainer)
        {
            name = fromPieceContainer.name;
            rarity = fromPieceContainer.rarity;
            attack = fromPieceContainer.attack;
            defense = fromPieceContainer.defense;
            intelligence = fromPieceContainer.intelligence;
            speed = fromPieceContainer.speed;
            weight = fromPieceContainer.weight;
            value = fromPieceContainer.value;
            effect = fromPieceContainer.effect;
            subType = fromPieceContainer.subType;
            pieceType = fromPieceContainer.pieceType;
            pathToImage = fromPieceContainer.pathToImage;
        }
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
            // THE ORDER MATTERS BECAUSE THE NAME IS CONSTRUCTED IN ORDER.
            //
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
            effect = equipPiece.effect;
            pathToImage = equipPiece.pathToImage;

            pathToImage = pathToImage.Replace("frame", mat.name.ToLower().Trim());

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

            subType = "Completed Item!";    
        }

    }

    [Serializable]
    public class Piece : InventoryItemBaseClass
    {
        public Piece(string n, double r, int a, int d, int i, int s, int w, int v, string e, string st, string pt, string path)
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
            pathToImage = path;
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
            pathToImage = otherPiece.pathToImage;
        }

        public Piece(InventoryPieceContainer fromPieceContainer)
        {
            name = fromPieceContainer.name;
            rarity = fromPieceContainer.rarity;
            attack = fromPieceContainer.attack;
            defense = fromPieceContainer.defense;
            intelligence = fromPieceContainer.intelligence;
            speed = fromPieceContainer.speed;
            weight = fromPieceContainer.weight;
            value = fromPieceContainer.value;
            effect = fromPieceContainer.effect;
            subType = fromPieceContainer.subType;
            pieceType = fromPieceContainer.pieceType;
            pathToImage = fromPieceContainer.pathToImage;
        }
    }
}

