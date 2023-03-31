using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerManager : MonoBehaviour
{
    public GameObject m_Player;

    [Header("Life")]
    public int m_PlayerLife;
    public GameObject m_Life1;
    public GameObject m_Life2;
    public GameObject m_Life3;

    [Header("Damage UI")]
    public Image m_DamageOverlay;
    public float m_OverlayDuration;
    public float m_OverlayDelay;
    private float m_Timer;

    public string m_filename = "data.txt";

    // Start is called before the first frame update
    void Start()
    {
        m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, 0);
        Desirialize();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PlayerLife <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            AnaliticManager.Instance.Amimir();
            SceneManager.LoadScene("Title");
        }

        if (m_DamageOverlay.color.a > 0)
        {
            m_Timer += Time.deltaTime;

            if (m_Timer > m_OverlayDuration)
            {
                float TempAlpha = m_DamageOverlay.color.a;
                TempAlpha -= Time.deltaTime * m_OverlayDelay;
                m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, TempAlpha);
            }
        }

        if(m_Player.transform.position.y <= -10 && SceneManager.GetActiveScene().name == "Scene_Alek")
        {
            m_PlayerLife--;
            ChangeLife();
            m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, 1);
            m_Player.transform.position = new Vector3(-0.08092921f, 1.2f, -13.21809f);
        }

        if (m_Player.transform.position.y <= -10 && SceneManager.GetActiveScene().name == "Scene_Douglas")
        {
            m_PlayerLife--;
            ChangeLife();
            m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, 1);
            m_Player.transform.position = new Vector3(0, 1.2f, -7.77f);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        m_Timer = 0;
        if (collision.gameObject.tag == "Bullet")
        {
            m_PlayerLife -= 1;
            ChangeLife();    
            m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, 1);
        }
    }

    void ChangeLife()
    {
        if(m_PlayerLife == 2)
        {
            m_Life3.GetComponent<Image>().color = Color.black;
        }

        if (m_PlayerLife == 1)
        {
            m_Life2.GetComponent<Image>().color = Color.black;
        }

        if (m_PlayerLife == 0)
        {
            m_Life1.GetComponent<Image>().color = Color.black;
        }
    }

    public void Desirialize()
    {
        string filePath = Path.Combine(Application.persistentDataPath, m_filename);

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string data = reader.ReadToEnd();
                string[] words = data.Split(',');
                m_PlayerLife = int.Parse(words[6]);
                ChangeLife();
            }
        }

    }

    
}
