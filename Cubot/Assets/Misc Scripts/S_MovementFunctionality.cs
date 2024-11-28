using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementFunctionality : MonoBehaviour
{
    //basic movement functionality 

    protected float m_frameFixMultiplier;

    [Header("Layers for collision detection")]
    [SerializeField] protected Transform m_groundCheck;
    [SerializeField] protected LayerMask m_standableLayer;
    [SerializeField] protected Transform m_bounceCheck;


    [Header("Desired framerate")]
    [SerializeField] float m_frameRate = 60f;

    [Header("X movement info")]
    [SerializeField] protected Vector2 m_playerSpeed;
    [SerializeField] protected float m_coyoteTimeLength;
    protected float m_coyoteTimeCounter;



    [Header("Y movmement info")]
    [SerializeField] protected float m_jumpPower;
    [SerializeField] float m_horizontal;
    [SerializeField] bool m_isFacingRight;
    [SerializeField] protected float m_JumpBufferLength;
    [SerializeField] protected float m_JumpBufferCounter;


    [Header("Misc")]

    [SerializeField] Vector2 m_playerMove;
    [SerializeField] Rigidbody2D m_rb;
    [SerializeField]  protected bool m_isGrounded;

    
    public Rigidbody2D RB => m_rb;
    public float JumpPower => m_jumpPower;

    public bool IsFacingRight => m_isFacingRight;

    public Vector2 PlayerMove => m_playerMove;

    // Update is called once per frame

    public virtual void PlayerMoving(float _extraValueX)
    {
        m_frameFixMultiplier = m_frameRate * Time.deltaTime;
        m_rb.velocity = (new Vector2((m_horizontal * m_playerSpeed.x * m_frameFixMultiplier) + _extraValueX, m_rb.velocity.y));
    }




    protected void Walking(float _horizontal)
    {
        m_horizontal = _horizontal;

        if (m_isFacingRight && m_horizontal > 0)
        {
            FlipSprite();
        }
        else if (!m_isFacingRight && m_horizontal < 0)
        {
            FlipSprite();
        }
    }

    public virtual void CheckOverlapBooleans()
    {
        m_isGrounded = Physics2D.Raycast(m_groundCheck.position, new Vector2(0, -1f), 0.4f, m_standableLayer);
          
    }
    
    public void JumpBufferCheck()
    {
        if(!m_isGrounded)
        {
            m_JumpBufferCounter = m_JumpBufferLength;
        }
    }

    public virtual void JumpBufferUpdate()
    {
        m_JumpBufferCounter -= Time.deltaTime;

        if(m_JumpBufferCounter > 0 && m_isGrounded)
        {
            m_coyoteTimeCounter = m_JumpBufferLength;
            JumpStart();
        }

    }

    public virtual void JumpStart()
    {
        JumpBufferCheck();

        if ((m_coyoteTimeCounter > 0f))
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, m_jumpPower * m_frameFixMultiplier);
        }
    }

    public void JumpFinish()
    {
        m_coyoteTimeCounter = 0f;
    }


    public virtual void FlipSprite()
    {
        
        m_isFacingRight = !m_isFacingRight;
        Vector3 m_localScale = transform.localScale;
        m_localScale.x *= -1f;
        transform.localScale = m_localScale;

    }

    public virtual void CoyoteTimeFunc()
    {
       

        if (m_isGrounded)
        {
            m_coyoteTimeCounter = m_coyoteTimeLength;
        }
        else
        {
            m_coyoteTimeCounter -= Time.deltaTime;
        }



    }

    public void ClearVelocity()
    {
        m_rb.velocity = new Vector2 (0f, 0f);
    }

    private void OnDisable()
    {

    }


}
