using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool mustFlip;
    public bool mustPatrol;
    [HideInInspector] public bool canMove = true;
    public Rigidbody2D rb; 
    public float walkSpeed;
    public Transform groundCheckPos;
    public Collider2D bodyCollider;

    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (mustPatrol && canMove) Patrol();
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    private void Patrol()
    {
        if (mustFlip || bodyCollider.IsTouchingLayers(groundLayer)) Flip();
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }



    private void Flip()
    {
    mustPatrol = false;
    rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    walkSpeed *= -1;
    mustPatrol = true;
    }
}
