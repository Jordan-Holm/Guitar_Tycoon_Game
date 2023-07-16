using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float moneyToAdd = 1.50f;

    private GameManager gameManager;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
  
    }

    public void AddMoney(float productValue)
    {
        gameManager.InventoryUpdater(moneyToAdd, "money");
        Debug.Log("Adding Money to GameManger");
    }

}
