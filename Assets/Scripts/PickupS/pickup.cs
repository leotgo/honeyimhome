using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup : MonoBehaviour
{
    public GameObject spawner;
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

    public LayerMask tileLayerMask;
    public LayerMask pickupLayerMask;

    private bool interactable = false;
    private float animationTime;
    protected Vector3 originalScale;

    private void Awake()
    {
        interactable = true;
        currentOwner = null;
        animationTime = 0.5f;
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }

    protected virtual void Update()
    {
        if (currentOwner == null)
            PickupAnim();
        else
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, 5.0f*Time.deltaTime);

        Collider2D collTile = Physics2D.OverlapPoint(transform.position, tileLayerMask.value);
        if (collTile != null)
            collTile.gameObject.GetComponent<AnyTile>().canSpawn = false;

        if (currentOwner != null)
            transform.position = Vector3.Lerp(transform.position, currentOwner.pickupPos.position, 10.0f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!interactable)
            return;

        if (collision.gameObject.GetComponent<Bee>() != null)
        {
            var bee = collision.gameObject.GetComponent<Bee>();
            if(!(bee is player))
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

    public void PickupAnim()
    {
        animationTime += Time.deltaTime;
        if (animationTime > 2f)
            animationTime = 0f;

        var targetScale = originalScale * (1.25f + Mathf.Sin(animationTime * 180f * Mathf.Deg2Rad) * 0.25f);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 5.0f * Time.deltaTime);
    }

    public virtual void OnConsume()
    {
        Destroy(this.gameObject);
    }

    public void CombineToNewEntity(pickup other, GameObject prefab)
    {
        this.interactable = false;
        other.interactable = false;
        var newEntity = Instantiate(prefab);
        newEntity.transform.position = other.transform.position;
        if (newEntity.GetComponent<pickup>() != null)
        {
            newEntity.GetComponent<pickup>().currentOwner = this.currentOwner;
            this.currentOwner.carryingObject = newEntity.GetComponent<pickup>();
        }
        this.OnConsume();
        other.OnConsume();
    }

    public virtual void OnInteractWithTile(HexagonTile tile)
    {
        // Implementar em classes filhas
    }

    public virtual void OnInteractWithBee(Bee bee)
    {
        if (bee.carryingObject == null && type != PickupType.Directional)
        {
            if (currentOwner != null)
                currentOwner.carryingObject = null;
            currentOwner = bee;
            bee.carryingObject = this;
        }
    }

    public virtual void OnInteractWithPickup(pickup p)
    {
        // Implementar em classes filhas
    }


}
