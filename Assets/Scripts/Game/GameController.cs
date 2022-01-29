using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseSingletonBehaviour<GameController>
{

    public Camera mainCamera;
    public GameObject player;
    public Inventory inventory;

    public List<Monster> monsters = new List<Monster>();

    private Vector2 moveInput;
   
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        AudioController.Instance.PlayBGM(AudioIdentifier.BGM_Main);
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        ProcessInput();
    }

    #region Inventory related 
    public void AddItem(Item item)
    {
        inventory.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        inventory.RemoveItem(item);
    }

    public void ShowInventory()
    {
        //UIController.Instance.ShowInventory();
    }
    #endregion

    #region Input related
    private void ProcessInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            UIController.Instance.OpenInventoryScreen();
        } 
        else if (UIController.Instance.inventory.isOpen)
        {
            UIController.Instance.inventory.ProcessInput(moveInput);

            if (Input.GetButtonDown("Fire1"))
            {
                UIController.Instance.inventory.UseSelectedItem();
            }
        }
    }

    #endregion
}
