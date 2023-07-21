using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditingSystem : MonoBehaviour
{
    public InputManager inputManager;
    public Camera mainCamera;

    private void Start()
    {
        inputManager = InputManager.FindFirstObjectByType<InputManager>().GetComponent<InputManager>();
        mainCamera = Camera.main;
    }
    private void EditStructure()
    {
        if (!inputManager.IsPointerOverUI())
        {
            Ray ray = inputManager.mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("Station"))
                {
                    Debug.Log($"Hit {hitObject.name}");
                }
            }
        }
    }

    private void Update()
    {
        EditStructure();
    }
}
