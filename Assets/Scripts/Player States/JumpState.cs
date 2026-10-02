//This is a derived class of State
//This means it inherits fields and methods from State.cs



using UnityEngine;

public class JumpState : State
{
    float rotationSpeed;

    
    public JumpState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        Debug.Log("entering jumping state");
        player.rb.linearVelocityY = 10f;
        groundLayerMask = LayerMask.GetMask("Ground");
        playerHasJumped = true;
        //player.sr.color = new Color(0.8f, 0.3f, 0.4f);  //change the sprite colour
        //player.sr.sprite = player.jumpSpr;
    }

    public override void Exit()
    {
        playerHasJumped = false;
        //exit the jump state
    }

    public override void Update()
    {
        GroundCheck(-0.3f, 0);
        GroundCheck(0.3f, 0);
        SetAnims("jumping");
        FlipPlr();
        Debug.Log("is plr touching ground: " + isOnGround);
        if (isGrounded == true && playerHasJumped)
        {
            sm.ChangeState(sm.idleState);

            if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
            {
               //  sm.ChangeState(sm.runState);
            }


        }

        UIscript.ui.DrawText("*** This is the jumping state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move State");
        UIscript.ui.DrawText("E = Idle State");


    }

    public override void FixedUpdate()
    {
        //Fixed Update 
    }
    /*
    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
           
    }
    public override void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
    */
}
