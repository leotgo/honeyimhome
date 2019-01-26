using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(PolygonCollider2D))]
public class HexagonTile : Entity
{
    public bool isDirectional = false;
    public Vector3 direction = Vector3.zero;

    private TileInfoListManager tileInfoListManager;
    private Grid grid;
    private TileChooser tileChooser;

    private void Start()
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
        if(collision.gameObject.GetComponent<Entity>() != null)
        {
            var entity = collision.gameObject.GetComponent<Entity>();
            EntitiesInteractions.instance.ProcessInteraction(this, entity);
        }
    }
}
