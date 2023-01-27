
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera FPScam;
    public float fireRate = 15f;

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
    }

    void OnFire2()
    {
        if (m_AlreadyFire2 == false)
        {
            rb.AddForce(0f, 5f, 0f, ForceMode.Impulse);
            m_AlreadyFire2 = true;
        }
        
    }
}
