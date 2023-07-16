using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("UI Counts")]
    public float money;
    public int woodCount;
    public int neckCount;
    public int bodyCount;

    [Header("UI HUD")]
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI neckText;

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
        InventoryUpdater(5, "money");
        InventoryUpdater(5, "wood");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddWood()
    {
        if (money >= 5)
        {
            InventoryUpdater(10, "wood");
            InventoryUpdater(-5, "money");
        }
    }

    public void InventoryUpdater (float amountToAdd, string type)
    {
        switch (type)
        {
            case "money":
                money += amountToAdd;
                moneyText.text = $"${money}";
                Debug.Log("Recieved money from MoneyManager");
                break;
            case "wood":
                woodCount += ((int)amountToAdd);
                woodText.text = $"Wood: {woodCount}";
                Debug.Log("One Piece of wood Used");
                break;
            case "neck":
                neckCount += ((int)amountToAdd);
                neckText.text = $"Necks: {neckCount}";
                Debug.Log("One Neck added to inventory");
                break;
            case "body":
                bodyCount += ((int)amountToAdd);
                Debug.Log("One Body Added to inventory");
                break;
        }
    }
}
