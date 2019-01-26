using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(PolygonCollider2D))]
public class HexagonTile : Entity
{
    public bool isDirectional = false;
    public Vector3 direction = Vector3.zero;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Entity>() != null)
        {
            var entity = collision.gameObject.GetComponent<Entity>();
            EntitiesInteractions.instance.ProcessInteraction(this, entity);
        }
    }
}
