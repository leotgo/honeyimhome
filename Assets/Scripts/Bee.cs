using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Entity
{
    public Transform pickupPos;
    public pickup carryingObject;

    public void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
