using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public enum BeeType
    {
        Bee,
        Player
    }

    public Transform pickupPos;
    public pickup carryingObject;

    public LayerMask tileLayerMask;

    public Transform trailPos;
    private Vector3 lastPos;
    private float lastAngle = 0f;
    public float trailDist = 0.5f;
    public GameObject trailPrefab;

    [SerializeField]
    private Sprite[] beeSprites;
    private int currFrameIndex = 0;
    private float animTime = 0.04f;
    private float currTime = 0f;

    private void Start()
    {
        currFrameIndex = 0;
        currTime = 0f;
        lastPos = transform.position;
        lastAngle = 0f;
    }

    protected virtual void Update()
    {
        SpawnTrail();
        ChangeSprite();
        CheckTileCollision();
    }

    private void SpawnTrail()
    {
        float currAngle = Mathf.Atan2(transform.up.y, transform.up.x);
        float angleDiff = Mathf.Abs(lastAngle - currAngle);
        float posDiff = Vector3.Distance(transform.position, lastPos);
        if (posDiff > trailDist)
        {
            var trail = Instantiate(trailPrefab);
            trail.transform.position = trailPos.position;
            trail.transform.rotation = Quaternion.Euler(0f, 0f, -90f) * transform.rotation;
            lastPos = transform.position;
            lastAngle = currAngle;
        }
    }

    private void CheckTileCollision()
    {
        Collider2D coll = Physics2D.OverlapPoint(transform.position, tileLayerMask.value);
        if (coll != null)
            coll.gameObject.GetComponent<AnyTile>().canSpawn = false;
    }

    private void ChangeSprite()
    {
        currTime += Time.deltaTime;
        if (currTime > animTime)
        {
            currTime = 0;
            currFrameIndex = (currFrameIndex == beeSprites.Length - 1) ? 0 : currFrameIndex + 1;
            GetComponent<SpriteRenderer>().sprite = beeSprites[currFrameIndex];
        }
    }

    public void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
