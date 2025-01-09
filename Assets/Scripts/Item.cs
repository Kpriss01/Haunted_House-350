using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;



public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    private InventoryManager inventoryManager;

    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
    }

    //check if player collides with object
    private void OnTriggerEnter2D(Collider2D collision)
    {

       UnityEngine.Debug.Log("Collision detected with:" + collision.gameObject.name);

        if (collision.gameObject.tag == "Player")
        {
            inventoryManager.AddItem(itemName, quantity, sprite);
            Destroy(gameObject);
        }
    }
}
