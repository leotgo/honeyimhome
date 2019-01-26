using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyTile : HexagonTile
{
    TileInfoListManager tileInfoListManager;
    Grid grid;
    TileChooser tileChooser;

    public void Start()
    {
        GameObject gridobject = GameObject.FindGameObjectWithTag("Grid");
        grid = gridobject.GetComponent<Grid>();
        tileChooser = gridobject.GetComponent<TileChooser>();
        GameObject tileInfoListManagerObject = GameObject.FindGameObjectsWithTag("TileInfoListManager")[0];
        tileInfoListManager = tileInfoListManagerObject.GetComponent<TileInfoListManager>();
    }

    protected override void OnInteract(pickup pickup)
    {
        if(pickup.type == pickup.PickupType.Flower)
        {
            Destroy(pickup.gameObject);
            tileInfoListManager.DeleteTile(tileChooser.currentTile);
            Destroy(this.gameObject);
        }
    }

    protected override void OnInteract(player player)
    {
        
    }
}
