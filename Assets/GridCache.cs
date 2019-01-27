using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCache : MonoBehaviour
{
    public static Grid grid;

    void Start()
    {
        GameObject gridobject = GameObject.FindGameObjectWithTag("Grid");
        grid = gridobject.GetComponent<Grid>();
    }
}
