﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public enum PickupType
    {
        Honey,       // OBJETO de mel, que abelha pode pegar
        Wax,         // OBJETO de cera, que abelha pode pegar
        Larva,       // OBJETO de larva, que abelha pode pegar
        Polen,       // OBJETO de polen, que abelha pode pegar
        Secretion,   // OBJETO, que abelha pode pegar
        Flower,      // OBJETO de flor, que abelha pode pegar
        Jelly,       // OBJETO de geléia, que abelha pode pegar
        Directional, // OBJETO direcional, que pode ser botado em um tile pelo jogador
    }

    public PickupType type;
    public GameObject tilePrefab;
    public Bee currentOwner = null;

    private bool interactable = false;

    private void Awake()
    {
        interactable = true;
        currentOwner = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!interactable)
            return;

        if (collision.gameObject.GetComponent<Bee>() != null)
        {
            var bee = collision.gameObject.GetComponent<Bee>();
            OnInteractWithBee(bee);
        }
        else if (collision.gameObject.GetComponent<HexagonTile>() != null && currentOwner != null)
        {
            HexagonTile tile = collision.gameObject.GetComponent<HexagonTile>();
            OnInteractWithTile(tile);
        }
        else if (collision.gameObject.GetComponent<pickup>() != null && currentOwner != null)
        {
            var p = collision.gameObject.GetComponent<pickup>();
            OnInteractWithPickup(p);
        }
    }

    public virtual void OnConsume()
    {
        Destroy(this.gameObject);
    }

    public void CombineToNewEntity(pickup other, GameObject prefab)
    {
        this.interactable = false;
        other.interactable = false;
        var newPickup = Instantiate(prefab);
        newPickup.transform.position = other.transform.position;
        this.OnConsume();
        other.OnConsume();
    }

    public virtual void OnInteractWithTile(HexagonTile tile)
    {
        // Implementar em classes filhas
    }

    public virtual void OnInteractWithBee(Bee bee)
    {
        if (bee.carryingObject == null)
        {
            if (currentOwner != null)
                currentOwner.carryingObject = null;
            currentOwner = bee;
            transform.parent = bee.transform;
            transform.position = bee.pickupPos.position;
            bee.carryingObject = this;
        }
    }

    public virtual void OnInteractWithPickup(pickup p)
    {
        // Implementar em classes filhas
    }


}
