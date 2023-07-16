using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeckTable : MonoBehaviour
{
    public float productValue = 5f;

    public float timeRemaining = 5f;

    private MoneyManager moneyManager;

    private void Awake()
    {
        moneyManager = GameObject.FindGameObjectWithTag("Money Manager").GetComponent<MoneyManager>();
    }
    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            moneyManager.AddMoney(productValue);
            timeRemaining = 5f;
            Debug.Log("5 seconds up");
        }
    }


}
