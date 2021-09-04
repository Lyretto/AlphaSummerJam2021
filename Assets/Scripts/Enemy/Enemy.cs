using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 9;
    Rigidbody2D enemyRb;
    [SerializeField] float freezeTime;
    [SerializeField] int burningDamage;
    [SerializeField] int freezeDamage;
    float currentFreezeTime;
    bool freeze = false;
    SpriteRenderer enemySr;
    private bool isInKillzone = false;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySr = GetComponent<SpriteRenderer>();
        currentFreezeTime = freezeTime;
    }

    private void Update()
    {
        if (currentFreezeTime >= 0 && freeze)
        {
            currentFreezeTime -= Time.deltaTime;
            GetComponent<EnemyMovement>().canMove = false;
            if (currentFreezeTime <= 0)
            {
                if (isInKillzone) Destroy(gameObject);
                freeze = false;
                currentFreezeTime = freezeTime;
                GetComponent<EnemyMovement>().canMove = true;
            }
        }

        if(health <= 0)
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Killzone"))
            Destroy(this.gameObject);
        if (collision.transform.CompareTag("Player"))
            Player.Instance.ChangeLifes(-1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ice"))
        {
            Debug.Log("Vereist");
            takeDamage(freezeDamage);
            freeze = true;
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


}
