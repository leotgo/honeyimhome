using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : Entity
{
    public GameObject tilePrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Entity>() != null)
        {
            var entity = collision.gameObject.GetComponent<Entity>();
            EntitiesInteractions.instance.ProcessInteraction(this, entity);
        }
    }

    public virtual void OnConsume()
    {
        Destroy(this.gameObject);
    }

}
