using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputManager m_Instance;
    private PlayerInput m_playerInput;
    private PlayerInput m_inputLayouts;

    [Header("Analitics")]
    public int m_JumpTimes;
    public int m_ShootTimes;

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
    }

    void AddJump()
    {

    }
}
