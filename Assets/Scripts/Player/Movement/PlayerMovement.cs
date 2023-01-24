using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Este es el bueno xd
/// </summary>
public class PlayerMovement : MonoBehaviour
{

    //Movement variables
    public float m_Speed = 5f;
    Vector2 m_MoveInput;
    Rigidbody m_Rigidbody;

    //Jumping variables
    public float m_JumpSpeed = 5f;
    bool m_IsOnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Walk();
    
    }

    void Walk()
    {
        Vector3 PlayerVelocity = new Vector3 (m_MoveInput.x * m_Speed,m_Rigidbody.velocity.y, m_MoveInput.y * m_Speed);
        m_Rigidbody.velocity = transform.TransformDirection(PlayerVelocity);
    }

    void OnJump()
    {
        if (m_IsOnGround)
        {
            m_Rigidbody.AddForce(new Vector3(0, m_JumpSpeed, 0), ForceMode.Impulse);
            m_IsOnGround = false;
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_IsOnGround = true;
        }
    }

    void OnMove(InputValue value)
    {
        m_MoveInput = value.Get<Vector2>();
    }

    
}
