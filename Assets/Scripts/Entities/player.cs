using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        switch (type)
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
            if (carryingObject.type == pickup.PickupType.Directional)
            {
                var tile = TileInfoListManager.instance.getHexagonTile(TileChooser.instance.currentTile);
                var currTile = TileChooser.instance.currentTile;
                // se tile nao esta vazio, substitui por um tile de direcao
                if (!TileInfoListManager.instance.tileIsEmpty(currTile))
                {
                    var tileComponent = tile.GetComponent<AnyTile>();
                    if (tileComponent.currentlyHeldPickup != null)
                        tileComponent.currentlyHeldPickup.GetComponent<pickup>().OnConsume();
                    TileInfoListManager.instance.DeleteTile(TileChooser.instance.currentTile);
                    Destroy(tile.gameObject);
                    var newTile = Instantiate(TilePrefabHolder.instance.normalTilePrefab).GetComponent<AnyTile>();
                    newTile.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                    TileInfoListManager.instance.addTile(newTile.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
                    carryingObject.currentOwner = null;
                    newTile.isDirectional = true;
                    newTile.directionalPickup = carryingObject.gameObject;
                    ((DirectionalPickup)carryingObject).ownerTile = newTile;
                    carryingObject.GetComponent<SpriteRenderer>().DOFade(0.3f, 0.5f);
                    carryingObject = null;
                }
                // se esta vazio, cria um tile gerador de direcoes
                else
                {
                    var newTile = Instantiate(TilePrefabHolder.instance.directionalTilePrefab).GetComponent<AnyTile>();
                    newTile.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                    TileInfoListManager.instance.addTile(newTile.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
                    carryingObject.OnConsume();
                }
            }
            else
            {
                var currTile = TileChooser.instance.currentTile;
                if (TileInfoListManager.instance.tileIsEmpty(currTile))
                {
                    var t = Instantiate(carryingObject.tilePrefab);
                    t.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                    TileInfoListManager.instance.addTile(t.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
                    carryingObject.OnConsume();
                }
                else
                {
                    // se tem tile normal, substitui
                    var hexTile = TileInfoListManager.instance.getHexagonTile(TileChooser.instance.currentTile);
                    if (hexTile.type == HexagonTile.TileType.NormalTile)
                    {
                        TileInfoListManager.instance.DeleteTile(TileChooser.instance.currentTile);
                        Destroy(hexTile.gameObject);
                        var t = Instantiate(carryingObject.tilePrefab);
                        t.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                        TileInfoListManager.instance.addTile(t.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
                        carryingObject.OnConsume();
                    }
                }
            }
        }
        else
        {
            // procura pra ver se tem pickup pra pegar
            var collPickup = Physics2D.OverlapCircle(transform.position, 0.3f, pickupLayerMask.value);
            if (collPickup != null)
            {
                var p = collPickup.GetComponent<pickup>();
                if (p.currentOwner != null)
                    p.currentOwner.carryingObject = null;
                p.currentOwner = this;
                carryingObject = p;
                if (p.spawner != null)
                {
                    p.spawner.GetComponent<AnyTile>().currentlyHeldPickup = null;
                    p.spawner = null;
                }
                if (p is DirectionalPickup)
                {
                    var directionalPickup = (DirectionalPickup)p;
                    if (directionalPickup.ownerTile != null)
                    {
                        directionalPickup.ownerTile.isDirectional = false;
                        directionalPickup.ownerTile.directionalPickup = null;
                        directionalPickup.ownerTile = null;
                        directionalPickup.GetComponent<SpriteRenderer>().DOFade(1f, 0.5f);
                    }
                }
            }
            // se nao tem pickup, verifica se o tile vazio
            else if (TileInfoListManager.instance.tileIsEmpty(TileChooser.instance.currentTile))
            {
                // se o tile estiver vazio,
                // Player cria um tile vazio, apertando num elemento do grid segurando nada
                var newTile = Instantiate(TilePrefabHolder.instance.normalTilePrefab).GetComponent<AnyTile>();
                newTile.transform.position = GridCache.grid.GetCellCenterWorld(TileChooser.instance.currentTile);
                TileInfoListManager.instance.addTile(newTile.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
            }
        }
    }
}
