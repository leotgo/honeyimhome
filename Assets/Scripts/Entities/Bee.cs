using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public enum BeeType
    {
        Bee,
        Player
    }

    public Transform pickupPos;
    public pickup carryingObject;

    public void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
