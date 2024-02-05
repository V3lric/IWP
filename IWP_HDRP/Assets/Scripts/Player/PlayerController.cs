using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerData pData;
    public static PlayerController Instance;
    public bool disabled = false;
    public Animator animator;
    public ParticleSystem particleBurst,truffleBurst;
    public GameObject body,truffle;
    [SerializeField] float idleTimer = 10f;
    [SerializeField] float animTimer;
    [SerializeField] bool bIdleAnim = false;
    [Header("Player Stats")]
    public float speed = 10f;
    [SerializeField] int talentPt,coins;

    [Header("Movement Stats")]
    Vector2 movement;
    public float turnSmoothTime = 0.1f;
    [SerializeField] float turnSmoothVelocity;
    public Transform Cam;

    [Header("Jump Stats")]
    protected float airborneTime;
    public int jumpsInAir;
    public int maxJumpsInAir = 1;
    public float jumpSpeed = 20f;
    public float jumpDelay = 0.1f;
    public float jumpheight;
    public Vector3 Velocity;
    public float gravity = 80f;
    CharacterController characterController;

    public bool Grounded = true;//check if grounded
    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.32f;//radius of groundcheck
    public LayerMask Floor;//what layer player can walk on
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        characterController = GetComponent<CharacterController>();
        pData = GameObject.FindGameObjectWithTag("Data").GetComponent<PlayerData>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disabled)
        {
            Movement();
            Gravity();
            CheckGrounded();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if (disabled)//to do, ensure map disable don't override the esc disbale
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Movement()//WASD
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x, 0f, movement.y).normalized;
        if (direction.magnitude >= 0.1f)
        {
            idleTimer = 10f;
            animTimer = 2.117f;
            bIdleAnim = false;
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            animator.SetFloat("Player", 2f, 0.01f, 1f * Time.deltaTime);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        if (direction == new Vector3(0, direction.y,0) && !bIdleAnim)
        {
            animator.SetFloat("Player", 0f);
            idleTimer -= Time.deltaTime;
        }

        if (idleTimer < 0)
        {
            bIdleAnim = true;

        }
        if (bIdleAnim)
        {
            animator.SetFloat("Player", 1f,0,Time.deltaTime);
            animTimer -= Time.deltaTime;
            if (animTimer < 0)
            {
                bIdleAnim = false;
                animTimer = 2.117f;
                idleTimer = 10f;
            }
        }
    }

    public void Gravity()//set gravity on player
    {
        //new jump code
        if (Grounded)
        {
            Velocity.y = 0;
            jumpsInAir = maxJumpsInAir;
        }
        else
        {
            Velocity.y += (gravity * 10) * Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (jumpsInAir > 0)
            {
                Velocity.y += Mathf.Sqrt((jumpSpeed * 10) * -2f * gravity);
                jumpsInAir--;
            }
            animator.PlayInFixedTime("Jump");
        }
        //if (Velocity.y > -20 || Velocity.y < -100)
        //    Velocity.y += (gravity * 10) * Time.deltaTime;

        characterController.Move(Velocity * Time.deltaTime);
    }
    private void CheckGrounded()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, Floor, QueryTriggerInteraction.Ignore);
    }
    public void PlayerDeath()
    {
        StartCoroutine(Death());
    }
    IEnumerator Death()
    {
        disabled = true;
        yield return new WaitForSeconds(2f);
        particleBurst.Play();
        truffleBurst.Play();
        yield return new WaitForSeconds(0.1f);
        body.SetActive(false);
        truffle.SetActive(false);

    }
}