using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public enum PickupType
    {
        Flower,
        Honey,
        Polen
    }

    public PickupType type = PickupType.Flower;

    public GameObject prefab;

    public virtual void OnConsume()
    {
        Destroy(this.gameObject);
    }

}
