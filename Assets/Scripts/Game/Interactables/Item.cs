using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Gold,
    Potion,
    Treasure
}
[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public ItemType itemType;
    public int initialQuantity = 1;
    public int currentQuantity = 1;
    public Sprite spriteIcon;
    public int value = 0;

    /// <summary>
    /// Uses the item
    /// </summary>
    public void Use()
    {
        DecreaseQuantity();
    }

    /// <summary>
    /// Increases the quantity of this item by passed value
    /// </summary>
    /// <param name="value"></param>
    public void IncreaseQuantity(int value)
    {
        currentQuantity += value;
    }

    /// <summary>
    /// Increases the quantity of this item by 1
    /// </summary>
    public void IncreaseQuantity()
    {
        currentQuantity++;
    }

    /// <summary>
    /// Decreases the quantity of this item by passed value
    /// </summary>
    /// <param name="value"></param>
    public void DecreaseQuantity(int value)
    {
        if (currentQuantity - value >= 0)
            currentQuantity -= value;

        DestroyIfEmpty();
    }

    /// <summary>
    /// Decreases the quantity of this item by 1
    /// </summary>
    public void DecreaseQuantity()
    {
        if (currentQuantity > 0)
            currentQuantity--;

        DestroyIfEmpty();
    }

    public void DestroyIfEmpty()
    {
        if (currentQuantity == 0)
        {
            GameController.Instance.inventory.RemoveItem(this);
        }
    }
}

