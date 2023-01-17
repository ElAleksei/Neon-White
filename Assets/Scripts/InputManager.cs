using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager m_Instance;
    public static PlayerInput m_playerInput;
    public PlayerInput m_inputLayouts;
    
    void Start()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(m_Instance);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        m_playerInput = m_inputLayouts;
    }

    void Update()
    {
        
    }

    public static float MoveHorizontal()
    {
        return m_playerInput.actions.FindAction("Move").ReadValue<Vector2>().x;
    }

    public static float MoveVertical()
    {
        return m_playerInput.actions.FindAction("Move").ReadValue<Vector2>().y;
    }

    public static bool OnJump()
    {
        return true;
    }
}
