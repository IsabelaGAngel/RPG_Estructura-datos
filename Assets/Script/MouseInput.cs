using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [SerializeField] Grid targetGrid;
    [SerializeField] LayerMask terrainLayerMask;

    public Vector2Int positionOnGrid;
    public bool active;

    [SerializeField] TMPro.TextMeshProUGUI positionOnScreen;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, terrainLayerMask))
        {
            active = true;
            Vector2Int hitPosition = targetGrid.GetGridPosition(hit.point);
            if (hitPosition != positionOnGrid)
            {
                positionOnGrid = hitPosition;
                positionOnScreen.text = "Position " + positionOnGrid.x.ToString() + ":" + positionOnGrid.y;
            }
        }
        else {
            active = false;
            positionOnScreen.text = "Outside";
        }
    }
}
