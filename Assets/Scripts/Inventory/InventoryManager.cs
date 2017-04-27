using System.Collections;
using System.Collections.Generic;
using LootGenerator;
using Patterns;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public List<InventoryItemBaseClass> currentInventory;
    public GameObject[] inventorySlots;

    void Start()
    {
        currentInventory = new List<InventoryItemBaseClass>(24);
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
}
