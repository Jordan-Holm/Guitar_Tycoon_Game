using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckTable : MonoBehaviour
{
    public float timeRemaining = 5f;
    public int woodNeededToBuild = 1;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            if (gameManager.woodCount >= woodNeededToBuild)
            {
                gameManager.InventoryUpdater(1, "neck");
                gameManager.InventoryUpdater(-1, "wood");
                timeRemaining = 5f;
                Debug.Log("5 seconds up");
            }
            else
            {
                Debug.Log("Out of Materials");
                timeRemaining = 5f;
            }
                
        }
    }


}
