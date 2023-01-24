
using UnityEngine;

public class Gun : MonoBehaviour
{
    //public SO_Weapons = 
    public float damage = 10f;
    public float range = 100f;
    public Camera FPScam;
    public float fireRate = 15f;
    public bool Discard = false;

    public Rigidbody rb;

    private float nextTimetoFire = 0f;

    void Update()
    {
        
       // if (Input.GetButton("Fire1") && Time.time >= nextTimetoFire)
        //{
            //nextTimetoFire = Time.time + 1f / fireRate;
            //Shoot();
        //}

        //if (Input.GetButton("Fire2"))
        //{
           
            //rb.AddForce(0f, 5f, 0f, ForceMode.Force);
        //}
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
    }

    void OnFire2()
    {
        Discard = true;

        if(Discard == true)
        {
            Debug.Log("Entró");
            rb.AddForce(0f, 5f, 0f, ForceMode.Impulse);

        }
        
        
    }
}
