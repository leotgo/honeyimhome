using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform pickupPos;
    public pickup carryingObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnTile();
        }   
    }

    void spawnTile()
    {
        if(carryingObject != null)
        {
            var tile = Instantiate(carryingObject.prefab);
            tile.transform.position = transform.position;

            carryingObject.OnConsume();
            carryingObject = null;
        }

        
    }
}
