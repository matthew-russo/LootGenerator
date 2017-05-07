﻿using System;
using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace LootGenerator
{
    public class LootGenerator : Singleton<LootGenerator>
    {
        public StatsUI StatsText;
        public Image shopImage;

        public List<Piece> AllPieces = new List<Piece>();
        public List<Piece> Ornaments = new List<Piece>();
        public List<Piece> Titles = new List<Piece>();
        public List<Piece> Weapons = new List<Piece>();
        public List<Piece> Armor = new List<Piece>();
        public List<Piece> Materials_Wood = new List<Piece>();
        public List<Piece> Materials_Metal = new List<Piece>();

        public List<string> resources = new List<string>() { "Logs","Copper","Tin","OakLogs","Iron","Coal","WillowLogs","Concrete","Bricks","Steel","YewLogs","Gold","ElderLogs","Titanium","Diamond","Meteorite","Honor","Happiness","Culture","Science",};

        public void Generate()
        {
            float rng = Random.value;
            if (rng < .55)
            {
                // 55% chance to get a resource
                PickResource();
            }
            else if (rng < .95)
            {
                // 25% chance to get a piece
                Piece randomPiece = PickPiece();

                // SHOW PIECE STATS AND STUFF
                StatsText.currentItem = null;
                StatsText.currentPiece = randomPiece;
            }
            else
            {
                // 10% chance to get a whole item
                Item randomItem = CreateItem();

                StatsText.currentPiece = null;
                StatsText.currentItem = randomItem;
            }
        }

        void PickResource()
        {
            Debug.Log("Resource");
            float rng = Random.value;
            GlobalFuncs.GeometricShuffle(resources, rng);
            if (resources[0] == "Logs") { ResourceContainer.Instance.Logs++; }
            else if (resources[0] == "Copper") { ResourceContainer.Instance.Copper++; }
            else if (resources[0] == "Tin") { ResourceContainer.Instance.Tin++; }
            else if (resources[0] == "OakLogs") { ResourceContainer.Instance.OakLogs++; }
            else if (resources[0] == "Iron") { ResourceContainer.Instance.Iron++; }
            else if (resources[0] == "Coal") { ResourceContainer.Instance.Coal++; }
            else if (resources[0] == "WillowLogs") { ResourceContainer.Instance.WillowLogs++; }
            else if (resources[0] == "Concrete") { ResourceContainer.Instance.Concrete++; }
            else if (resources[0] == "Bricks") { ResourceContainer.Instance.Bricks++; }
            else if (resources[0] == "YewLogs") { ResourceContainer.Instance.YewLogs++; }
            else if (resources[0] == "Gold") { ResourceContainer.Instance.Gold++; }
            else if (resources[0] == "ElderLogs") { ResourceContainer.Instance.ElderLogs++; }
            else if (resources[0] == "Titanium") { ResourceContainer.Instance.Titanium++; }
            else if (resources[0] == "Diamond") { ResourceContainer.Instance.Diamond++; }
            else if (resources[0] == "Meteorite") { ResourceContainer.Instance.Meteorite++; }
            else if (resources[0] == "Honor") { ResourceContainer.Instance.Honor++; }
            else if (resources[0] == "Happiness") { ResourceContainer.Instance.Happiness++; }
            else if (resources[0] == "Culture") { ResourceContainer.Instance.Culture++; }
            else if (resources[0] == "Science") { ResourceContainer.Instance.Science++; }         
            Debug.Log(resources[0]);
        }

        Piece PickPiece()
        {
            Piece randomPiece = new Piece(WeightedShuffle(AllPieces) ?? AllPieces[0]);
            randomPiece.name = randomPiece.name + " (" + randomPiece.subType + " Piece)";

            if (InventoryManager.Instance.currentInventory.Count < 24)
            {
                InventoryManager.Instance.loadedInventory.Add(randomPiece);
                InventoryManager.Instance.ConvertBaseClassToContainer();
            }
            else
            {
                // LOGIC FOR BREAKING DOWN OR SELLING ITEM
            }
            ShowImage(randomPiece);
            return randomPiece;
        }

        Item CreateItem()
        {
            // PICK EQUIPMENT PIECE
            Piece equipmentPiece = Random.value < .4 ? GlobalFuncs.randElem(Weapons) : GlobalFuncs.randElem(Armor);

            // PICK MATERIAL
            Piece material;
            if (equipmentPiece.subType == "Weapon_Metal" || equipmentPiece.subType == "Armor_Metal")
            {
                material = WeightedShuffle(Materials_Metal) ?? Materials_Metal[0];
            }
            else if (equipmentPiece.subType == "Weapon_Wood")
            {
                material = WeightedShuffle(Materials_Wood) ?? Materials_Wood[0];
            }
            else
            {
                material = Materials_Metal[0];
            }

            // PICK ORNAMENT
            Piece ornament = WeightedShuffle(Ornaments);

            // PICK TITLE
            Piece title = WeightedShuffle(Titles);

            Item newItem = new Item(material, ornament, title, equipmentPiece);

            if (InventoryManager.Instance.currentInventory.Count < 24)
            {
                InventoryManager.Instance.loadedInventory.Add(newItem);
                InventoryManager.Instance.ConvertBaseClassToContainer();
            }
            else
            {
                // LOGIC FOR BREAKING DOWN OR SELLING ITEM
            }

            ShowImage(newItem);
            return newItem;
        }

        Piece WeightedShuffle(List<Piece> ListToShuffle)
        {
            List<Piece> tempList = new List<Piece>(ListToShuffle);
            for (int i = 0; i < tempList.Count; ++i)
            {
                tempList[i].rarity *= Random.Range(.9f,1.1f);
            }

            tempList.Sort(ComparePieceRarities);
        
            double rng = Random.value;

            foreach (Piece item in tempList)
            {
                if (rng > item.rarity)
                {
                    return item;
                }
            }
            return null;
        }

        public int ComparePieceRarities(Piece s1, Piece s2)
        {
            if (s1.rarity < s2.rarity)
            {
                return 1;
            }
            else if (s1.rarity > s2.rarity)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public void ShowImage(InventoryItemBaseClass thing)
        {
            shopImage.enabled = true;
            shopImage.preserveAspect = true;
            Sprite sprite = new Sprite();
            sprite = Resources.Load(thing.pathToImage, typeof(Sprite)) as Sprite;
            shopImage.sprite = sprite;
            shopImage.color = new Color(255, 255, 255, 255);
        }
    }
}
