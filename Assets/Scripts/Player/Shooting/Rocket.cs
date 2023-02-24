using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    //public SO_Weapons = 
    public float damage = 10f;
    public float range = 100f;
    public Camera FPScam;
    public float fireRate = 15f;
    public bool Discard = false;

    public float ExplosionDistance = 2f;
    public float RocketJumpPower;

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

            else if (hit.transform.tag == "Ground")
            {
                Debug.Log("Entró al tag");

                Vector3 distancedir = hit.transform.position - transform.position;

                float distance = distancedir.magnitude;

                Debug.Log(distance);

               if (distance <= ExplosionDistance)
                {
                    Debug.Log("RocketJump!");
                    rb.AddForce(transform.up * RocketJumpPower, ForceMode.Impulse);
                }
                
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

    }

    void OnFire2()
    {

        Discard = true;

        if (Discard == true)
        {
            

        }


        if (m_AlreadyFire2 == false)
        {
           
        }


    }
}
