using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUtility : MonoBehaviour
{
    [SerializeField] Pathfinding targetPF;
    [SerializeField] GridHiglight attackHiglight;
    [SerializeField] GridHiglight moveHiglight;

    public void ClearPathfinding() 
    {
        targetPF.Clear();
    }

    public void ClearGridHiglightAttack() 
    {
        attackHiglight.Hide();
    }

    public void ClearGridHiglightMove() 
    {
        moveHiglight.Hide();
    }
}
