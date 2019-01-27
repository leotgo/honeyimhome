using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyTile : HexagonTile
{
    public GameObject pickupPrefab;
    public float spawnTime = 5f;
    private float currentTime = 0f;
    public bool wasPicked = true;

    private void Start()
    {
        currentTime = 0f;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > spawnTime && wasPicked)
        {
            SpawnPickup();
            currentTime = 0f;
            wasPicked = false;
        }
        if(wasPicked == false)
        {
            currentTime = 0f;
        }
    }

    private void SpawnPickup()
    {
        var pickup = Instantiate(pickupPrefab);
        pickup.transform.position = transform.position;
        pickup pickupclass = pickup.GetComponent<pickup>();
        pickupclass.spawner = this.gameObject;
    }
}