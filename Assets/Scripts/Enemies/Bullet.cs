using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float m_LifeTime = 2f;
    float m_CurrentTime;
    

    // Update is called once per frame
    void Update()
    {
        m_CurrentTime += Time.deltaTime;

        if (m_CurrentTime >= m_LifeTime)
        {
            Destroy(gameObject);
        }
    }
}
