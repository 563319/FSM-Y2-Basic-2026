
//This is the base class 
// It defines the common methods and fields that all other states inherit
// You can include methods that you want to allow other states to use here

using UnityEngine;

public abstract class State
{
    protected PlayerScript player;
    protected StateMachine sm;

    protected Animator anim;

    public float verticalInput;
    public float horizontalInput;


    // base constructor
    public State(PlayerScript player, StateMachine sm)
    {
        this.player = player;
        this.sm = sm;
    }

    //methods that can be overriden by each state
    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
    public virtual void Exit() { }
    public virtual void OnCollisionEnter2D(Collision2D collision) { }
    public virtual void OnTriggerEnter2D(Collider2D collision) { }
    public virtual void OnTriggerExit2D(Collider2D collision) { }

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

    public void SetAnims(string input)
    {
 
        if (input == "running")
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "idle")
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "climbing")
        {
            anim.SetBool("isClimbing", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "jumping")
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "climbingEnd")
        {
            anim.SetBool("isClimbingEnd", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "hammerRun")
        {
            anim.SetBool("isHammerRun", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == "hammerIdle")
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
