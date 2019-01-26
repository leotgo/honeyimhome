using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Transform pickupPos;
    public pickup carryingObject;

    Grid grid;
    TileChooser tileChooser;

    public void Start()
    {
        GameObject gridobject = GameObject.FindGameObjectWithTag("Grid");
        grid = gridobject.GetComponent<Grid>();
        tileChooser = gridobject.GetComponent<TileChooser>();
    }

    public void spawnTile()
    {
        if(carryingObject != null)
        {
            var tile = Instantiate(carryingObject.prefab);
            Debug.Log(tileChooser.currentTile);
            tile.transform.position = grid.GetCellCenterWorld(tileChooser.currentTile);

            carryingObject.OnConsume();
            carryingObject = null;
        }

        
    }
}
