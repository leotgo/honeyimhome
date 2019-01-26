using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(PolygonCollider2D))]
public abstract class HexagonTile : MonoBehaviour
{
    UnityEvent<pickup.PickupType> onPickupEvent;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<pickup>() != null)
        {
            var pickup = collision.gameObject.GetComponent<pickup>();
            OnInteract(pickup);
        }
        else if(collision.gameObject.GetComponent<player>() != null)
        {
            var player = collision.gameObject.GetComponent<player>();
            OnInteract(player);
        }
    }

    protected abstract void OnInteract(pickup pickup);
    protected abstract void OnInteract(player player);
}
