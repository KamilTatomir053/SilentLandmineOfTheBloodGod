using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    Soldiers soldiersSpawner;

    public void SetReference(Soldiers soldiers)
    {
        soldiersSpawner = soldiers;
    }

    public void KillSoldier()
    {
        if (soldiersSpawner != null)
            soldiersSpawner.KilledSoldier();
    }
}
