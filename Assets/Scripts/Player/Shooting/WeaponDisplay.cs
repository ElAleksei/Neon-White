using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public int m_damage;
    public float m_range;
    public float m_fireRate;
    public float m_nextTimetoFire;
    public int m_MaxAmmo;
    public int m_CurrentAmmo;
    public bool m_Discard;
    bool m_AlreadyFire2 = false;

    public SO_Weapons weapon;
    public Camera FPScam;
    public Rigidbody rb;

    public Component CurrentScript;

    Image CurrentCard;

    // Start is called before the first frame update
    void Start()
    {
        CurrentCard = GameObject.Find("Slider").transform.GetChild(0).gameObject.GetComponent<Image>();

        m_damage = weapon.damage;
        m_range = weapon.range;
        m_fireRate = weapon.fireRate;
        m_nextTimetoFire = weapon.nextTimetoFire;
        m_MaxAmmo = weapon.MaxAmmo;
        m_CurrentAmmo = weapon.CurrentAmmo;
        m_Discard = weapon.Discard;
    
    }

    private void Update()
    {
        m_damage = weapon.damage;
        m_range = weapon.range;
        m_fireRate = weapon.fireRate;
        m_nextTimetoFire = weapon.nextTimetoFire;
        m_MaxAmmo = weapon.MaxAmmo;
        m_CurrentAmmo = weapon.CurrentAmmo;
        m_Discard = weapon.Discard;
    }

    public void ChangeCard()
    {
        if (CurrentCard.sprite.name == "Elevate Card")
        {
            weapon = Resources.Load("Weapon_") as SO_Weapons;
            ChangeStats();
        }

        else if (CurrentCard.sprite.name == "Katana Card BW")
        {
            weapon = Resources.Load("Weapon_Katana") as SO_Weapons;
            ChangeStats();
        }
    }

    void Shoot()
    {
        if(m_CurrentAmmo > 0)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, m_range))
            {

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(m_damage);
                    
                }

            }

            m_CurrentAmmo -= 1;
            weapon.CurrentAmmo = m_CurrentAmmo;
        }       

    }

    void OnFire1()
    {
        if (Time.time >= m_nextTimetoFire)
        {
            m_nextTimetoFire = Time.time + 1f / m_fireRate;
            Shoot();
        }

        //rb.AddForce(transform.forward * 500f, ForceMode.Impulse);
    }

    void OnFire2()
    {
        if(CurrentCard.sprite.name == "Elevate Card")
        {
            if (m_AlreadyFire2 == false)
            {
                if (rb.velocity.y < 0f)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                }

                rb.AddForce(0f, 8f, 0f, ForceMode.Impulse);
                m_AlreadyFire2 = true;
            }
        }
        
        else if(CurrentCard.sprite.name == "Godspeed Card")
        {
            CurrentScript = Resources.Load("RifleCopy") as Component;            
        }

        else
        {
            Debug.Log("Not gun");
        }
    }

    void ChangeStats()
    {
        m_damage = weapon.damage;
        m_range = weapon.range;
        m_fireRate = weapon.fireRate;
        m_nextTimetoFire = weapon.nextTimetoFire;
        m_MaxAmmo = weapon.MaxAmmo;
        m_CurrentAmmo = weapon.CurrentAmmo;
        m_Discard = weapon.Discard;
    }
}
