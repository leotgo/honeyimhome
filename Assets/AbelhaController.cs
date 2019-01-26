using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class AbelhaController : MonoBehaviour
{
    float speed=0.2f;             //Floating point variable to store the player's movement speed.
    public Vector2 movementvector;

    public float strength = 2.0f;
    [SerializeField]
    Sprite hexagon;

    bool hasMoved = false;
    float moveHorizontal;
    float moveVertical;

    MyCharacterActions characterActions;

    void Start()
    {
        characterActions = new MyCharacterActions();

        characterActions.Left.AddDefaultBinding(Key.LeftArrow);
        characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        characterActions.Right.AddDefaultBinding(Key.RightArrow);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Up.AddDefaultBinding(Key.UpArrow);
        characterActions.Up.AddDefaultBinding(InputControlType.DPadUp);

        characterActions.Down.AddDefaultBinding(Key.DownArrow);
        characterActions.Down.AddDefaultBinding(InputControlType.DPadDown);

        characterActions.Jump.AddDefaultBinding(Key.Space);
        characterActions.Jump.AddDefaultBinding(InputControlType.Action1);
    }

    void Update()
    {
        if (characterActions.Jump.WasPressed)
        {
            PerformJump();
        }

        // We use the aggregate filter action here.
        // It combines Left and Right into a single axis value
        // in the range -1 to +1.
        PerformMove(characterActions.MoveHorizontal.Value, characterActions.MoveVertical.Value);

    
    }

    void PerformJump()
    {
        // ...
    }

    void PerformMove(float moveHorizontal, float moveVertical)
    {
        moveVertical = moveVertical * -1;
        movementvector = new Vector2(moveHorizontal, moveVertical);

        /* 
         //Use the two store floats to create a new Vector2 variable movement.
         Vector2 movement = new Vector2(x*(-1), y);

         //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
         rb2d.AddForce(movement * speed);
         */

        Vector3 dir = new Vector3(moveHorizontal, moveVertical, 0f).normalized;
        Debug.Log(dir * strength);
        GetComponent<Rigidbody2D>().AddForce(dir * strength, ForceMode2D.Force);
        hasMoved = true;


    }

    public class MyCharacterActions : PlayerActionSet
    {
        public PlayerAction Left;
        public PlayerAction Right;
        public PlayerAction Up;
        public PlayerAction Down;
        public PlayerAction Jump;
        public PlayerOneAxisAction MoveHorizontal;
        public PlayerOneAxisAction MoveVertical;

        public MyCharacterActions()
        {
            Left = CreatePlayerAction("Move Left");
            Right = CreatePlayerAction("Move Right");
            Up = CreatePlayerAction("Move Up");
            Down = CreatePlayerAction("Move Down");
            Jump = CreatePlayerAction("Jump");
            MoveHorizontal = CreateOneAxisPlayerAction(Left, Right);
            MoveVertical = CreateOneAxisPlayerAction(Up, Down);
        }
    }

}

