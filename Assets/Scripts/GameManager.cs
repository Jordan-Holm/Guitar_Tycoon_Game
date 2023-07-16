using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("UI Counts")]
    public float money;

    [Header("UI HUD")]
    public TextMeshProUGUI moneyText;

    [Header("Managers")]
    public GameObject moneyManager;

    private static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        MoneyUpdater(5);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MoneyUpdater (float moneyToAdd)
    {
        money += moneyToAdd;
        moneyText.text = "$" + money;
        Debug.Log("Recieved money from MoneyManager");
    }
}
