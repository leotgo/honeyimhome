using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInfoListManager : MonoBehaviour
{

    List<TileInfo> tileInfoList;    

    private void Start()
    {
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
        while(result == null && i < tileInfoList.Count)
        {
            if (tilePosition == tileInfoList[i].tilePosition)
            {
                result = tileInfoList[i].hexagonTile;
            }
            i++;
        }
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
