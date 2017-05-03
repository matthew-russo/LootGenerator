using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using LootGenerator;
using Patterns;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<InventoryItemBaseClass> currentInventory;
    public GameObject[] inventorySlots;

    private string pathName;
    private const string fileName = "inventory.dat";

    public GameObject HoverPopUpUIObject;

    void Start()
    {
        pathName = Application.streamingAssetsPath;
        currentInventory = new List<InventoryItemBaseClass>(24);
        LoadInventory();
        UpdateInventory();

        GameObject[] inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        foreach (GameObject inventorySlot in inventorySlots)
        {
            HoverPopUp HoverPopUpScript = inventorySlot.AddComponent<HoverPopUp>();
            HoverPopUpScript.HoverPopUpUIObject = HoverPopUpUIObject;
        }
        HoverPopUpUIObject.SetActive(false);

    }

    void OnDestroy()
    {
        SaveInventory();
    }

    public void UpdateInventory() {
	    for (int i = 0; i < currentInventory.Count; ++i)
	    {
	        inventorySlots[i].name = currentInventory[i].name;
	        if (inventorySlots[i].GetComponent<InventoryPieceContainer>() != null)
	        {
	            Destroy(inventorySlots[i].GetComponent<InventoryPieceContainer>());
	        }
	        InventoryPieceContainer newInvItem = inventorySlots[i].AddComponent<InventoryPieceContainer>();
            newInvItem.ConvertToContainer(currentInventory[i]);
	    }
	}

    public void SaveInventory()
    {
        string filePath = Path.Combine(pathName, fileName);

        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(fs, currentInventory);
        fs.Close();
    }

    public void LoadInventory()
    {
        string filePath = Path.Combine(pathName, fileName);

        FileStream stream = new FileStream(filePath, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        currentInventory = (List<InventoryItemBaseClass>)bf.Deserialize(stream);
        stream.Close();
    }
}
