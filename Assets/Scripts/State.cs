
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

    public void SetAnims(int input)
    {
        /*
        isRunning"     1 
        isIdle"        2
        isClimbing"    3  
        isJumping"     4
        isClimbingEnd" 5          
        isHammerRun"   6
        isHammerIdle"  7
        */
        if (input == 1)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 2)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 3)
        {
            anim.SetBool("isClimbing", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 4)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 5)
        {
            anim.SetBool("isClimbingEnd", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isHammerRun", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 6)
        {
            anim.SetBool("isHammerRun", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isClimbing", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isClimbingEnd", false);
            anim.SetBool("isHammerIdle", false);
        }
        if (input == 7)
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
