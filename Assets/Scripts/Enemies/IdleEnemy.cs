using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleEnemy : MonoBehaviour
{

    public Transform m_player;
    public LayerMask m_layermask;

    public float m_Cooldown;
    bool m_AttackOn;
    public GameObject m_bullet;

    public float m_attackRange;
    public bool m_PlayerInAttackRange;

    private void Awake()
    {
        m_player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        m_PlayerInAttackRange = Physics.CheckSphere(transform.position, m_attackRange, m_layermask);

        if (m_PlayerInAttackRange) Attack();
    }

    private void Attack()
    {
        transform.LookAt(m_player);

        if (!m_AttackOn)
        {
            Rigidbody Bulletrb = Instantiate(m_bullet, transform.position + (transform.forward * 1),Quaternion.identity).GetComponent<Rigidbody>();
            Bulletrb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            Bulletrb.AddForce(transform.up * 2f, ForceMode.Impulse);

            m_AttackOn = true;
            Invoke(nameof(ResetAttack), m_Cooldown);
        }
    }

    private void ResetAttack()
    {
        m_AttackOn = false;
    }
}
