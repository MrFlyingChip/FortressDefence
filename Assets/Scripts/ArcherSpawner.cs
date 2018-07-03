using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherSpawner : MonoBehaviour {

    public RectTransform[] spawnPoints;
    public GameObject archerPrefab;

    public ArcherController SpawnArcher(int number)
    {
        GameObject archer = Instantiate(archerPrefab, spawnPoints[number]) as GameObject;

        return archer.GetComponent<ArcherController>();
    }
}
