using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Bee
{
    public LayerMask pickupLayerMask;

    protected override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SpawnTileOfType(HexagonTile.TileType.PolenTile);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SpawnTileOfType(HexagonTile.TileType.HoneyTile);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SpawnTileOfType(HexagonTile.TileType.WaxTile);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            SpawnTileOfType(HexagonTile.TileType.LarvaTile);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            SpawnTileOfType(HexagonTile.TileType.DirectionalTile);
    }

    public void SpawnTileOfType(HexagonTile.TileType type)
    {
        GameObject prefab;
        switch(type)
        {
            case HexagonTile.TileType.DirectionalTile:
                prefab = TilePrefabHolder.instance.directionalTilePrefab;
                break;
            case HexagonTile.TileType.HoneyTile:
                prefab = TilePrefabHolder.instance.honeyTilePrefab;
                break;
            case HexagonTile.TileType.LarvaTile:
                prefab = TilePrefabHolder.instance.larvaTilePrefab;
                break;
            case HexagonTile.TileType.PolenTile:
                prefab = TilePrefabHolder.instance.polenTilePrefab;
                break;
            case HexagonTile.TileType.WaxTile:
                prefab = TilePrefabHolder.instance.waxTilePrefab;
                break;
            default:
                return;
        }
        var t = Instantiate(prefab);
        t.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
        TileInfoListManager.instance.addTile(t.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
    }

    public void Interact()
    {
        if (carryingObject != null)
        {
            if (TileInfoListManager.instance.tileIsEmpty(TileChooser.instance.currentTile))
            {
                var t = Instantiate(carryingObject.tilePrefab);
                t.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                TileInfoListManager.instance.addTile(t.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
                carryingObject.OnConsume();
            }
            else if (carryingObject.type == pickup.PickupType.Directional)
            {
                var tile = TileInfoListManager.instance.getHexagonTile(TileChooser.instance.currentTile);
                if (tile.type != HexagonTile.TileType.DirectionalTile && !tile.isDirectional)
                {
                    carryingObject.currentOwner = null;
                    tile.isDirectional = true;
                    tile.directionalPickup = carryingObject.gameObject;
                    ((DirectionalPickup)carryingObject).ownerTile = tile;
                    carryingObject = null;
                }
            }
        }
        else
        {
            var collPickup = Physics2D.OverlapCircle(transform.position, 0.5f, pickupLayerMask.value);
            if(collPickup != null)
            {
                var p = collPickup.GetComponent<pickup>();
                if (p.currentOwner != null)
                    p.currentOwner.carryingObject = null;
                p.currentOwner = this;
                carryingObject = p;
                if (p is DirectionalPickup)
                {
                    var directionalPickup = (DirectionalPickup)p;
                    if (directionalPickup.ownerTile != null)
                    {
                        directionalPickup.ownerTile.isDirectional = false;
                        directionalPickup.ownerTile.directionalPickup = null;
                        directionalPickup.ownerTile = null;
                    }
                }
            }
        }
    }
}
