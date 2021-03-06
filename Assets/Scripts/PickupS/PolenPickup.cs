﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolenPickup : pickup
{
    public override void OnInteractWithPickup(pickup other)
    {
        switch (other.type)
        {
            case PickupType.Honey:
                CombineToNewEntity(other, PickupPrefabHolder.instance.waxPickupPrefab);
                break;
            case PickupType.Wax:
                CombineToNewEntity(other, PickupPrefabHolder.instance.larvaPickupPrefab);
                break;
            case PickupType.Larva:
                CombineToNewEntity(other, EntityPrefabHolder.instance.beePrefab);
                break;
            case PickupType.Polen:
                CombineToNewEntity(other, PickupPrefabHolder.instance.honeyPickupPrefab);
                break;
            
        }
    }

    public override void OnInteractWithTile(HexagonTile tile)
    {
        Debug.Log("Interacting with tile " + tile.name);
    }

}
