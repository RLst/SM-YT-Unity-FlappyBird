using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float initialDelay = 1;
    public float spawnInterval = 2;
    public GameObject obstaclePrefab;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), initialDelay, spawnInterval);
    }

    public void Spawn()
    {
        Instantiate(obstaclePrefab, this.transform.position, Quaternion.identity);
    }
}
