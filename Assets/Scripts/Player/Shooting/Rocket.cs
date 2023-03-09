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

    private bool enableMovement;

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
        
        Grappling = true;

        freeze = true;

        

        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.forward, out hit, MaxGrapDistance, Grappable))
        {
            GrapPoint = hit.point;

            Invoke(nameof(Grapple), GrapDelay);
        }
        else
        {
            GrapPoint = cam.position + cam.forward * MaxGrapDistance;
            Invoke(nameof(EndGrapple), GrapDelay);
        }

        lr.enabled = true;
        lr.SetPosition(1, GrapPoint);

    }

    void Grapple()
    {
        freeze = false;
        rb.drag = 0f;

        Vector3 lowestPoint = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);

        float grapplePointRelativeYPos = GrapPoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + OvershootYaxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = OvershootYaxis;

        JumpToPosition(GrapPoint, highestPointOnArc);

        Invoke(nameof(EndGrapple), 1f);
    }

    void EndGrapple()
    {
        freeze = false;
        rb.drag = 0.05f;

        Grappling = false;

        GrapCoolDownTimer = GrapCoolDown;

        lr.enabled = false;
    }

    public void JumpToPosition(Vector3 TargetPosition, float TrajectoryHeight)
    {
        ActiveGrapple = true;
        rb.velocity = CalculateJumpVelocity(transform.position, TargetPosition, TrajectoryHeight);
        VelocityToSet = CalculateJumpVelocity(transform.position, TargetPosition, TrajectoryHeight);
        Invoke(nameof(SetVelocity), 0.1f);
    }

    private Vector3 VelocityToSet;

    private void SetVelocity()
    {
        freeze = false;
        rb.velocity = VelocityToSet;
    }

    public Vector3 CalculateJumpVelocity(Vector3 Startpoint, Vector3 Endpoint, float TrajectoryHeight)
    {
        float gravity = Physics.gravity.y;
        float displacementY = Endpoint.y - Startpoint.y;

        Vector3 DisplacementXZ = new Vector3(Endpoint.x - Startpoint.x, 0f, Endpoint.z - Startpoint.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * TrajectoryHeight);
        Vector3 velocityXZ = DisplacementXZ / (Mathf.Sqrt(-2 * TrajectoryHeight / gravity) + Mathf.Sqrt(2 * (displacementY - TrajectoryHeight) / gravity));

        return velocityXZ + velocityY;
    }
}
