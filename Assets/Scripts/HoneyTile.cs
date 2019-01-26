using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyTile : HexagonTile
{
    protected override void OnInteract(pickup pickup)
    {
        if(pickup.type == pickup.PickupType.Flower)
        {
            Destroy(pickup.gameObject);
            Destroy(this.gameObject);
        }
    }

    protected override void OnInteract(player player)
    {
        
    }
}
