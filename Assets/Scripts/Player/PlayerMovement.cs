using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float movementSpeed = 3f;
    public float jumpmovementSpeedModifier = 0.5f;
    public float jumpForce = 7.5f;
    private Rigidbody2D rb;
    //private bool isGrounded = false;
    BoxCollider2D boxCollider;
    [SerializeField] LayerMask platformLayer;
    Animator characterAnimator;

    private static PlayerMovement _instance;
    private Vector3 doorExit;
    private bool done;

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
        characterAnimator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {

        if (done)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(0f, 0f, 0f), 0.002f);
            transform.position = Vector3.MoveTowards(transform.position, doorExit, 1f);
            characterAnimator.SetBool("isGrounded", isGrounded());
            return;
        }

        if (InputManager.Instance.canMove)
        {
            Vector2 velocity = new Vector2();
            velocity.x = isGrounded() ? (rb.velocity.x + Input.GetAxis("Horizontal") * movementSpeed) / 2f : (rb.velocity.x + Input.GetAxis("Horizontal") * movementSpeed) /2f;
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
            
            if (Input.GetButtonDown("Jump") && isGrounded())
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                //isGrounded = false;
            }
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            characterAnimator.SetFloat("Horizontal", 1);
        }

        if(Input.GetAxis("Horizontal") < 0)
        {
            characterAnimator.SetFloat("Horizontal", -1);
        }


        if (rb.velocity.y > 0)
        {
            characterAnimator.SetFloat("Vertical",1);
        }
        if (rb.velocity.y < 0)
        {
            characterAnimator.SetFloat("Vertical", -1);
        }

        characterAnimator.SetFloat("Speed", rb.velocity.sqrMagnitude);
        characterAnimator.SetBool("isGrounded", isGrounded());
    }

    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, platformLayer);
        return hit.collider != null;
    }

    public void LevelDone(Vector3 doorExit) {
        done = true;
        rb.bodyType = RigidbodyType2D.Kinematic;
        SpellManager.Instance.canSpell = false;
        this.doorExit = doorExit;
        SoundManager.Instance.PlayOneShot(SoundEvent.LEVELDONE);

       Invoke("GoToMenu", 1.5f);
    }

    public void GoToMenu()
    {
        UIManager.Instance.goToMainMenu();
    }
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Platform") && collision.transform.position.y < transform.position.y)
    //    {
    //        isGrounded = false;
    //    }
    //}
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Platform") && collision.transform.position.y < transform.position.y)
    //    {
    //        isGrounded = true;
    //    }
    //}
}
