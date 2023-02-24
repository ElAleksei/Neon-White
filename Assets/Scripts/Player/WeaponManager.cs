using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    static GameObject m_Card1;
    static GameObject m_Card2;
    static GameObject m_CurrentCard;
    static GameObject m_OtherCard;

    GameObject m_Card1Background;
    GameObject m_Card1Fill;
    public static Image m_Card1Image;
    static Image m_Card1FillImage;

    GameObject m_Card2Background;
    GameObject m_Card2Fill;
    static Image m_Card2Image;
    static Image m_Card2FillImage;

    public SO_Weapons m_katana;
    public SO_Weapons m_gun;
    public SO_Weapons m_rifle;
    public SO_Weapons m_sniper;
    public SO_Weapons m_uzi;

    void Start()
    {
        m_Card1 = GameObject.Find("Slider");
        m_Card2 = GameObject.Find("Slider2");
        m_CurrentCard = m_Card1;
        m_OtherCard = m_Card2;

        m_Card1Background = m_Card1.transform.GetChild(0).gameObject;
        m_Card1Fill = m_Card1.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        m_Card1Image = m_Card1Background.GetComponent<Image>();
        m_Card1FillImage = m_Card1Fill.GetComponent<Image>();

        m_Card2Background = m_Card2.transform.GetChild(0).gameObject;
        m_Card2Fill = m_Card2.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        m_Card2Image = m_Card2Background.GetComponent<Image>();
        m_Card2FillImage = m_Card2Fill.GetComponent<Image>();

        m_katana.damage = 5;
        m_katana.range = 3;
        m_katana.fireRate = 1;
        m_katana.nextTimetoFire = 1;
        m_katana.MaxAmmo = 3;
        m_katana.CurrentAmmo = 3;
        m_katana.Discard = false;

        m_gun.damage = 50;
        m_gun.range = 10;
        m_gun.fireRate = 1;
        m_gun.nextTimetoFire = 1;
        m_gun.MaxAmmo = 20;
        m_gun.CurrentAmmo = 20;
        m_gun.Discard = false;
    }


    public static void Change()
    {
        if (m_CurrentCard == m_Card1 & m_Card2 != null)
        {
            Sprite Backup = m_Card1Image.sprite;
            Color ColorBackUp = m_Card1FillImage.color;

            m_Card1Image.sprite = m_Card2Image.sprite;
            m_Card1FillImage.sprite = m_Card2FillImage.sprite;
            m_Card1FillImage.color = m_Card2FillImage.color;

            m_Card2Image.sprite = Backup;
            m_Card2FillImage.sprite = Backup;
            m_Card2FillImage.color = ColorBackUp;

            m_CurrentCard = m_Card2;
            m_OtherCard = m_Card1;

        }

        else if (m_CurrentCard == m_Card2 & m_Card1 != null)
        {
            Sprite Backup = m_Card1Image.sprite;
            Color ColorBackUp = m_Card1FillImage.color;

            m_Card1Image.sprite = m_Card2Image.sprite;
            m_Card1FillImage.sprite = m_Card2FillImage.sprite;
            m_Card1FillImage.color = m_Card2FillImage.color;

            m_Card2Image.sprite = Backup;
            m_Card2FillImage.sprite = Backup;
            m_Card2FillImage.color = ColorBackUp;


            m_CurrentCard = m_Card1;
            m_OtherCard = m_Card2;
            
        }

        else
        {
            
        }
        
    }

    public static void NewCard(string Weapon)
    {
        if (m_CurrentCard == m_Card1 & m_Card2 == null)
        {
            
        }

        else if (m_CurrentCard == m_Card2 & m_Card1 == null)
        {

        }

        else
        {

        }
    }
}
