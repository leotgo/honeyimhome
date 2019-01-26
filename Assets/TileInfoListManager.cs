using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfoListManager : MonoBehaviour
{
    public static TileInfoListManager instance;
    List<TileInfo> tileInfoList;    

    private void Start()
    {
        instance = this;
        tileInfoList = new List<TileInfo>();
    }

    public void addTile(HexagonTile hexagonTile,Vector3Int tilePosition)
    {
        TileInfo tileInfo = new TileInfo(tilePosition,hexagonTile);
        tileInfoList.Add(tileInfo);

    }

    public HexagonTile getHexagonTile(Vector3Int tilePosition)
    {
        int i = 0;
        HexagonTile result = null;
        while (result == null && i < tileInfoList.Count)
        {
            if (tilePosition == tileInfoList[i].tilePosition)
            {
                result = tileInfoList[i].hexagonTile;
            }
            i++;
        }
        if (result == null)
        {
            var gridTile = GridTile.instance;
            gridTile.type = HexagonTile.TileType.Grid;
            return gridTile;
        }
        else
        return result;

        
    }

    public void DeleteTile(Vector3Int tilePosition)
    {
        int i = 0;
        TileInfo result = null;
        while (result == null && i < tileInfoList.Count)
        {
            if (tilePosition == tileInfoList[i].tilePosition)
            {
                result = tileInfoList[i];
            }
            i++;
        }
        if (result != null)
        {
            tileInfoList.Remove(result);
        }

    }
}
