using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float climbCooldown;
    public float airMultiplier;
    bool readyToJump, allowClimb;

    

    [HideInInspector] public float speed;
    Vector3 oldPosition;
    

    [HideInInspector] public float walkSpeed;
    public float sprintSpeed;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded, isRunning, onFront;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;


    float edgeHeight;
    Vector3 moveDirection;
    RaycastHit frontHit;
    Rigidbody rb;
    CapsuleCollider playerCollision;

    AnimationMenager animationManager;
    [SerializeField] Transform feet;
    Animator animator;

    float oldCapsuleHeight;

    private void Start()
    {
        allowClimb = true;

        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        animationManager = GetComponentInChildren<AnimationMenager>();
        animator = GameObject.Find("PlayerCharacter").GetComponent<Animator>();
        readyToJump = true;
        playerCollision = GetComponent<CapsuleCollider>();
        oldPosition = new Vector3(0,0,0);

        oldCapsuleHeight = playerCollision.height;
    }

    private void Update()
    {
        
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        onFront = Physics.Raycast(transform.position, transform.forward, out frontHit, 1f , whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        speed = Vector3.Distance(oldPosition, transform.position) * 100f;
        oldPosition = transform.position;

        if (onFront)
        {
            if(frontHit.collider != null)
            {
                edgeHeight = (frontHit.transform.position.y + frontHit.collider.bounds.extents.y) - feet.position.y;
                edgeHeight = Mathf.Abs(edgeHeight);
              

                if (edgeHeight < 2)
                {
                    allowClimb = true;
                }
                else
                {
                    allowClimb = false;
                }
            }
            else
            {
                allowClimb = false;
            }
           
        }
        else
        {
            allowClimb= false;
        }

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetButton("Jump") && readyToJump && grounded && allowClimb == false)
        {
            readyToJump = false;

            

            animationManager.Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
        else if(Input.GetButtonDown("Jump") && readyToJump && grounded && allowClimb == true)
        {
            readyToJump = false;
            allowClimb = false;

            Climb();

            Invoke(nameof(ResetClimb), climbCooldown);
        }

        if(Input.GetButton("Sprint"))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // on ground
        if (grounded)
        {
            if (isRunning)
            {
                rb.AddForce(moveDirection.normalized * sprintSpeed * 10f, ForceMode.Force);

                animator.SetBool("isRunning", true);
            }
            else
            {
                rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

                animator.SetBool("isRunning", false);
            }
        }
        // in air
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    void Climb()
    {
        animationManager.Climb();

        playerCollision.height = 1f;
        playerCollision.center = new Vector3(0, 0.5f, 0);
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        
    }

    public void Jump()
    {
        // reset y velocity
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

       
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
       
    }

    private void ResetClimb()
    {
        readyToJump = true;
        playerCollision.height = oldCapsuleHeight;
        playerCollision.center = new Vector3(0, 0, 0);
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere( frontHit.collider.bounds.center, 0.1f);
    //}
}