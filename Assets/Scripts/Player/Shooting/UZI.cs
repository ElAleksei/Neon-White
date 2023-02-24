using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : MonoBehaviour
{
    //public SO_Weapons = 
    public float damage = 10f;
    public float range = 100f;
    public Camera FPScam;
    public float fireRate = 30f;
    public bool Discard = false;

    public Rigidbody rb;

    private float nextTimetoFire = 0f;

    bool m_AlreadyFire2 = false;

    void Update()
    {

    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPScam.transform.position, FPScam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    void OnFire1()
    {
        if (Time.time >= nextTimetoFire)
        {
            nextTimetoFire = Time.time + 1f / fireRate;
            Shoot();
        }

        //rb.AddForce(transform.forward * 500f, ForceMode.Impulse);
    }

    void OnFire2()
    {

        Discard = true;

        if (Discard == true)
        {
            Debug.Log("Entró");
            rb.AddForce(0f, -8f, 0f, ForceMode.Impulse);

        }


        if (m_AlreadyFire2 == false)
        {
            rb.AddForce(0f, -8f, 0f, ForceMode.Impulse);
            m_AlreadyFire2 = true;
        }


    }
}
