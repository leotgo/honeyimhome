﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPrefabHolder : MonoBehaviour
{
    public static PickupPrefabHolder instance;

    public GameObject honeyPickupPrefab;
    public GameObject waxPickupPrefab;
    public GameObject larvaPickupPrefab;
    public GameObject polenPickupPrefab;
    public GameObject directionalPickupPrefab;

    void Start()
    {
        instance = this;
    }
}
