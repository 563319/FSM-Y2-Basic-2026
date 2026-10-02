using UnityEngine;

public class RunHammerState : State
{

    protected float speed;
    protected float rotationSpeed;

    public RunHammerState(PlayerScript player, StateMachine sm) : base(player, sm)
    {
    }

    public override void Enter()
    {
        if (sm.lastState == sm.runState)
        {
            hammerTimer = hammerTimeMax;

        }

        speed = 3;
        base.Enter();
        horizontalInput = verticalInput = 0.0f;

        Debug.Log("entering running hammer state");

        //player.sr.color = new Color(0.8f, 0.8f, 0.2f);
        //player.sr.sprite = player.runHammerSpr;
    }

    public override void Exit()
    {
        //player.hammer.SetActive(false);
        
        base.Exit();
    }



    public override void Update()
    {
        SetAnims("hammerRun");
        TestMethod("hello");
        FlipPlr();
        GroundCheck(-0.3f, 0);
        GroundCheck(0.3f, 0);
        //player.hammer.SetActive(true);


        ReadInput();
       
        if (hammerTimer > 0.1)
        {
            hammerTimer -= Time.deltaTime;
            if (player.moveAction.ReadValue<Vector2>().magnitude < 0.1f)
            {
                sm.ChangeState(sm.idleHammerState);
            }
        }
        else
        {
            if (player.moveAction.ReadValue<Vector2>().magnitude < 0.1f)
            {
                sm.ChangeState(sm.idleState);
            }
            if (player.moveAction.ReadValue<Vector2>().magnitude > 0.1f)
            {
                sm.ChangeState(sm.runState);
            }
        }


        //debug move gameObject
        //player.rb.linearVelocity = player.moveAction.ReadValue<Vector2>() * speed;
        player.rb.linearVelocityX = player.moveAction.ReadValue<Vector2>().x * speed;

        UIscript.ui.DrawText("*** This is the running hammer state ***\n");
        UIscript.ui.DrawText("Left/Right arrows = Move Sprite");
        UIscript.ui.DrawText("E = Idle State");
        UIscript.ui.DrawText("Space = Jump state");



    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("collided in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        }
    }
    public override void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit collision in runstate");

        if (collision.tag == "enemy")
        {
            collision.GetComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f);
        }
    }



    public override void FixedUpdate()
    {
    }
}
