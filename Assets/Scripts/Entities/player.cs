﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : Bee
{

    [SerializeField]
    private Sprite[] playerSprites;
    private int currFrameIndex = 0;
    private float animTime = 0.04f;
    private float currTime = 0f;

    private void Start()
    {
        currFrameIndex = 0;
        currTime = 0f;
    }

    private void Update()
    {
        currTime += Time.deltaTime;
        if(currTime > animTime)
        {
            currTime = 0;
            currFrameIndex = (currFrameIndex == playerSprites.Length - 1) ? 0 : currFrameIndex + 1;
            GetComponent<SpriteRenderer>().sprite = playerSprites[currFrameIndex];
        }
    }

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
