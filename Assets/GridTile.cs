using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : HexagonTile
{
    public static GridTile instance;

    private void Start()
    {
        instance = this;
    }
}
