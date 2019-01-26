using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers.Routine;
using Helpers;

public class movement : MonoBehaviour
{
    public float strength = 2.0f;
    float speed;
    [SerializeField]
    Sprite hexagon;

    bool hasMoved = false;
    float moveHorizontal;
    float moveVertical;


    void Start()
    {
        speed = 0.2f;
        hasMoved = false;
    }

    void Update()
    {
        move();

    }

    void move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        GetComponent<Rigidbody2D>().AddForce(dir * strength, ForceMode2D.Force);
        hasMoved = true;
    }
}
