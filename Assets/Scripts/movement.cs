using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    float speed;
    [SerializeField]
    Sprite hexagon;

    bool canMove;
    float moveHorizontal;
    float moveVertical;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.2f;
        canMove = true;
        //Debug.Log("Hexagon: " + hexagon.bounds.size.x);
    }

    // Update is called once per frame
    void Update()
    {
        move();
        
    }

    void move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Debug.Log("moveHorizontal: " + moveHorizontal);
            StartCoroutine("moveTo");
        }

        //gameObject.transform.Translate(new Vector2(transform.position.x + moveHorizontal * speed * Time.deltaTime, transform.position.y));
    }

    IEnumerator moveTo()
    {
        if (canMove)
        {
            if(Input.GetAxis("Horizontal") > 0.0f)
            {
                //gameObject.transform.Translate(new Vector2(transform.position.x + hexagon.bounds.size.x, transform.position.y));
                transform.position += new Vector3(hexagon.bounds.size.x, 0, 0);
                Debug.Log("DIREITA");
            }
            else if(Input.GetAxis("Horizontal") < 0.0f)
            {
                //gameObject.transform.Translate(new Vector2(transform.position.x - hexagon.bounds.size.x, transform.position.y));
                transform.position -= new Vector3(hexagon.bounds.size.x, 0, 0);
                Debug.Log("ESQUERDA");
            }

            if (Input.GetAxis("Vertical") > 0.0f)
            {
                //gameObject.transform.Translate(new Vector2(transform.position.x, transform.position.y + hexagon.bounds.size.y));
                transform.position += new Vector3(0, hexagon.bounds.size.y, 0);
                Debug.Log("CIMA");
            }
            else if (Input.GetAxis("Vertical") < 0.0f)
            {
                //gameObject.transform.Translate(new Vector2(transform.position.x, transform.position.y - hexagon.bounds.size.y));
                transform.position -= new Vector3(0, hexagon.bounds.size.y, 0);
                Debug.Log("BAIXO");
            }

        }

        canMove = false;

        yield return new WaitForSeconds(1.0f);

        canMove = true;
    }
}
