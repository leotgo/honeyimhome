using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePrefabHolder : MonoBehaviour
{
    public static TilePrefabHolder instance;

    public GameObject directionalTilePrefab;
    public GameObject honeyTilePrefab;
    public GameObject polenTilePrefab;
    public GameObject waxTilePrefab;
    public GameObject larvaTilePrefab;
    public GameObject normalTilePrefab;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
