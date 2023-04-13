using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float initialDelay = 1f;
    public float spawnInterval = 2f;
    public float maxRandomHeight = 3f;
    public GameObject obstaclePrefab;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), initialDelay, spawnInterval);
    }

    public void Spawn()
    {
        var randomHeight = Random.Range(-maxRandomHeight * 0.5f, maxRandomHeight * 0.5f);
        Instantiate(obstaclePrefab, this.transform.position + Vector3.up * randomHeight, Quaternion.identity);
    }
}
