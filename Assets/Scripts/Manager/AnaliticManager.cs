using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnaliticManager : MonoBehaviour
{
    public AnaliticManager m_Instance;
    private AnaliticManager m_instance;

    [Header("Analitics")]
    public int m_JumpTimes;
    public int m_ShootTimes;
    public int m_SpecialShootTimes;

    void Awake()
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

    public void AddJump()
    {
        m_JumpTimes++;
    }

    public void AddShoot()
    {
        m_ShootTimes++;
    }

    public void AddSpecialShoot()
    {
        m_SpecialShootTimes++;
    }
}
