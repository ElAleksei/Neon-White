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
    public PlayerMovement pm;

    private float nextTimetoFire = 0f;

    bool m_AlreadyFire2 = false;

    public Transform cam;
    public Transform GunTip;
    public LayerMask Grappable;
    public LineRenderer lr;

    public float MaxGrapDistance;
    public float GrapDelay;
    public float OvershootYaxis;

    private Vector3 GrapPoint;

    public float GrapCoolDown;
    private float GrapCoolDownTimer;

    private bool Grappling;
    public bool freeze;
    public bool ActiveGrapple;

    public float GrapplingSpeed = 10;

    public float MinDistance = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (GrapCoolDownTimer > 0)
        {
            GrapCoolDownTimer -= Time.deltaTime;
        }

        if(freeze)
        {
            pm.m_Speed = 0f;
            rb.velocity = Vector3.zero;
        }
        else
        {
            pm.m_Speed = 10f;
        }

        if (Grappling)
        {
            Vector3 DirectionMagnitude = GrapPoint - transform.position;

            Vector3 Direction = DirectionMagnitude.normalized;

            transform.position += Direction * GrapplingSpeed * Time.deltaTime;

            Debug.Log(DirectionMagnitude.magnitude);

            if (DirectionMagnitude.magnitude <= MinDistance)
            {
                EndGrapple();
            }
        }

    }

    private void LateUpdate()
    {
        if (Grappling)
        {
            lr.SetPosition(0, GunTip.position);
        }
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
            StartGrapple();

        }


        if (m_AlreadyFire2 == false)
        {
            StartGrapple();
        }


    }

    void StartGrapple()
    {
        if (GrapCoolDownTimer > 0) return;

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, MaxGrapDistance, Grappable))
        {
            Grappling = true;

            freeze = true;

            GrapPoint = hit.point;

            lr.enabled = true;
            lr.SetPosition(1, GrapPoint);

        }

        

    }

    void Grapple()
    {
       
    }

    void EndGrapple()
    {
        freeze = false;
        rb.drag = 0.05f;

        Grappling = false;

        GrapCoolDownTimer = GrapCoolDown;

        lr.enabled = false;
    }

   
}
