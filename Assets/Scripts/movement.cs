using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
using Helpers.Routine;
using Helpers;
*/
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

        //if (!hasMoved && (Mathf.Abs(moveHorizontal) > 0.1f || (Mathf.Abs(moveVertical) > 0.1f && Mathf.Abs(moveHorizontal) > 0.1f)))
        //{
            //if (moveHorizontal > 0f)
            //{
            //    // direita cima
            //    if (moveVertical > 0f)
            //        dir = new Vector3(1.0f, 1.0f, 0.0f).normalized;
            //    // direita baixo
            //    if (moveVertical < 0f)
            //        dir = new Vector3(1.0f, -1.0f, 0.0f).normalized;
            //    // direita
            //    if (Mathf.Abs(moveVertical) < 0.1f)
            //        dir = new Vector3(1.0f, 0.0f, 0.0f).normalized;
            //}
            //else
            //{
            //    // direita cima
            //    if (moveVertical > 0f)
            //        dir = new Vector3(-1.0f, 1.0f, 0.0f).normalized;
            //    // direita baixo
            //    if (moveVertical < 0f)
            //        dir = new Vector3(-1.0f, -1.0f, 0.0f).normalized;
            //    // direita
            //    if (Mathf.Abs(moveVertical) < 0.1f)
            //        dir = new Vector3(-1.0f, 0.0f, 0.0f).normalized;
            //}

            Debug.Log(dir * strength);
            GetComponent<Rigidbody2D>().AddForce(dir * strength, ForceMode2D.Force);
            hasMoved = true;
            //ActionHelper.Delay(1f, () => { hasMoved = false; });
        //}
    }
}
