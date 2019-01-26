using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(PolygonCollider2D))]
public class HexagonTile : MonoBehaviour
{
    public enum TileType
    {
        Grid,             // Uma célula no grid sem nada, pode virar tile
        NormalTile,       // Um tile normal (neutro), que não faz nada
        HoneyTile,        // Produz mel
        WaxTile,          // Um tile que produz cera
        LarvaTile,        // Produz larvas
        PolenTile,        // Produz pólen
        SecretionTile,    // Produz secreção
        FlowerTile,       // Produz flores
        JellyTile,        // Produz Geléia
        DirectionalTile   // Produz direcionais
    }

    public bool isDirectional = false;
    public Vector3 direction = Vector3.zero;
    public TileType type;

    private TileInfoListManager tileInfoListManager;
    private Grid grid;
    private TileChooser tileChooser;

    private void Awake()
    {
        GameObject gridobject = GameObject.FindGameObjectWithTag("Grid");
        grid = gridobject.GetComponent<Grid>();
        tileChooser = gridobject.GetComponent<TileChooser>();
        GameObject tileInfoListManagerObject = GameObject.FindGameObjectsWithTag("TileInfoListManager")[0];
        tileInfoListManager = tileInfoListManagerObject.GetComponent<TileInfoListManager>();

        //tileInfoListManager.DeleteTile(tileChooser.currentTile);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        var bee = collision.gameObject.GetComponent<Bee>();
        if (collision.gameObject.GetComponent<Bee>() != null)
        {
        }
    }
}
