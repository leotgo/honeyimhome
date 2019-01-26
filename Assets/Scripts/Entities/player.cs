using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Bee
{
    public void spawnTile()
    {
        if(carryingObject != null)
        {
            GameObject gridobject = GameObject.FindGameObjectWithTag("Grid");
            Grid grid = gridobject.GetComponent<Grid>();
            var t = Instantiate(carryingObject.tilePrefab);
            t.transform.position = grid.GetCellCenterWorld(TileChooser.instance.currentTile);
            TileInfoListManager.instance.addTile(t.GetComponent<HexagonTile>(), TileChooser.instance.currentTile);
            carryingObject.OnConsume();
        }
    }
}
