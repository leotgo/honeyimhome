using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileChooser : MonoBehaviour
{
    GameObject player;

    public Grid grid;
    public Vector3 umtileposition;
    public GameObject highlight_hex;

    // Start is called before the first frame update
    void Start()
    {
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
        highlight_hex.transform.position = grid.GetCellCenterWorld(cellPosition);

    }
}
