using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPrefabs : MonoBehaviour
{
    string m_CardName;

    public SO_Weapons m_katana;
    public SO_Weapons m_gun;
    public SO_Weapons m_rifle;
    public SO_Weapons m_sniper;
    public SO_Weapons m_uzi;

    // Start is called before the first frame update
    void Start()
    {
        m_CardName = GetComponent<MeshRenderer>().material.name;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0,0.2f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {   
            if(m_CardName == "Katana Card 3 (Instance)")
            {
                m_katana.CurrentAmmo = m_katana.MaxAmmo;
            }

            if (m_CardName == "Elevate Card (Instance)")
            {
                m_gun.CurrentAmmo = m_gun.MaxAmmo;
            }

            Destroy(gameObject);
        }
    }
}
