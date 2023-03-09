using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallrunning : MonoBehaviour
{
    public LayerMask IsGround;
    public LayerMask IsWall;
    public float wallRunForce;
    public float maxWallRunTimer;
    public float WalljumpUpForce;
    public float WallJumpSideForce;
    private float wallRunTimer;
    

    private float horizontalInput;
    private float verticalInput;

    public float wallCheckDistance;
    public float minJumpHeight;

    private RaycastHit LeftWallHit;
    private RaycastHit RightWallHit;

    private bool LeftWall;
    private bool RightWall;
    private bool Wallrun;
    private bool exitingWall;
    public float exitWallTime;
    private float exitWallTimer;

    public Transform orientation;
    private PlayerMovement pm;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        CheckForWall();
    }

    private void CheckForWall()
    {
        LeftWall = Physics.Raycast(transform.position, -orientation.right, out LeftWallHit, wallCheckDistance, IsWall);
        RightWall = Physics.Raycast(transform.position, orientation.right, out RightWallHit, wallCheckDistance, IsWall);
    }

    private bool AboveGround()
    {
        return !Physics.Raycast(transform.position, Vector3.down, minJumpHeight, IsGround);
    }

    private void StateMachine()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if((LeftWall || RightWall) && verticalInput > 0 && AboveGround() && !exitingWall)
        {
            if (!Wallrun)
            {
                StartWallRun();

                if (Input.GetKeyDown("Space"))
                {
                    WallJump();
                }
            }

            else if (exitingWall)
            {
                if (Wallrun)
                {
                    StopWallRun();
                }

                if (exitWallTime > 0)
                {
                    exitWallTimer -= Time.deltaTime;
                }

                if (exitWallTimer <= 0)
                {
                    exitingWall = false;
                }
            }

            else
            {
                if (Wallrun)
                {
                    StopWallRun();
                }
                
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (Wallrun)
        {
            WallRun();
        }
    }

    private void StartWallRun()
    {
        Wallrun = true;
        pm.WallRunSpeed = pm.m_Speed;
        
    }

    private void WallRun()
    {
        rb.useGravity = false;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        Vector3 WallNomal = RightWall ? RightWallHit.normal : LeftWallHit.normal;

        Vector3 WallForward = Vector3.Cross(WallNomal, transform.up);

        if ((orientation.forward - WallForward).magnitude > (orientation.forward - -WallForward).magnitude)
        {
            WallForward = -WallForward;
        }
        
        if (!(LeftWall && horizontalInput > 0) && !(RightWall && horizontalInput < 0))
        {
            rb.AddForce(-WallNomal * 100, ForceMode.Force);
        }

        
        
        
    }

    private void StopWallRun()
    {
        Wallrun = false;
        pm.WallRunSpeed = 0;
    }

    private void WallJump()
    {
        exitingWall = true;
        exitWallTimer = exitWallTime;

        Vector3 WallNomal = RightWall ? RightWallHit.normal : LeftWallHit.normal;

        Vector3 ForcetoApply = transform.up * WalljumpUpForce + WallNomal * WallJumpSideForce;

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(ForcetoApply, ForceMode.Impulse);

    }


}
