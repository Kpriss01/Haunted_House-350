using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
   [SerializeField] private Vector3 moveDirection;
    [SerializeField] private float flip;
    [SerializeField] public bool Attack = false;

    public bool rightfacing = true;
    public bool FacingRight;

    private Collider2D enemycollider;
    private Collider2D playercollider;
    private Rigidbody2D rb;
    private Animator animator;
    private Animator camera;
    Animator cameraAnimator;
    private Transform target;
    private bool active = false;
    private bool collide = false;

    private bool attack = false;

    [SerializeField] private AudioClip monsterRoarSound; // Assign the "monster_roar" sound in the Inspector
    private AudioSource audioSource;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cameraAnimator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playercollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        enemycollider = GetComponent<CapsuleCollider2D>();
        playercollider.isTrigger = true;
    }

    public void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        moveDirection = direction;
        flip = moveDirection.x;
    }

    private void FixedUpdate()
    {
        if (active || collide)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
            animator.SetBool("isMoving", true);
            SetFacingDirection(flip);
        }

        if (attack)
        {
            Attack = true;
            animator.SetBool("Attack", true);
            cameraAnimator.SetBool("isShaking", true);

            // Play the "monster_roar" sound
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(monsterRoarSound);
            }
        }
        else
        {
            Attack = false;
            animator.SetBool("Attack", false);
            cameraAnimator.SetBool("isShaking", false);
        }
    }

    private void SetFacingDirection(float flip)
    {
        if (flip >= 0 && !FacingRight)
        {
            FacingRight = true;
            if (rightfacing != FacingRight)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            rightfacing = FacingRight;
        }
        else if (flip < 0 && FacingRight)
        {
            FacingRight = false;
            if (rightfacing != FacingRight)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            rightfacing = FacingRight;
        }
    }


    private bool allow = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        collide = true;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if (allow)
        {
            StartCoroutine(Attacker());
            StartCoroutine(Counter());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        collide = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private IEnumerator Attacker()
    {
        active = true;
        attack = true;
        yield return new WaitForSeconds(1);
        attack = false;
        yield return new WaitForSeconds(1);
        active = false;
    }

    private IEnumerator Counter()
    {
        allow = false;
        yield return new WaitForSeconds(4);
        allow = true;
    }

}
