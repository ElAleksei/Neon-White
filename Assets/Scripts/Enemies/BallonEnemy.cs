using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonEnemy : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.rigidbody.AddForce(new Vector3(0f,10f,0f), ForceMode.Impulse);
            Destroy(gameObject);
        }

    }
}
