using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaxPickup : pickup
{
    public override void OnInteractWithPickup(pickup other)
    {
        switch (other.type)
        {
            case PickupType.Honey:
                CombineToNewEntity(other, PickupPrefabHolder.instance.larvaPickupPrefab);
                break;
            case PickupType.Larva:
                CombineToNewEntity(other, PickupPrefabHolder.instance.directionalPickupPrefab);
                break;
            case PickupType.Polen:
                CombineToNewEntity(other, PickupPrefabHolder.instance.larvaPickupPrefab);
                break;
            case PickupType.Wax:
                CombineToNewEntity(other, PickupPrefabHolder.instance.polenPickupPrefab);
                break;
        }
    }

    public override void OnInteractWithTile(HexagonTile tile)
    {

    }

}
