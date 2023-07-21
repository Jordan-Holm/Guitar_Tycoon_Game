using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Inventory Item/Inventory Item")]
public class InventoryItemData : ScriptableObject
{
    public int ID;
    public string DisplayName;
    [Range(1,5)]
    public int itemQuality;
    public float baseItemValue;
    public float itemValue;
    public float itemValueQualityIncrease;
    [TextArea(4, 4)]
    public string Description;
    public Sprite Icon;
    public GameObject gameObjectPrefab;
    public int maxStackSize;

    private void CalculateItemValue()
    {
        if (itemQuality > 1)
            itemValue = (itemValueQualityIncrease * itemQuality) + baseItemValue;
        else
            itemValue = baseItemValue;
    }
}
