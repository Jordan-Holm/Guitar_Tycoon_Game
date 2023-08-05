using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckTable : MonoBehaviour
{
    public float timeToBuild = 5f;
    public int woodNeededToBuild = 1;

    private GameManager gameManager;
    public InventoryItemData ItemData;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (timeToBuild > 0)
        {
            timeToBuild -= Time.deltaTime;
            Debug.Log(timeToBuild);
        }
        else
        {
            BuildNeck();
        }
    }
    public void BuildNeck()
    {
        var inventory = gameManager.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            timeToBuild = 5f;
        }
    }
}