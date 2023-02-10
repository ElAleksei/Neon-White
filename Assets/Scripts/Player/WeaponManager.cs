using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    GameObject m_Card1;
    GameObject m_Card2;
    GameObject m_Card3;
    
    void Start()
    {
        m_Card1 = GameObject.Find("Slider");
        m_Card2 = GameObject.Find("Slider2");
    }

    // Update is called once per frame
    void Update()
    {
        m_Card2.GetComponentInChildren<Image>().sprite = null;
    }
}
