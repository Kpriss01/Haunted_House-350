using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private Transform movePoint;
    [SerializeField]
    private LayerMask obstacleMask;
    [SerializeField]
    public GameObject sprite;
    Animator animator;
    Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = sprite.GetComponent<Animator>();
        movePoint.parent = null;
    }

    void Update()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        float movementAmount = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, movementAmount);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(inputHorizontal) == 1f)
            {
                Move(new Vector3(inputHorizontal, 0, 0));
                animator.SetBool("isMoving", true);

            }
            else if (Mathf.Abs(inputVertical) == 1f)
            {
                Move(new Vector3(0, inputVertical, 0));
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

        if (inputHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);

        }
        else if (inputHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        

    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = movePoint.position + direction;
        if (!Physics2D.OverlapCircle(newPosition, 0.2f, obstacleMask))
        {
            movePoint.position = newPosition;
        }
    }
}
