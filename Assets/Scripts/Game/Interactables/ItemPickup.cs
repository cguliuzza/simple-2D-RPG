using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Interact()
    {
        PickUp();
    }

    public void PickUp()
    {
        if (item.currentQuantity == 0) item.IncreaseQuantity();

        AudioController.Instance.PlaySFX(AudioIdentifier.Item_Pickup);
        GameController.Instance.AddItem(item);
        Destroy(gameObject);
    }
}
