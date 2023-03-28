using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

/// <summary>
/// Este es el bueno xd
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    //Movement variables
    public float m_Speed = 5f;
    Vector2 m_MoveInput;
    public Rigidbody m_Rigidbody;
    //Jumping variables
    public float m_JumpSpeed = 5f;
    bool m_IsOnGround = true;
    //WallRunVariables
    public float WallRunSpeed;

    public WeaponDisplay m_WeaponDisplay;

    [Header("Sound")]
    public AudioSource [] m_AudioSource;

    //[Header("Analitics")]
    //public AnaliticManager m_AnaliticManager;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //m_AnaliticManager = GameObject.Find("AnaliticsManager").GetComponent<AnaliticManager>();
        //Debug.Log(m_Rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.X) && SceneManager.GetActiveScene().name != "Title" && SceneManager.GetActiveScene().name != "FinishScene")
        {
            AnaliticManager.Instance.ShowAnalitics();
        }
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
            m_AudioSource[0].Play();
            m_IsOnGround = false;
            AnaliticManager.Instance.AddJump();
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

    void OnChangeCard()
    {
        WeaponManager.Change();
        m_WeaponDisplay.ChangeCard();
    }

    
}
