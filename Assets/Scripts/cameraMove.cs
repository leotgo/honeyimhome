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

    public LayerMask camBoundMask;

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

        var leftPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 0.5f, 0.0f));
        var rightPoint = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0.5f, 0.0f));
        var bottomPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1.0f, 0.0f));
        var topPoint = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.0f, 0.0f));

        var collLeft = Physics2D.OverlapPoint(leftPoint, camBoundMask.value);
        var collRight = Physics2D.OverlapPoint(rightPoint, camBoundMask.value);
        var collTop = Physics2D.OverlapPoint(topPoint, camBoundMask.value);
        var collBottom = Physics2D.OverlapPoint(bottomPoint, camBoundMask.value);

        if (isAdjusting)
        {
            Vector3 playerPos = new Vector3(target.position.x, target.position.y, transform.position.z);
            var targetPos = playerPos;
            if ((relativePos.x < 0f && collRight != null) || (relativePos.x > 0f && collLeft != null))
                targetPos = new Vector3(transform.position.x, targetPos.y, targetPos.z);
            if ((relativePos.y < 0f && collBottom != null) || (relativePos.y > 0f && collTop != null))
                targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);

            transform.position = Vector3.Slerp(transform.position, targetPos, speed * Time.deltaTime);

            if (Mathf.Abs(relativePos.x) < adjustingStopZone.x && Mathf.Abs(relativePos.y) < adjustingStopZone.y)
                isAdjusting = false;
        }
        else
        {
            isAdjusting = Mathf.Abs(relativePos.x) > deadZone.x || Mathf.Abs(relativePos.y) > deadZone.y;
        }
    }
}
