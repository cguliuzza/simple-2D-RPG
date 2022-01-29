using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreen : MonoBehaviour
{
    public bool isOpen = false;
    public List<InventoryIcon> inventoryIcons = new List<InventoryIcon>();

    private int selectedIndex = 0;
    private bool isProcessing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProcessInput(Vector2 moveInput)
    {
        if (!isOpen || isProcessing) return;

        StartCoroutine(ChangeSelection(moveInput));
    }

    private IEnumerator ChangeSelection(Vector2 moveInput)
    {

        isProcessing = true;

        // Change selection only if there's an applicable next item to select
        if (selectedIndex+1 < inventoryIcons.Count && inventoryIcons[selectedIndex+1].inventoryItem != null)
        {
            if (inventoryIcons[selectedIndex].inventoryItem != null && inventoryIcons[selectedIndex].isSelected)
            {
                inventoryIcons[selectedIndex].HideHighlight();
            }

            if (moveInput.x > 0) // move right
            {
                if (selectedIndex < inventoryIcons.Count - 1)
                    selectedIndex++;

            }
            else if (moveInput.x < 0) // move left
            {
                if (selectedIndex > 0)
                    selectedIndex--;
            }
            if (inventoryIcons[selectedIndex].inventoryItem != null && !inventoryIcons[selectedIndex].isSelected)
            {
                inventoryIcons[selectedIndex].ShowHighlight();
            }
        }        

        yield return new WaitForSeconds(0.1f);
        isProcessing = false;
    }

    public void OpenInventoryScreen()
    {
        if (isOpen)
        {
            CloseInventoryScreen();
            return;
        }

        SetupInventory();

        if (inventoryIcons[0].inventoryItem != null)
        {
            inventoryIcons[0].ShowHighlight();
        }

        PlayerController.Instance.canMove = false;
        isOpen = true;
        this.gameObject.SetActive(true);
    }

    public void CloseInventoryScreen()
    {
        inventoryIcons[selectedIndex].HideHighlight();

        isOpen = false;
        this.gameObject.SetActive(false);
        PlayerController.Instance.canMove = true;
    }

    private void SetupInventory()
    {
        SetupInventory(GameController.Instance.inventory.items);
    }

    private void SetupInventory(List<Item> items)
    {
        selectedIndex = 0;
        foreach (InventoryIcon icon in inventoryIcons)
        {
            icon.UpdateIcon(null);
            icon.HideHighlight();
        }

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];
            inventoryIcons[i].UpdateIcon(item);

            if (i == 0)
            {
                inventoryIcons[0].ShowHighlight();
            }
        }
    }

    public void UseSelectedItem()
    {
        InventoryIcon icon = inventoryIcons[selectedIndex];
        if (icon.inventoryItem != null)
        {
            icon.inventoryItem.Use();
            icon.UpdateIcon(icon.inventoryItem);

            // Update list again in case the used item no longer exists
            SetupInventory();
        }
    }
}
