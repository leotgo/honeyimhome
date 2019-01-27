using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class AbelhaController : MonoBehaviour
{
    float speed=0.2f;             //Floating point variable to store the player's movement speed.
    public Vector2 movementvector;

    public float strength = 2.0f;
    public float angularSpeed = 5.0f;
    
    bool hasMoved = false;
    float moveHorizontal;
    float moveVertical;

    MyCharacterActions characterActions;
    player a_player;

    void Start()
    {
        a_player = GetComponent<player>();

        characterActions = new MyCharacterActions();

        characterActions.Left.AddDefaultBinding(Key.LeftArrow);
        characterActions.Left.AddDefaultBinding(Key.A);
        characterActions.Left.AddDefaultBinding(InputControlType.DPadLeft);

        characterActions.Right.AddDefaultBinding(Key.RightArrow);
        characterActions.Right.AddDefaultBinding(Key.D);
        characterActions.Right.AddDefaultBinding(InputControlType.DPadRight);

        characterActions.Up.AddDefaultBinding(Key.UpArrow);
        characterActions.Up.AddDefaultBinding(Key.W);
        characterActions.Up.AddDefaultBinding(InputControlType.DPadUp);

        characterActions.Down.AddDefaultBinding(Key.DownArrow);
        characterActions.Down.AddDefaultBinding(Key.S);
        characterActions.Down.AddDefaultBinding(InputControlType.DPadDown);

        characterActions.Action.AddDefaultBinding(Key.Space);
        characterActions.Action.AddDefaultBinding(InputControlType.Action1);

        
    }

    void Update()
    {
        if (characterActions.Action.WasPressed)
        {
            PerformAction();
        }

        // We use the aggregate filter action here.
        // It combines Left and Right into a single axis value
        // in the range -1 to +1.
        PerformMove(characterActions.MoveHorizontal.Value, characterActions.MoveVertical.Value);

    
    }

    void PerformAction()
    {
        a_player.Interact();
    }

    void PerformMove(float moveHorizontal, float moveVertical)
    {
        moveVertical = moveVertical * -1;
        movementvector = new Vector2(moveHorizontal, moveVertical);

        Vector3 dir = new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        if (dir.magnitude > 0.15f)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90f, Vector3.forward), angularSpeed * Time.deltaTime);
        }

        Vector3 moveDir = dir;
        GetComponent<Rigidbody2D>().AddForce(dir.magnitude * moveDir * strength, ForceMode2D.Force);
        hasMoved = true;
    }

    public class MyCharacterActions : PlayerActionSet
    {
        public PlayerAction Left;
        public PlayerAction Right;
        public PlayerAction Up;
        public PlayerAction Down;
        public PlayerAction Action;
        public PlayerOneAxisAction MoveHorizontal;
        public PlayerOneAxisAction MoveVertical;

        public MyCharacterActions()
        {
            Left = CreatePlayerAction("Move Left");
            Right = CreatePlayerAction("Move Right");
            Up = CreatePlayerAction("Move Up");
            Down = CreatePlayerAction("Move Down");
            Action = CreatePlayerAction("Action");
            MoveHorizontal = CreateOneAxisPlayerAction(Left, Right);
            MoveVertical = CreateOneAxisPlayerAction(Up, Down);
        }
    }

}

