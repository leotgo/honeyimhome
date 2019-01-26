using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChooser : MonoBehaviour
{
    public static TileChooser instance;

    GameObject player;

    public Grid grid;
    public GameObject highlightHex;
    public Vector3Int currentTile;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3Int cellPosition = grid.WorldToCell(player.transform.position);

        highlight_hex.transform.position = new Vector3(cellPosition.x, cellPosition.y);
        */
        
        Vector3Int cellPosition = grid.WorldToCell(player.transform.position);

        highlightHex.transform.position = grid.GetCellCenterWorld(cellPosition);

        currentTile = new Vector3Int(cellPosition.x, cellPosition.y, cellPosition.z);

    }
}
