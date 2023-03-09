
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    GameManager m_Manager;
    private void Awake()
    {
        m_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        m_Manager.AddEnemyCount();
        Destroy(gameObject);
    }
}
