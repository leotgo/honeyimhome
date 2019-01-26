using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityPrefabHolder : MonoBehaviour
{
    public static EntityPrefabHolder instance;

    public GameObject beePrefab;

    private void Start()
    {
        instance = this;
    }
}
