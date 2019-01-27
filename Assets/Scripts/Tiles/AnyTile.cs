using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnyTile : HexagonTile
{
    public GameObject pickupPrefab;
    public float spawnTime = 5f;
    private float currentTime = 0f;
    public bool canSpawn = true;

    public List<GameObject> entitiesInTile;

    private Collider2D coll2D;

    private void Start()
    {
        var defaultScale = transform.localScale;
        transform.localScale = Vector3.zero;
        transform.DOScale(defaultScale, 0.5f);
        currentTime = 0f;
        coll2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!canSpawn)
            currentTime = 0f;
        else
            currentTime += Time.deltaTime;

        if(currentTime > spawnTime && canSpawn)
        {
            SpawnPickup();
            currentTime = 0f;
        }
        canSpawn = true;
    }

    private void SpawnPickup()
    {
        var pickup = Instantiate(pickupPrefab);
        pickup.transform.position = transform.position;
        pickup pickupclass = pickup.GetComponent<pickup>();
        pickupclass.spawner = this.gameObject;
    }
}