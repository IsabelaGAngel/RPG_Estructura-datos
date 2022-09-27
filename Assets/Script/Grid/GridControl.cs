using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridControl : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    [SerializeField] LayerMask terrainLayerMask;

    Vector2Int currentGridPosition = new Vector2Int(-1, -1);

    [SerializeField] GridObject hoveringOver;
    [SerializeField] SelectableGridObject selectedObject;

    private void Update()
    {
        HoverOverObjectCheck();

        SelectObject();

        DeselectObject();
    }

    private void DeselectObject()
    {
        if (Input.GetMouseButtonDown(1))
        {
            selectedObject = null;
        }
    }

    private void SelectObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hoveringOver == null) { return; }
            selectedObject = hoveringOver.GetComponent<SelectableGridObject>();
        }
    }

    private void HoverOverObjectCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, terrainLayerMask))
        {
            Vector2Int gridPosition = targetGrid.GetGridPosition(hit.point);
            if (gridPosition == currentGridPosition) { return; }
            currentGridPosition = gridPosition;
            GridObject gridObject = targetGrid.GetPlacedObject(gridPosition);
            hoveringOver = gridObject;
        }
    }
}
