using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool menuActivated = false;
    public ItemSlot[] itemSlot;
    public static InventoryManager Instance;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate InventoryManager
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuActivated)
        {
            Debug.Log("Inventory Button pressed");
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && !menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }

    //pass in the item name, quantity, and sprite from Item class
    public void AddItem(string itemName, int quantity, Sprite sprite)
    {
        Debug.Log("Item added to inventory: " + itemName + " x" + quantity);

        for(int i = 0; i < itemSlot.Length; i++)
        {
            if (!itemSlot[i].full)
            {
                itemSlot[i].AddItem(itemName, quantity, sprite);
                break;
            }
        }
    }
}
