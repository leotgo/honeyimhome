using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyTile : HexagonTile
{
    public GameObject pickupPrefab;
    public float spawnTime = 5f;
    private float currentTime = 0f;

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime)
        {
            SpawnPickup();
            currentTime = 0f;
        }
    }

    private void SpawnPickup()
    {
        var pickup = Instantiate(pickupPrefab);
        pickup.transform.position = transform.position;
    }
}