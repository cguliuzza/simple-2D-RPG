using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currentGold = 0;
    public List<Item> items = new List<Item>();
    public int maxLimit = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseGold(int value)
    {
        currentGold += value;
        GameEvents.OnGoldChanged.Invoke(currentGold);
    }

    public void DecreaseGold(int value)
    {
        currentGold -= value;
        GameEvents.OnGoldChanged.Invoke(currentGold);
    }

    public void AddItem(Item item)
    {
        if (item.itemType == ItemType.Gold)
        {
            IncreaseGold(item.value);
        }
        else
        {
            if (items.Contains(item))
            {
                int index = items.IndexOf(item);
                items[index].IncreaseQuantity();
            }
            else if (items.Count < maxLimit)
            {
                items.Add(item);
            }
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }

    public void RemoveItemByIndex(int index)
    {
        items.RemoveAt(index);
    }

    public void UseItemByIndex(int index)
    {
        UseItem(items[index]);
    }

    public void UseItem(Item item)
    {
        AudioController.Instance.PlaySFX(AudioIdentifier.Item_Use);
    }
}
