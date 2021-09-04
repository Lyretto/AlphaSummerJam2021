using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 9;
    Rigidbody2D enemyRb;
    [SerializeField] float freezeTime;
    [SerializeField] float stunTime;
    [SerializeField] float shootIntervall;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int burningDamage;
    [SerializeField] int freezeDamage;
    [SerializeField] bool isShooter;
    [HideInInspector] public bool stuned = false;
    Animator enemyAnimator;
    float currentFreezeTime;
    float currentStunTime;
    float currentShootIntervall;
    public bool freeze = false;
    public bool canShoot = true;
    SpriteRenderer enemySr;
    private bool isInKillzone = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySr = GetComponentInChildren<SpriteRenderer>();
        enemyAnimator = GetComponent<Animator>();
        currentFreezeTime = freezeTime;
        currentStunTime = stunTime;
        currentShootIntervall = shootIntervall;
    }

    private void Update()
    {

        if (currentFreezeTime >= 0 && freeze)
        {
            enemySr.color = new Color(0.5f,0.7f,1f,1f);
            enemyAnimator.enabled = false;
            currentFreezeTime -= Time.deltaTime;
            GetComponent<EnemyMovement>().canMove = false;
            if (currentFreezeTime <= 0)
            {
                if (isInKillzone) Destroy(gameObject);
                enemySr.color = new Color(1f,1f,1f,1f);
                freeze = false;
                enemyAnimator.enabled = true;
                canShoot = true;
                currentFreezeTime = freezeTime;
                GetComponent<EnemyMovement>().canMove = true;
            }
        }

        if (currentShootIntervall >= 0 && canShoot && isShooter)
        {
            currentShootIntervall -= Time.deltaTime;  
            if (currentShootIntervall <= 0)
            {
                Shoot();
                currentShootIntervall = shootIntervall;
            }
        }

        if (currentStunTime >= 0 && stuned)
        {
            currentStunTime -= Time.deltaTime;
            GetComponent<EnemyMovement>().canMove = false;
            enemyRb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (currentStunTime <= 0)
            {
                stuned = false;
                canShoot = true;
                currentStunTime = stunTime;
                GetComponent<EnemyMovement>().canMove = true;
                enemyRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
        
        if (health <= 0)
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Killzone"))
            Destroy(this.gameObject);
        if (collision.transform.CompareTag("Player") && !freeze && !stuned)
            Player.Instance.ChangeLifes(-1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ice"))
        {
            Debug.Log("Vereist");
            takeDamage(freezeDamage);
            freeze = true;
            canShoot = false;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Gravity"))
        {
            Debug.Log("Schwerkraft!!");
            enemyRb.gravityScale = enemyRb.gravityScale * -1;
            if (enemyRb.gravityScale < 1)
            {
                canShoot = false;
            }
            else
            {
                canShoot = true;
            }
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Stun"))
        {
            Debug.Log("Bleibe Stehen du Unhold!!");
            canShoot = false;
            stuned = true;
            Destroy(collision.gameObject);
        }

        if (collision.transform.CompareTag("Fire"))
        {
            Debug.Log("Angebrannt");
            takeDamage(burningDamage);
            collision.GetComponent<FireBall>().Explosion();
        }
        if (collision.CompareTag("Killzone"))
        {
            if (!freeze)
                Destroy(gameObject);
            isInKillzone = true;
        }
        if (collision.CompareTag("GroundKillzone"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Killzone"))
        {
            isInKillzone = false;
        }
    }

    void takeDamage(int amount)
    {
        health -= amount;
    }

    void die()
    {
        Destroy(this.gameObject);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3.Normalize(Player.Instance.transform.position - transform.position)), Quaternion.identity);
    }
}
