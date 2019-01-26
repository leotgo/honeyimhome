using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour
{
    public GameObject pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.GetComponent<player>() != null)
        {
            var player = collision.gameObject.GetComponent<player>();
            if (player.carryingObject == null)
            {
                var p = Instantiate(pickup);
                p.transform.parent = player.transform;
                p.transform.position = player.pickupPos.position;
                player.carryingObject = p.GetComponent<pickup>();
            }
        } 
    }
}
