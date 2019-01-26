using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    private bool isAdjusting = false;

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 5.0f;

    [SerializeField]
    private Vector2 deadZone = new Vector2(0.25f, 0.25f);
    [SerializeField]
    private Vector2 adjustingStopZone = new Vector2(0.1f, 0.1f);

    void Start()
    {
        isAdjusting = false;
    }

    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(target.position);
        Vector2 centerPos = new Vector2(0.5f, 0.5f);
        Vector2 relativePos = centerPos - screenPos;

        if (isAdjusting)
        {
            Vector3 playerPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Slerp(transform.position, playerPos, speed * Time.deltaTime);

            if (Mathf.Abs(relativePos.x) < adjustingStopZone.x && Mathf.Abs(relativePos.y) < adjustingStopZone.y)
                isAdjusting = false;
        }
        else
        {
            isAdjusting = Mathf.Abs(relativePos.x) > deadZone.x || Mathf.Abs(relativePos.y) > deadZone.y;
        }
    }
}
