using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalPickup : pickup
{
    private float currTime = 0f;
    public float rotateTime = 0.75f;
    private int currentRotationIndex = 0;
    private float[] rotateAngles = { 45f, 90f, 45f, 45f, 90f, 45f };

    public HexagonTile ownerTile = null;

    protected override void Update()
    {
        if (currentOwner != null && ownerTile == null)
        {
            currTime += Time.deltaTime;
            if (currTime > rotateTime)
            {
                currTime = 0f;
                transform.Rotate(Vector3.forward, -rotateAngles[currentRotationIndex]);

                if (currentRotationIndex == rotateAngles.Length - 1)
                    currentRotationIndex = 0;
                else
                    currentRotationIndex++;
            }
        }

        if (currentOwner == null && ownerTile == null)
            PickupAnim();
        else if(currentOwner != null)
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale, 5.0f * Time.deltaTime);

        Collider2D collTile = Physics2D.OverlapPoint(transform.position, tileLayerMask.value);
        if (collTile != null)
        {
            var tileComponent = collTile.gameObject.GetComponent<AnyTile>();
            if(tileComponent != null)
                if(tileComponent.type == HexagonTile.TileType.DirectionalTile)
                    tileComponent.canSpawn = false;
        }

        if (currentOwner != null)
            transform.position = Vector3.Lerp(transform.position, currentOwner.pickupPos.position, 10.0f * Time.deltaTime);
        else if (ownerTile != null)
        {
            transform.position = Vector3.Lerp(transform.position, ownerTile.transform.position, 10.0f * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, originalScale * 2.0f, 5.0f * Time.deltaTime);
        }
    }
}
