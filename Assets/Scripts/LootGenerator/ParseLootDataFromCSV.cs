using System;
using System.Collections;
using System.Collections.Generic;
using Generator;
using UnityEngine;

public class ParseLootDataFromCSV : MonoBehaviour {
    // ####
    //      Name,Rarity,Attack,Defense,Intelligence,Speed,Weight,Value,Special/Effect,Type,SubType,PieceType,ListToAddTo
    // ####

    private readonly string fileName = "GeneratorData.csv";
    private string _lootDataFilePath;

    private string[] content;

    void Awake () {
		LoadCSVFile();
        IterateThroughContentAndInstantiateObjects();
	}

    void LoadCSVFile()
    {
        //TextAsset textAsset = Resources.Load("GeneratorData.csv") as TextAsset;
        //string theText = textAsset.text;
        //content = theText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        _lootDataFilePath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        content = System.IO.File.ReadAllLines(_lootDataFilePath);
    }

    void IterateThroughContentAndInstantiateObjects()
    {
        for (int i = 1; i < content.Length; ++i)
        {
            string[] splitLine = content[i].Split(',');
            Piece newPiece = new Piece(splitLine[0], Convert.ToDouble(splitLine[1]), Convert.ToInt32(splitLine[2]), Convert.ToInt32(splitLine[3]), Convert.ToInt32(splitLine[4]), Convert.ToInt32(splitLine[5]), Convert.ToInt32(splitLine[6]), Convert.ToInt32(splitLine[7]), splitLine[8], splitLine[9], splitLine[10], splitLine[11]);
            LootGenerator.Instance.AllPieces.Add(newPiece);
            if (splitLine[9] == "Ornament")
            {
                LootGenerator.Instance.Ornaments.Add(newPiece);
            }
            else if (splitLine[9] == "Title")
            {
                LootGenerator.Instance.Titles.Add(newPiece);
            }
            else if (splitLine[9] == "Material")
            {
                LootGenerator.Instance.AllMaterials.Add(newPiece);
                if (splitLine[10] == "Metal")
                {
                    LootGenerator.Instance.Materials_Metal.Add(newPiece);
                }
                else
                {
                    LootGenerator.Instance.Materials_Wood.Add(newPiece);
                }
            }
            else if (splitLine[9].Contains("Weapon"))
            {
                LootGenerator.Instance.AllEquipment.Add(newPiece);
                LootGenerator.Instance.Weapons.Add(newPiece);
            }
            else if (splitLine[9].Contains("Armor"))
            {
                LootGenerator.Instance.AllEquipment.Add(newPiece);
                LootGenerator.Instance.Armor.Add(newPiece);
            }
        }
    }
}
