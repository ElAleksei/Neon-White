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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PlayerLife <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            m_PlayerLife -= 1;
            ChangeLife();
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
