using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform pickupPos;
    public pickup carryingObject;

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

    public void spawnTile()
    {
        if(carryingObject != null)
        {
            var tile = Instantiate(carryingObject.prefab);
            Debug.Log(tileChooser.currentTile);
            tile.transform.position = grid.GetCellCenterWorld(tileChooser.currentTile);

            tileInfoListManager.addTile(null, tileChooser.currentTile);

            carryingObject.OnConsume();
            carryingObject = null;
        }

        
    }
}
