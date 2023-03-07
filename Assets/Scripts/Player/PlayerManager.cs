using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public int m_PlayerLife;
    public GameObject m_Life1;
    public GameObject m_Life2;
    public GameObject m_Life3;

    public Image m_DamageOverlay;
    public float m_OverlayDuration;
    public float m_OverlayDelay;
    private float m_Timer;

    // Start is called before the first frame update
    void Start()
    {
        m_DamageOverlay.color = new Color(m_DamageOverlay.color.r, m_DamageOverlay.color.g, m_DamageOverlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PlayerLife <= 0)
        {
            Destroy(gameObject);
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

}
