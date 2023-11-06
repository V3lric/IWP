using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData pData;
    [Header("Player Stats")]
    [SerializeField] int walkSpeed;
    [SerializeField] int talentPt,coins;

    [Header("Movement Stats")]
    public float maxForwardSpeed = 5f;
    public float maxBackwardSpeed = 4f;
    public float acceleration = 20.0f;
    public float maxRotateSpeed = 150f;
    public float rotateAcceleration = 600f;
    protected Vector3 directSpeed;
    protected float speed;
    protected float rotateSpeed;
    protected Vector3 moveDelta = Vector3.zero;

    [Header("Jump Stats")]
    public bool airborne;
    protected float airborneTime;
    protected int jumpsInAir;
    protected int maxJumpsInAir = 1;
    public float jumpSpeed = 20f;
    public float jumpDelay = 0.1f;
    public float gravity = 80f;
    CharacterController characterController;

    public bool Grounded = true;//check if frounded
    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.32f;//radius of groundcheck
    public LayerMask Floor;//what layer player can walk on
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        walkSpeed = pData.GetWalkSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Gravity();
        CheckGrounded();
    }

    public void Movement()//WASD
    {
        // Calculate direct speed and speed.
        var right = Vector3.right;
        var forward = Vector3.forward;
        if (Camera.main)
        {
            right = Camera.main.transform.right;
            right.y = 0.0f;
            right.Normalize();
            forward = Camera.main.transform.forward;
            forward.y = 0.0f;
            forward.Normalize();
        }

        var targetSpeed = right * Input.GetAxisRaw("Horizontal");
        targetSpeed += forward * Input.GetAxisRaw("Vertical");
        if (targetSpeed.sqrMagnitude > 0.0f)
        {
            targetSpeed.Normalize();
        }
        targetSpeed *= maxForwardSpeed;

        var speedDiff = targetSpeed - directSpeed;
        if (speedDiff.sqrMagnitude < acceleration * acceleration * Time.deltaTime * Time.deltaTime)
        {
            directSpeed = targetSpeed;
        }
        else if (speedDiff.sqrMagnitude > 0.0f)
        {
            speedDiff.Normalize();

            directSpeed += speedDiff * acceleration * Time.deltaTime;
        }
        speed = directSpeed.magnitude;

        // Calculate rotation speed - ignore rotate acceleration.
        rotateSpeed = 0.0f;
        if (targetSpeed.sqrMagnitude > 0.0f)
        {
            var localTargetSpeed = transform.InverseTransformDirection(targetSpeed);
            var angleDiff = Vector3.SignedAngle(Vector3.forward, localTargetSpeed.normalized, Vector3.up);

            if (angleDiff > 0.0f)
            {
                rotateSpeed = maxRotateSpeed;
            }
            else if (angleDiff < 0.0f)
            {
                rotateSpeed = -maxRotateSpeed;
            }

            // Assumes that x > NaN is false - otherwise we need to guard against Time.deltaTime being zero.
            if (Mathf.Abs(rotateSpeed) > Mathf.Abs(angleDiff) / Time.deltaTime)
            {
                rotateSpeed = angleDiff / Time.deltaTime;
            }
        }
        moveDelta = new Vector3(directSpeed.x, moveDelta.y, directSpeed.z);

        // Calculate move delta.
        characterController.Move(directSpeed * (speed * Time.deltaTime) + new Vector3(0.0f, moveDelta.y, 0.0f) * Time.deltaTime);
    }
    public void Gravity()//set gravity on player
    {
        //Check if player is grounded.
        if (Grounded)
        {
            jumpsInAir = maxJumpsInAir;
        }
        else
            moveDelta.y -= gravity * Time.deltaTime;
        // Check if player is jumping.
        if (Input.GetButtonDown("Jump"))
        {
            if (!airborne || jumpsInAir > 0)
            {
                if (airborne)
                {
                    jumpsInAir--;
                }

                moveDelta.y = jumpSpeed;

                airborne = true;
                airborneTime = jumpDelay;
            }
        }
    }
    private void CheckGrounded()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, Floor, QueryTriggerInteraction.Ignore);
    }
}