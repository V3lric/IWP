using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData pData;
    public bool disabled = false;

    [Header("Player Stats")]
    public float speed = 10f;
    [SerializeField] int talentPt,coins;

    [Header("Movement Stats")]
    Vector2 movement;
    public float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;
    public Transform Cam;

    [Header("Jump Stats")]
    public bool airborne;
    protected float airborneTime;
    protected int jumpsInAir;
    protected int maxJumpsInAir = 1;
    public float jumpSpeed = 20f;
    public float jumpDelay = 0.1f;
    public float jumpheight;
    Vector3 Velocity;
    public float gravity = 80f;
    CharacterController characterController;

    public bool Grounded = true;//check if grounded
    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.32f;//radius of groundcheck
    public LayerMask Floor;//what layer player can walk on
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        speed = pData.GetWalkSpeed();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (!disabled)
        {
            {
                Movement();
                Gravity();
                CheckGrounded();
            }
        }
    }

    public void Movement()//WASD
    {

        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

    public void Gravity()//set gravity on player
    {
        //new jump code
        if (Grounded)
            Velocity.y = -1;

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Velocity.y += Mathf.Sqrt((jumpSpeed * 10) * -2f * gravity);
        }
        if (Velocity.y > -20)
            Velocity.y += (gravity * 10) * Time.deltaTime;

        characterController.Move(Velocity * Time.deltaTime);

        //// Check if player is grounded.
        //if (Grounded)
        //{
        //    jumpsInAir = maxJumpsInAir;
        //}
        //else
        //{
        //    moveDelta.y -= gravity * Time.deltaTime;
        //}

        //// Check if player is jumping.
        //if (Input.GetButtonDown("Jump"))
        //{
        //    if (!airborne || jumpsInAir > 0)
        //    {
        //        if (airborne)
        //        {
        //            jumpsInAir--;
        //        }

        //        moveDelta.y = jumpSpeed;

        //        airborne = true;
        //        airborneTime = jumpDelay;
        //    }
        //}

        //// Apply airborne time
        //if (airborneTime > 0)
        //{
        //    airborneTime -= Time.deltaTime;
        //}
        //else
        //{
        //    airborne = false;
        //}
    }
    private void CheckGrounded()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, Floor, QueryTriggerInteraction.Ignore);
    }
}