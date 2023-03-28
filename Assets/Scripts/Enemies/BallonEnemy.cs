using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonEnemy : MonoBehaviour
{
    GameManager m_Manager;
    private void Awake()
    {
        m_Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.rigidbody.velocity.y < 0)
            {
                collision.rigidbody.velocity = new Vector3(0,0,0);
            }

            collision.rigidbody.AddForce(new Vector3(0f,10f,0f), ForceMode.Impulse);
            m_Manager.AddEnemyCount();
            Destroy(gameObject);
        }

    }
}
