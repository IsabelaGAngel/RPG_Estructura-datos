using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    [SerializeField] Grid targetGrid;
    [SerializeField] GridHiglight higlight;

    List<Vector2Int> attackPosition;

    public void CalculateAttackArea(Vector2Int characterPositionOnGrid, int attackRange, bool selfTargetable = false) 
    {
        if (attackPosition == null)
        {
            attackPosition = new List<Vector2Int>();
        }
        else {
            attackPosition.Clear();
        }

        for (int x = -attackRange; x <= attackRange; x++)
        {
            for (int y = -attackRange; y <= attackRange; y++)
            {
                if ((Mathf.Abs(x) + Mathf.Abs(y)) > attackRange) { continue; }

                if (selfTargetable == false)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }
                }

                if (targetGrid.CheckBoundry(characterPositionOnGrid.x + x, characterPositionOnGrid.y + y) == true)
                {
                    attackPosition.Add(
                        new Vector2Int(
                            characterPositionOnGrid.x + x,
                            characterPositionOnGrid.y + y
                            )
                        );
                }
            }
        }

        higlight.Highlight(attackPosition);
    }

    internal GridObject GetAttackTarget(Vector2Int positionOnGrid)
    {
        GridObject target = targetGrid.GetPlacedObject(positionOnGrid);
        return target;
    }

    internal bool Check(Vector2Int positionOnGrid)
    {
        return attackPosition.Contains(positionOnGrid);
    }
}
