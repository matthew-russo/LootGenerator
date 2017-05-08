using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Generator;
using Patterns;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<InventoryPieceContainer> currentInventory;
    public List<InventoryItemBaseClass> loadedInventory;
    public GameObject[] inventorySlots;

    private string pathName;
    private const string fileName = "inventory.dat";

    public GameObject HoverPopUpUIObject;

    public bool Dragging;

    public GameObject EquipmentSlot;
    public GameObject MaterialSlot;
    public GameObject OrnamentSlot;
    public GameObject TitleSlot;

    void Start()
    {
        pathName = Application.streamingAssetsPath;
        currentInventory = new List<InventoryPieceContainer>(24);
        loadedInventory = new List<InventoryItemBaseClass>(24);
        SaveInventory();
        LoadInventory();

        GameObject[] inventorySlots = GameObject.FindGameObjectsWithTag("InventorySlot");
        foreach (GameObject inventorySlot in inventorySlots)
        {
            HoverPopUp HoverPopUpScript = inventorySlot.AddComponent<HoverPopUp>();
            HoverPopUpScript.HoverPopUpUIObject = HoverPopUpUIObject;
        }
        HoverPopUpUIObject.SetActive(false);

        EquipmentSlot = GameObject.Find("Equipment Slot").transform.GetChild(0).gameObject;
        MaterialSlot = GameObject.Find("Material Slot").transform.GetChild(0).gameObject;
        OrnamentSlot = GameObject.Find("Ornament Slot").transform.GetChild(0).gameObject;
        TitleSlot = GameObject.Find("Title Slot").transform.GetChild(0).gameObject;
    }

    void OnDestroy()
    {
        SaveInventory();
    }

    public void ConvertBaseClassToContainer()
    {
        ClearInventory();
        for (int i = 0; i < loadedInventory.Count; ++i)
        {
            InventoryPieceContainer newInvItem = inventorySlots[i].AddComponent<InventoryPieceContainer>();
            newInvItem.ConvertToContainer(loadedInventory[i]);
            currentInventory.Add(newInvItem);
            if (newInvItem.subType != "Completed Item!")
            {
                inventorySlots[i].AddComponent<DraggableObject>();
            }
            newInvItem.showImage = true;
        }
    }

    public void UpdateBaseList()
    {
        loadedInventory.Clear();
        for (int i = 0; i < currentInventory.Count; ++i)
        {
            loadedInventory.Add(new InventoryItemBaseClass(currentInventory[i]));
        }
    }

    public void SaveInventory()
    {
        string filePath = Path.Combine(pathName, fileName);

        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryFormatter bf = new BinaryFormatter();
        ConvertInventory();
        bf.Serialize(fs, loadedInventory);
        fs.Close();
    }

    public void LoadInventory()
    {
        string filePath = Path.Combine(pathName, fileName);

        FileStream stream = new FileStream(filePath, FileMode.Open);
        BinaryFormatter bf = new BinaryFormatter();
        loadedInventory = (List<InventoryItemBaseClass>)bf.Deserialize(stream);
        stream.Close();

        for (int i = 0; i < loadedInventory.Count; ++i)
        {
            currentInventory[i].ConvertToContainer(loadedInventory[i]);
        }
    }

    public void ConvertInventory()
    {
        for (int i = 0; i < currentInventory.Count; ++i)
        {
            loadedInventory[i] = new InventoryItemBaseClass(currentInventory[i]);
        }
    }

    public void ClearInventory()
    {
        currentInventory.Clear();
        for (int i = 0; i < inventorySlots.Length; ++i)
        {
            Destroy(inventorySlots[i].GetComponent<InventoryPieceContainer>());
            inventorySlots[i].GetComponent<Image>().enabled = false;
            Destroy(inventorySlots[i].GetComponent<DraggableObject>());
        }
    }
}
