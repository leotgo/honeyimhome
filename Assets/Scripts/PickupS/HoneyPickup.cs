using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPickup : pickup
{
    public override void OnInteractWithPickup(pickup other)
    {
        switch (other.type)
        {
            case PickupType.Wax:
                CombineToNewEntity(other, PickupPrefabHolder.instance.larvaPickupPrefab);
                break;
            case PickupType.Larva:
                CombineToNewEntity(other, EntityPrefabHolder.instance.beePrefab);
                break;
            case PickupType.Polen:
                CombineToNewEntity(other, PickupPrefabHolder.instance.waxPickupPrefab);
                break;
        }
    }

    public override void OnInteractWithTile(HexagonTile tile)
    {
        
    }
}
