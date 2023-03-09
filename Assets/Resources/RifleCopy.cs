using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleCopy : MonoBehaviour
{
    public Transform orientation;
    public Transform PlayerCam;
    public Rigidbody rb;
    private PlayerMovement pm;

    public float DashForce;
    public float DashUpwardForce;
    public float DashDuration;

    public float DashCooldown;
    private float CoolDownTimer;

    //public SO_Weapons = 
    public float damage = 10f;
    public float range = 100f;
    public Camera FPScam;
    public float fireRate = 15f;
    public bool Discard = false;

    private float nextTimetoFire = 0f;

    bool m_AlreadyFire2 = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    void Dash()
    {
        Vector3 dashforce = orientation.forward * DashForce + orientation.up * DashUpwardForce;

        rb.AddForce(dashforce, ForceMode.Impulse);

        Invoke(nameof(ResetDash), DashDuration);
    }

    void ResetDash()
    {

    }

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
            Dash();

        }


        if (m_AlreadyFire2 == false)
        {
            Dash();
        }


    }
}
