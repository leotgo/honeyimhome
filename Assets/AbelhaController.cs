using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class AbelhaController : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    public Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    public Vector2 movementvector;


    MyCharacterActions characterActions;

    void Start()
    {
        characterActions = new MyCharacterActions();

        characterActions.Left.AddDefaultBinding(Key.LeftArrow);
        characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        characterActions.Right.AddDefaultBinding(Key.RightArrow);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Right.AddDefaultBinding(Key.UpArrow);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Right.AddDefaultBinding(Key.DownArrow);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

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

    void PerformMove(float x, float y)
    {

        movementvector = new Vector2(x, y);
        /*
        if(y==1)
        {
            if (x == 1)
            {
               
            }
            if (x == -1)
            {

            }

        }

        if (y == -1)
        {
            if (x == 1)
            {

            }
            if (x == -1)
            {

            }

        }

        if (x == 1 && y==0)
        {

        }
        if (x == -1 && y==0)
        {

        }
        */

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(x*(-1), y);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);




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

