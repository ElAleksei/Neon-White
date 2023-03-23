using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    //public Rigidbody m_Player_body;
    //
    ////Movement variables
    //public float m_Velocity = 2;
    //public float m_dir;
    //public float m_HorizontalMove;
    //public float m_VerticalMove;
    //
    ////Jump variables
    //public bool m_OnJump;
    //public bool m_OnGround;
    //public Rigidbody _floor;
    //
    //void Start()
    //{
    //    
    //}
    //
    //
    //void Update()
    //{
    //    //Instances of Action Map functions
    //    m_HorizontalMove = InputManager.MoveHorizontal();
    //    m_VerticalMove = InputManager.MoveVertical();
    //    m_OnJump = InputManager.OnJump();
    //
    //
    //    //Moving character
    //    if (m_HorizontalMove > 0.1 || m_HorizontalMove < 0.01)
    //    {
    //        m_dir = m_HorizontalMove * m_Velocity * Time.deltaTime;
    //        m_Player_body.AddForce(new Vector3(m_dir, 0, 0), ForceMode.Impulse);
    //    }
    //    else
    //    {
    //
    //        m_Player_body.AddForce(-m_Player_body.velocity);
    //    }
    //
    //    if (m_VerticalMove > 0.1 || m_VerticalMove < 0.01)
    //    {
    //        m_dir = m_VerticalMove * m_Velocity * Time.deltaTime;
    //        m_Player_body.AddForce(new Vector3(0, 0, m_dir), ForceMode.Impulse);
    //    }
    //    else
    //    {
    //
    //        m_Player_body.AddForce(-m_Player_body.velocity);
    //    }
    //
    //    
    //
    //    //Character jumping
    //    if (m_OnJump & m_OnGround == true)
    //    {
    //        m_Player_body.AddForce(new Vector3(0, 0, 0), ForceMode.Impulse);
    //        m_OnGround = false;
    //    }
    //}
    //
    //void OnCollisionEnter(Collision collision)
    //{
    //
    //    if (collision.gameObject.name == "Floor")
    //    {
    //        m_OnGround = true;
    //    }
    //}
}
