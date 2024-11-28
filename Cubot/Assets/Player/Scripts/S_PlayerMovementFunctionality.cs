using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementFunctionality : MovementFunctionality
{
    //expanded movement functionality for this specfic context
    [Header("Bounce values")]

    [SerializeField] float m_walkDirection = 1;
    public Vector2 m_BounceForce;

    [Header("WallJump values")]
    [SerializeField] float m_wallJumpWindowLength;
    [SerializeField] float m_wallJumpWindowCounter;
    [SerializeField] Vector2 m_wallJumpForce;
    [SerializeField] protected Transform m_wallJumpCheck;

    [Header("Spring values")]
    [SerializeField] LayerMask m_springLayer;
    [SerializeField] Transform m_SpringYJumpCheck;
    [SerializeField] bool m_canSpringX;
    [SerializeField] bool m_canSpringY;
    [SerializeField] Vector2 m_springForce;
    float m_extraXvalue;
    [SerializeField] float m_upDown;


    [Header("Misc")]
    [SerializeField] GameObject m_echoSprite;
    bool m_canBounce;
    bool m_canWallJump;
    
    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        CheckOverlapBooleans();
        WallJumpCounterFunct();
        CoyoteTimeFunc();
        PlayerMoving(m_extraXvalue);
     
    }

    public override void JumpBufferUpdate()
    {
        base.JumpBufferUpdate();

        if (m_JumpBufferCounter > 0 && m_canWallJump)
        {
            m_coyoteTimeCounter = m_JumpBufferLength;
            JumpStart();
        }
    }

    public override void CheckOverlapBooleans()
    {
        base.CheckOverlapBooleans();

        if (RB.velocity.y <= 0)
        {
            m_upDown = -1;
        }
        else
        {
            m_upDown = 1;
        }
        
        m_canSpringX = Physics2D.Raycast(
            m_wallJumpCheck.position, new Vector2(m_walkDirection, 0f), 1f, m_springLayer);
        m_canSpringY = Physics2D.OverlapBox(m_SpringYJumpCheck.position, new Vector2(0.9f, 0.3f * m_upDown), 0);
       
    }

    public override void CoyoteTimeFunc()
    {
        JumpBufferUpdate();
        base.CoyoteTimeFunc();
        m_canWallJump = Physics2D.Raycast(
            m_wallJumpCheck.position, new Vector2(m_walkDirection, 0f), 0.7f, m_standableLayer);
    }


    private void WallJumpCounterFunct()
    {

        if(m_canWallJump && !m_isGrounded)
        {
            m_wallJumpWindowCounter = m_wallJumpWindowLength;
        }
        else
        {
            m_wallJumpWindowCounter -= Time.deltaTime;
        }
    }

    public override void JumpStart()
    {
        base.JumpStart();

        if(m_wallJumpWindowCounter > 0f) 
        {
            WallJump();
            
        }
    }

    public void WallJump()
    {
        RB.velocity = new Vector2(RB.velocity.x
            ,m_wallJumpForce.y * m_frameFixMultiplier);
    }

    public override void PlayerMoving(float _extraXvalue)
    {
 
           base.PlayerMoving(0);
    

   

        m_canBounce = Physics2D.Raycast(
            m_bounceCheck.position, new Vector2(m_walkDirection, 0), 0.5f, m_standableLayer);

        //flip the player when they hit a wall
        if (m_canBounce)
        {

            m_walkDirection *= -1;
            Bounce();
        }

        Walking(m_walkDirection);

        
    }
    
        
    public void Bounce()
    {
        //simulate a little bounce off the wall
        RB.AddForce(new Vector2(m_BounceForce.x * m_frameFixMultiplier, 0), ForceMode2D.Impulse);
       
    }

    public void SpringBounce()
    {

       if(m_canSpringX)
       {
           m_walkDirection *= -1;

       }    
       if(m_canSpringY)
        {
            RB.velocity = new Vector2(RB.velocity.x
            ,m_springForce.y * m_frameFixMultiplier * -m_upDown);
            print("bounce");
        }
            
        
      
        
    }

    public override void FlipSprite()
    {

        
        base.FlipSprite();
    }

}
