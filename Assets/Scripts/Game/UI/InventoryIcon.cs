using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryIcon : MonoBehaviour
{
    public bool isSelected = false;
    public TextMeshProUGUI quantityText;
    public Image itemIcon;
    public Image itemPanelBg;
    public Item inventoryItem;

    public Color normalBorder = Color.white;
    public Color highlightBorder = Color.yellow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateIcon(Item item)
    {
        if (item == null)
        {
            inventoryItem = null;
            quantityText.text = string.Empty;
            itemIcon.sprite = null;
            HideHighlight();
            return;
        }

        inventoryItem = item;
        itemIcon.sprite = item.spriteIcon;
        quantityText.text = item.currentQuantity.ToString();
    }

    public void ShowHighlight()
    {
        isSelected = true;
        itemPanelBg.color = highlightBorder;
    }

    public void HideHighlight()
    {
        isSelected = false;
        itemPanelBg.color = normalBorder;
    }
}
