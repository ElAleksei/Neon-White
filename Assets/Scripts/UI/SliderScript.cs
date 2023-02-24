using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public GameObject Slider1;
    public GameObject Slider2;

    public Slider m_slider1;
    public Slider m_slider2;

    public int MaxAmmo;
    public int CurrentAmmo;

    public SO_Weapons m_katana;
    public SO_Weapons m_gun;
    public SO_Weapons m_rifle;
    public SO_Weapons m_sniper;
    public SO_Weapons m_uzi;

    // Start is called before the first frame update
    void Start()
    {
        m_slider1 = Slider1.GetComponent<Slider>();
        m_slider2 = Slider2.GetComponent<Slider>();

        MaxAmmo = GameObject.Find("Player").GetComponent<WeaponDisplay>().m_MaxAmmo;
        CurrentAmmo = GameObject.Find("Player").GetComponent<WeaponDisplay>().m_CurrentAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        MaxAmmo = GameObject.Find("Player").GetComponent<WeaponDisplay>().m_MaxAmmo;
        CurrentAmmo = GameObject.Find("Player").GetComponent<WeaponDisplay>().m_CurrentAmmo;

        m_slider1.maxValue = MaxAmmo;
        m_slider1.value = CurrentAmmo;

        if (Slider2.transform.GetChild(0).gameObject.GetComponent<Image>().sprite.name == "Katana Card BW")
        {
            m_slider2.maxValue = m_katana.MaxAmmo;
            m_slider2.value = m_katana.CurrentAmmo;
        }

        if (Slider2.transform.GetChild(0).gameObject.GetComponent<Image>().sprite.name == "Elevate Card")
        {
            m_slider2.maxValue = m_gun.MaxAmmo;
            m_slider2.value = m_gun.CurrentAmmo;
        }
    }
}
