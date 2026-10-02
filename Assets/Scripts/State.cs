
//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public abstract class State
{
    protected PlayerScript player;
    protected StateMachine sm;

    protected Animator anim;

    public float verticalInput;
    public float horizontalInput;

    protected float hammerTimer = 6;
    protected bool isOnGround;
    protected LayerMask groundLayerMask;
    protected bool result;
    protected bool isGrounded;
    protected bool playerHasJumped;

    protected GameObject playerEmpty;
    //protected GameObject hammer;


    // base constructor
    public State(PlayerScript player, StateMachine sm)
    {
        this.player = player;
        this.sm = sm;
        this.anim = player.GetComponent<Animator>();
    }

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnTriggerEnter2D(Collider2D collision) { }
    public virtual void OnTriggerExit2D(Collider2D collision) { }
    public virtual void OnCollisionStay2D(Collision2D collision) { }
    public virtual void OnCollisionExit2D(Collision2D collision) { }

    //Common Shared Methods
    //Put methods that you wish to share between other states here
    //Set them to be public
    public void TestMethod(string text)
    {
        Debug.Log(text);
    }
    public void ReadInput()
    {
    }
    public void GroundCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.1f; // length of raycast
        bool hitSomething = false;
        //float xoffs = 0f;
        //float yoffs = 0f;
        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward starting at the sprite's position
        RaycastHit2D hit;

        hit = Physics2D.Raycast(player.transform.position + offset, Vector2.down, rayLength, groundLayerMask);

        Color hitColor = Color.cyan;


        if (hit.collider != null)
        {
            Debug.Log("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray's position
        // You need to enable gizmos in th e editor to see these
        Debug.DrawRay(player.transform.position + offset, Vector2.down * rayLength, hitColor);
        //return hitSomething;
        isGrounded = hitSomething;

    }
    
    public void FlipPlr()
    {
        playerEmpty = GameObject.FindGameObjectWithTag("PlayerEmpty");
        if (player.rb.linearVelocityX > 0)
        {
            //player.sr.flipX = false;
            //player.hammer.transform.Rotate(new Vector3(0, -180, 0));
            //player.hammer.GetComponent<SpriteRenderer>().flipX = false;
            playerEmpty.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (player.rb.linearVelocityX < 0)
        {
            //player.sr.flipX = true;
            //player.hammer.transform.Rotate(new Vector3(0, -180, 0));
            //player.hammer.GetComponent<SpriteRenderer>().flipX = true;
            playerEmpty.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        
    }
  

    public void SetAnims(string input)
    {
 
        if (input == "running" && anim.GetBool("isRunning") == false)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "idle" && anim.GetBool("isIdle") == false)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "climbing" && anim.GetBool("isClimbing") == false)
        {
            anim.SetBool("isClimbing", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "jumping" && anim.GetBool("isJumping") == false)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "climbingEnd" && anim.GetBool("isClimbingEnd") == false)
        {
            anim.SetBool("isClimbingEnd", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "hammerRun" && anim.GetBool("isHammerRun") == false)
        {
            anim.SetBool("isHammerRun", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "hammerIdle" && anim.GetBool("isHammerIdle") == false)
        {
            anim.SetBool("isHammerIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
        }


    }



}
