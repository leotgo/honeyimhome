using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float speed;
    [SerializeField]
    Sprite hexagon;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        Debug.Log("Hexagon: " + hexagon.bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    void move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            gameObject.transform.Translate(new Vector2(transform.position.x + hexagon.bounds.size.x * Time.deltaTime, transform.position.y));
            Debug.Log(moveHorizontal);
        }

        //gameObject.transform.Translate(new Vector2(transform.position.x + moveHorizontal * speed * Time.deltaTime, transform.position.y));
    }
}
