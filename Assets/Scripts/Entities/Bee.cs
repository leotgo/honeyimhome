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

    [SerializeField]
    private Sprite[] beeSprites;
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
            currFrameIndex = (currFrameIndex == beeSprites.Length - 1) ? 0 : currFrameIndex + 1;
            GetComponent<SpriteRenderer>().sprite = beeSprites[currFrameIndex];
        }
    }

    public void OnDeath()
    {
        Destroy(this.gameObject);
    }
}
