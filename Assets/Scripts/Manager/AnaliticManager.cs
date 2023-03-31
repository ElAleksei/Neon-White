using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class AnaliticManager : MonoBehaviour
{
    public static AnaliticManager Instance { get; private set; }
    //private AnaliticManager m_instance;

    [Header("Analitics")]
    public int m_JumpTimes;
    public int m_ShootTimes;
    public int m_SpecialShootTimes;
    public int m_ChangeCardTimes;
    bool IsPlaying = true;
    public float m_PlayTime;
    public float m_InputTime;
    public int m_MimidoTimes;

    public GameObject m_Analitics;

    public string m_filename = "data.txt";

    void Awake()
    {
        m_Analitics = GameObject.Find("Analitics");
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    private void Start()
    {
        m_Analitics = GameObject.Find("Analitics");
    }

    private void Update()
    {
        if (IsPlaying)
        {
            TimeInGame();
        }
    }

    private void OnApplicationQuit()
    {
        string filepath = Path.Combine(Application.persistentDataPath, m_filename);
        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.Write(Serialize());
            writer.Write("\n");
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

    public void AddChangeCard()
    {
        m_ChangeCardTimes++;
    }

    public void TimeInGame()
    {        
        m_PlayTime += Time.deltaTime;
    }

    public void Amimir()
    {
        m_MimidoTimes++;
    }

    public void ShowAnalitics()
    {
        if (m_Analitics == null)
        {
            m_Analitics = GameObject.Find("Analitics");
        }

        TextMeshProUGUI Text = m_Analitics.GetComponent<TextMeshProUGUI>();
        Text.text = "Jump Times: " + m_JumpTimes + " Shoot Times: " + m_ShootTimes + " Special Shoot Times: " + m_SpecialShootTimes + " Change Card Times: " + m_ChangeCardTimes + " Playing Time: " + m_PlayTime + " Mimido Times: " + m_MimidoTimes;        
    }


    public string Serialize()
    {
        int Life = GameObject.Find("Player").GetComponent<PlayerManager>().m_PlayerLife;
        return string.Format("{0},{1},{2},{3},{4},{5},{6}", m_JumpTimes, m_ShootTimes, m_SpecialShootTimes, m_ChangeCardTimes, m_PlayTime, m_MimidoTimes,Life);
    }
    
}
