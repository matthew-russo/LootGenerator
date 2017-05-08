using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Generator;
using UnityEngine;
using UnityEngine.UI;

public class Crafting : MonoBehaviour
{
    public void Craft()
    {
        InventoryPieceContainer material =
            InventoryManager.Instance.MaterialSlot.GetComponent<InventoryPieceContainer>();
        InventoryPieceContainer equipment =
            InventoryManager.Instance.EquipmentSlot.GetComponent<InventoryPieceContainer>();
        InventoryPieceContainer title = InventoryManager.Instance.TitleSlot.GetComponent<InventoryPieceContainer>();
        InventoryPieceContainer ornament =
            InventoryManager.Instance.OrnamentSlot.GetComponent<InventoryPieceContainer>();

        // Check if/which slots are null

        // If Material or Equipment are null, cancel and put all pieces back in inventory
        if (material == null || equipment == null)
        {
            Debug.Log("missing either material or equipment");
            ClearCraftingSlots();
            InventoryManager.Instance.ConvertBaseClassToContainer();
            return;
        }

        if (!equipment.subType.Contains(material.pieceType))
        {
            Debug.Log("Equipment is of type: " + equipment.subType + ", and the material is of type: " + material.pieceType);
            ClearCraftingSlots();
            InventoryManager.Instance.ConvertBaseClassToContainer();
            return;
        }

        Piece matPiece = new Piece(material);
        Piece equipPiece = new Piece(equipment);
        InventoryManager.Instance.currentInventory.Remove(material);
        InventoryManager.Instance.currentInventory.Remove(equipment);

        Piece titlePiece = null;
        Piece ornamentPiece = null;
        if (title != null)
        {
            titlePiece = new Piece(title);
            InventoryManager.Instance.currentInventory.Remove(title);

        }
        if (ornament != null)
        {
            ornamentPiece = new Piece(ornament);
            InventoryManager.Instance.currentInventory.Remove(ornament);
        }

        InventoryManager.Instance.UpdateBaseList();

        Item craftedItem = new Item(matPiece,ornamentPiece,titlePiece,equipPiece);

        Regex regex = new Regex(@"([\s][(][_a-zA-Z\s]+[)])");

        Debug.Log(regex.Match("Welcome To (Hello) Yes").ToString());

        craftedItem.name = regex.Replace(craftedItem.name, "");
        craftedItem.pathToImage = regex.Replace(craftedItem.pathToImage, "").Trim();

        InventoryManager.Instance.loadedInventory.Add(craftedItem);

        InventoryManager.Instance.ConvertBaseClassToContainer();



        ClearCraftingSlots();

        // If material && equipment are not null, combine to create new item

        // Item is added to inventory

        // Inventory is updated

    }

    public void ClearCraftingSlots()
    {
        Destroy(InventoryManager.Instance.MaterialSlot.GetComponent<InventoryPieceContainer>());
        Destroy(InventoryManager.Instance.MaterialSlot.GetComponent<Image>());

        Destroy(InventoryManager.Instance.EquipmentSlot.GetComponent<InventoryPieceContainer>());
        Destroy(InventoryManager.Instance.EquipmentSlot.GetComponent<Image>());

        Destroy(InventoryManager.Instance.OrnamentSlot.GetComponent<InventoryPieceContainer>());
        Destroy(InventoryManager.Instance.OrnamentSlot.GetComponent<Image>());

        Destroy(InventoryManager.Instance.TitleSlot.GetComponent<InventoryPieceContainer>());
        Destroy(InventoryManager.Instance.TitleSlot.GetComponent<Image>());
    }

    public void RemoveUsedItems()
    {
        
    }
}
