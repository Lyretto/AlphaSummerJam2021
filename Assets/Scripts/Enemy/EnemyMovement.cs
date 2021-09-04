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
    public LayerMask wallLayer;

    public Animator enemyAnimator;

   
    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
        if (mustFlip) Flip();

        if (mustPatrol && canMove)  rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        enemyAnimator.SetFloat("movement", rb.velocity.x);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.gameObject.layer != groundLayer)
            Flip();
    }


    private void Flip()
    {
    mustPatrol = false;
    rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    walkSpeed *= -1;
    mustPatrol = true;
    }
}
