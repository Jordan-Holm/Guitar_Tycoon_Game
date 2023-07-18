using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Grid grid;

    [SerializeField] 
    private ObjectsDatabaseSO database;
    private int selectedObjectIndex = -1;

    [SerializeField]
    private GameObject gridVisual;

    private GridData floorData, stationData;

    private Renderer previewRenderer;

    private List<GameObject> placedGameObjects = new();

    private void Start()
    {
        StopPlacement();
        floorData = new();
        stationData = new();
        previewRenderer = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        if(selectedObjectIndex < 0)
        {
            Debug.Log($"No ID found {ID}");
            return;
        }
        gridVisual.SetActive(true);
        cellIndicator.SetActive(true);
        mouseIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
        {
            return;
        }

        if (gameManager.money >= database.objectsData[selectedObjectIndex].costToBuild)
        {
            Vector3 mousePosition = inputManager.GetSelectedMapPosition();
            Vector3Int gridPosition = grid.WorldToCell(mousePosition);

            bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
            if (placementValidity == false)
                return;

            GameObject newObject = Instantiate(database.objectsData[selectedObjectIndex].Prefab);
            newObject.transform.position = grid.CellToWorld(gridPosition);
            placedGameObjects.Add(newObject);
            GridData selectedData = database.objectsData[selectedObjectIndex].type == "floor" ?
                floorData :
                stationData;
            selectedData.AddObjectAt(gridPosition,
                database.objectsData[selectedObjectIndex].Size,
                database.objectsData[selectedObjectIndex].ID,
                placedGameObjects.Count - 1);

            gameManager.InventoryUpdater(-database.objectsData[selectedObjectIndex].costToBuild, "money");
            StopPlacement();
        }
        else
        {
            Debug.Log("Insufficient Funds");
            return;
        }
    }

    private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    {
        GridData selectedData = database.objectsData[selectedObjectIndex].type == "floor" ? 
            floorData : 
            stationData;

        return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].Size);
    }

    private void StopPlacement()
    {
        selectedObjectIndex = -1;
        gridVisual.SetActive(false);
        cellIndicator.SetActive(false);
        mouseIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        if (selectedObjectIndex < 0)
            return;
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        bool placementValidity = CheckPlacementValidity(gridPosition, selectedObjectIndex);
        previewRenderer.material.color = placementValidity ? Color.green: Color.red;

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }
}
