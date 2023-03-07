using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    GameManager m_GameManager;

    private void Awake()
    {
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (m_GameManager.m_EnemyCount >= 3)
            {
                SceneManager.LoadScene("FinishScene");
            }
        }
    }

}
