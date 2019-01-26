using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfo
{
    public Vector3Int tilePosition;
    public HexagonTile hexagonTile;

    public TileInfo(Vector3Int tilePosition,HexagonTile hexagonTile)
    {
        this.tilePosition = tilePosition;
        this.hexagonTile = hexagonTile;
    }
}
