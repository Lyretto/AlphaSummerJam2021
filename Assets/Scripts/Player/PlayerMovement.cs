using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;

    float horizontal;

    public float movementSpeed = 10f;
    public float jumpForce = 100f;
    [SerializeField] LayerMask groundLayer;

    private static PlayerMovement _instance;
    public static PlayerMovement Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (InputManager.Instance.canMove)
        {
            Vector2 velocity = new Vector2();
            velocity.x = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
            velocity.y = Input.GetButtonDown("Jump") ? jumpForce : rb.velocity.y;
            rb.velocity = velocity;            
        }

    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, groundLayer);
        return hit.collider != null;
    }

}
