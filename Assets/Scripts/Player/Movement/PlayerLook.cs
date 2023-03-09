using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float m_ViewDistance = 90f;
    public Transform m_player;
    public float m_Sensitivity = 200f;
    float m_Rotation = 0f;
    // Start is called before the first frame update
    void Start()
    {   
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Mouse_X = Input.GetAxis("Mouse X") * m_Sensitivity * Time.deltaTime;
        float Mouse_Y = Input.GetAxis("Mouse Y") * m_Sensitivity * Time.deltaTime;

        m_Rotation -= Mouse_Y;
        m_Rotation = Mathf.Clamp(m_Rotation, -90f, m_ViewDistance);
        transform.localRotation = Quaternion.Euler(m_Rotation, 0f, 0f);
        m_player.Rotate(Vector3.up * Mouse_X);

    }
}
