using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    //Slide variables
    public Transform Orientation;
    public Transform PlayerObj;
    private float SlideSpeed;
    public float SlideScale;
    private float StartSlideScale;
    private Rigidbody rb;
    private PlayerMovement pm;

    public float maxSlideTime;
    public float SlideForce;
    private float SlideTimer;

    public KeyCode slideKey = KeyCode.LeftControl;
    private float horizontalInput;
    private float verticalInput;

    private bool sliding;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();

        StartSlideScale = PlayerObj.localScale.y;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKey) && (horizontalInput != 0 || verticalInput != 0))
        {
            StartSlide();
        }

        if (Input.GetKeyUp(slideKey) && sliding)
        {
            StopSlide();
        }
    }

    private void StartSlide()
    {
        sliding = true;

        PlayerObj.localScale = new Vector3(PlayerObj.localScale.x, SlideScale, PlayerObj.localScale.z);
        rb.AddForce(Vector3.down, ForceMode.Force);
        SlideTimer = maxSlideTime;
    }

    private void FixedUpdate()
    {
        if (sliding)
        {
            SlideMovement();
        }
    }

    private void SlideMovement()
    {
        Vector3 InputDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        rb.AddForce(InputDirection.normalized * SlideForce, ForceMode.Force);

        SlideTimer -= Time.deltaTime;

        if (SlideTimer <= 0)
        {
            StopSlide();
        }
    }

    private void StopSlide()
    {
        sliding = false;

        PlayerObj.localScale = new Vector3(PlayerObj.localScale.x, StartSlideScale, PlayerObj.localScale.z);
    }


}
